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
: BaseEditForm
```

#### Filter functions:
```C#
// using UsefulLibs.src.common;
// protected bool _ascending { get; set; } = true;
string searchText = textBox1.Text.Trim();
string filterText = comboBox1.Text;

IQueryable<T> query = _masterTList.AsQueryable(); // replace T with the your model name
query = SearchAllFields(query, searchText);
query = FilterBy(filterText, "all", query, x => x.T);
query = SortBy(query, x => x.T, _ascending);

UpdateTable(query.ToList());
```
> T - column that you want to filter / sort, "all" - parameter in element that will return all for the current model list
