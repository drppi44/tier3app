Tier 3 application. Library.

Environment Requirements:<br>
  ASP.NET application,<br>
  .NET Framework 2.0 or higher, <br>
  MSSQL 2008<br>
<br>
Installation guide:
<ul>
<li>
  -Open project<br>
  </li>
  <li>
  -Import MyDB <br>
  </li>
  <li>
  -Change coString to connect current database:<br>
      (dal -> DALCLASS.cs line-14)<br>
      string coString =<br>
             @"Data Source=.\sqlexpress;Database=myDB;Trusted_Connection=True;";</li>
  <li>
  -run project<br>
  </li>
</ul>
