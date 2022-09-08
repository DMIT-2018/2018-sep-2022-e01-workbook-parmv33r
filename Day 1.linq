<Query Kind="Expression">
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

Albums


//Query Syntax to list all records in an entity (table, collection)
from arowonacollection in Albums
select arowonacollection 

//method sytax to list all records in an entity

Albums
   .Select (a => a)
   
//Where 
//filter method
//the conditios are setup as you would in C#
//beware that Linqpad may NOT like some C# sytax (DateTime)
//beware that Linq is converted to Sql which may not
//	like certain c# sytax because Sql count not convert


//sytax
//notice that the method syntax makes use of Lambda expressions
//Lambdas are common when performing Linq with the method syntax
//.Where(lambda experession)
//.Where(x => consition [logical operators condition2 ])
//.Where(x => x.Bytes > 350000)
//Albums
//	.Where(a => a.AlbumId == 1)

Tracks
	.Where(x => x.Bytes > 700000000)
	
from x in Tracks
where x.Bytes > 700000000
select x

//Find all the albums of the artist Queen.
//concerns: the artist name is in another table
				//in an SQL Select you would be using an inner join
				//in LINQ you DO NOT need to specify your inner join
				//instead use the navigational properties of your entity
				// to generate the relationship.

Albums
	.Where(a => a.Artist.Name.Contains("Queen"))
