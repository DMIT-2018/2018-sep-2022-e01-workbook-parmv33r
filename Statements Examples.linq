<Query Kind="Statements">
  <Connection>
    <ID>79560d8e-44cd-40a1-aebc-3aad61f84d6d</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>localhost</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAcZEve3zq0E2vlF++MRiBogAAAAACAAAAAAADZgAAwAAAABAAAABawN30Ktl9FCEEhynvR+pqAAAAAASAAACgAAAAEAAAANIhDZuh2+RE8XoZ6S7Ry3MQAAAA1TsBddLfogQbjG7FNj5bVBQAAAB1vIyr8PrgenBapQAyutLEvzdUyQ==</Password>
    <Database>Chinook</Database>
  </Connection>
</Query>

//the statement IDE
//This environemnet expects the use of C# statement grammar.
//the results of the query is NOT automatically displayed as in
//		the Exoression environment
//to display the results you need to .Dump() the varible
//		holding the data result.
//IMPORTANT!!! .Dump() is a Linqpad Method. It is not a C# method.
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