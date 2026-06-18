
using ExcelDataReader;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UsefulLibs.src.converter
{
    public class ExcelToSqliteConverter
    {
        private string? DetermineNumericType(DataTable dt, string columnName)
        {
            bool hasFloatValues = false;
            bool hasNumericData = false;

            foreach (DataRow dr in dt.Rows)
            {
                object value = dr[columnName];
                if (value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()))
                    continue;
                string input = value.ToString().Trim();
                if (int.TryParse(input, out _))
                {
                    hasNumericData = true;
                    continue;
                }
                if (double.TryParse(input, out _))
                {
                    hasNumericData = true;
                    hasFloatValues = true;
                }
            }
            if (!hasNumericData) return null;
            return hasFloatValues ? "Float" : "Int";
        }

        private string MapCSharpTypeToSqlite(Type csharpType, string? determinedNumeric)
        {
            if (determinedNumeric != null)
            {
                if (determinedNumeric == "Float")
                {
                    return "REAL";
                }
                else if (determinedNumeric == "Int")
                {
                    return "INTEGER";
                }
            }
            if (csharpType == typeof(int) || csharpType == typeof(short) || csharpType == typeof(long) || csharpType == typeof(bool))
                return "INTEGER";
            else if (csharpType == typeof(double) || csharpType == typeof(float) || csharpType == typeof(decimal))
                return "REAL";
            else if (csharpType == typeof(DateTime))
                return "TEXT";
            else
                return "TEXT";
        }

        public DataTable OpenSheet(string filePath)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {

                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();

                    DataTable dt = result.Tables[0];
                    return dt;
                }
            }
        }
        public int CheckDataIfExists(string dbPath, string tableName)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append($"SELECT 1 FROM {tableName}");
            string sqlCommand = sqlBuilder.ToString();
            using(var connection = new SqliteConnection($"Data Source={dbPath}; Foreign Keys=True;"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlCommand, connection);
                try
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var result = reader.GetValue(0);
                                int.TryParse(result.ToString(), out int res);
                                return 1;
                            }
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                catch (Microsoft.Data.Sqlite.SqliteException sqlEx) {
                    Debug.WriteLine($"Failed to execute command, table doesn't exist: {sqlEx}");
                }
                
                connection.Close();
            }
            return -1;
        }

        public void CreateTable(
            string dbPath, 
            string tableName, 
            DataTable dt, 
            Dictionary<string, string>? foreignKeyConfig = null, 
            Dictionary<string, string>? appendUniqueness = null)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append($"CREATE TABLE IF NOT EXISTS [{tableName}] (");
            sqlBuilder.Append($"[Id] INTEGER PRIMARY KEY AUTOINCREMENT");

            DataRow titleRow = dt.Rows[0];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sqlBuilder.Append(", ");
                string columnName = titleRow[i].ToString();
                DataColumn column = dt.Columns[i];
                string? determinedType = DetermineNumericType(dt, column.ColumnName);
                string sqliteType = MapCSharpTypeToSqlite(column.DataType, determinedType);
                
                sqlBuilder.Append($"[{titleRow[i]}] {sqliteType}");
                
                if(appendUniqueness != null && appendUniqueness.Count > 0)
                {
                    foreach(var el in appendUniqueness)
                    {
                        if(tableName == el.Key && columnName == el.Value)
                        {
                            sqlBuilder.Append(" UNIQUE");
                        }
                    }
                }
            }


            if (foreignKeyConfig != null && foreignKeyConfig.Count > 0) {
                foreach (var kvp in foreignKeyConfig) 
                {
                    sqlBuilder.Append(", ");
                    sqlBuilder.Append($"FOREIGN KEY({kvp.Key}) REFERENCES {kvp.Value}");
                }
            }

            sqlBuilder.Append(");");

            string createTableSql = sqlBuilder.ToString();
            sqlBuilder.Clear();
            Debug.WriteLine($"Generated SQL: {createTableSql}");
            
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = dbPath;
            connectionStringBuilder.Mode = SqliteOpenMode.ReadWriteCreate;
            connectionStringBuilder.ForeignKeys = true;

            var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
            
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = createTableSql;
                command.ExecuteNonQuery();
            }

            Debug.WriteLine($"Database successfully created at: {dbPath}");
            connection.Close();
        }

        public void InsertData(string dbPath, string tableName, DataTable dt)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = dbPath;
            connectionStringBuilder.Mode = SqliteOpenMode.ReadWriteCreate;
            connectionStringBuilder.ForeignKeys = true;

            StringBuilder sqlBuilder = new StringBuilder();
            DataRow titleRow = dt.Rows[0];

            sqlBuilder.Append($"INSERT INTO {tableName} (");
            for (int i = 0; i < titleRow.ItemArray.Length; i++)
            {
                sqlBuilder.Append($"[{titleRow[i]}]");
                if (i < titleRow.ItemArray.Length - 1)
                {
                    sqlBuilder.Append(',');
                }
            }
            sqlBuilder.Append(") VALUES ");

            for (int row = 1; row < dt.Rows.Count; row++)
            {
                sqlBuilder.Append("(");
                for (int col = 0; col < dt.Rows[row].ItemArray.Length; col++)
                {
                    string safeValue = dt.Rows[row].ItemArray[col].ToString().Replace("'", "''");
                    sqlBuilder.Append($"'{safeValue}'");

                    if (col < dt.Rows[row].ItemArray.Length - 1)
                    {
                        sqlBuilder.Append(',');
                    }
                }
                if (row < dt.Rows.Count - 1)
                {
                    sqlBuilder.Append("),\n");
                }
                else
                {
                    sqlBuilder.Append(");");
                }
            }

            string debugSql = sqlBuilder.ToString();

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = debugSql;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
