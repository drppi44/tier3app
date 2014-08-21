Tier 3 application. Library.

Environment Requirements:<br>
  ASP.NET application,
  .NET Framework 2.0 or higher, 
  MSSQL 2008

Installation guide:
  -Open project
  -Import MyDB 
  -Change coString to connect current database
    
      (dal -> DALCLASS.cs line-14)
      string coString =
             @"Data Source=.\sqlexpress;Database=myDB;Trusted_Connection=True;";
  
  -run project
