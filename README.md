#### Converter:
```C#
ExcelToSqliteConverter excelToSqliteConverter = new ExcelToSqliteConverter();
DataTable dt = excelToSqliteConverter.OpenSheet("data.xslx");
excelToSqliteConverter.CreateSqliteTableFromDatable("data.db", "table_name", dt);
```

#### Forms libray:
```C#
: LoginForm
: BaseForm // main form
```

#### Filter functions:
```C#
// using UsefulLibs.src.common;
// protected bool _ascending { get; set; } = true;
string searchText = textBox1.Text.Trim();
string filterText = comboBox1.Text;

IQueryable<T> query = _masterTList.AsQueryable(); // replace T with the your model
query = SearchAllFields(query, searchText);
query = FilterBy(filterText, "all", query, x => x.T); // replace T and "all" with parameters for your model (T - column, "all" - parameter in element that will return all elements)
query = SortBy(query, x => x.T, _ascending);

UpdateTable(query.ToList());
```
