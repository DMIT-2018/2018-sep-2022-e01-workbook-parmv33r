<Query Kind="Statements">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c12aaaaa</ID>
    <NamingService>2</NamingService>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\ChinookDemoDb.sqlite</AttachFileName>
    <DisplayName>Demo database (SQLite)</DisplayName>
    <DriverData>
      <PreserveNumeric1>true</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.Sqlite</EFProvider>
      <MapSQLiteDateTimes>true</MapSQLiteDateTimes>
      <MapSQLiteBooleans>true</MapSQLiteBooleans>
    </DriverData>
  </Connection>
</Query>

//the statement IDE
//This environemnet expects the use of C# statement grammar.
//the results of the query is NOT automatically displayed as in
//		the Exoression environment
//to display the results you need to .Dump() the varible
//		holding the data result.
//IMPORTANT!!! .Dumo() is a Linqpad Method. It is not a C# method.
//Within the statement environment one can run ALL the queries 
//		in one execution.
var qsyntaxlist = from arowonacollection in Albums
					select arowonacollection ;
					
qsyntaxlist.Dump();


var msyntaxlist = Albums
   					.Select (a => a)
					.Dump();

//msyntaxlist.Dump();

var QueenAlbums = Albums
					.Where(a => a.Artist.Name.Contains("Queen"))
					.Dump();