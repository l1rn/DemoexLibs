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

### Install packages for exam in local directory:
```cmd
curl -s https://raw.githubusercontent.com/l1rn/DemoexLibs/main/install-nuget-packages.bat > %temp%\i.bat && %temp%\i.bat
```
```ps
irm https://raw.githubusercontent.com/l1rn/DemoexLibs/main/install-nuget-packages.ps1 | iex
```
> GitHub
```cmd
curl -s https://install.lirn-dev.ru/install-nuget-packages.bat > %temp%\i.bat && %temp%\i.bat
```
```ps
irm https://install.lirn-dev.ru/install-nuget-packages.ps1 | iex
```
> TODO: remove
