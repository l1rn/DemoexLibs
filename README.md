#### Converter:
```C#
ExcelToSqliteConverter excelToSqliteConverter = new ExcelToSqliteConverter();
DataTable dt = excelToSqliteConverter.OpenSheet("data.xslx");
excelToSqliteConverter.CreateSqliteTableFromDatable("data.db", "table_name", dt);
```

#### Forms libray:
```
: LoginForm
: BaseForm // main form
```