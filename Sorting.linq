<Query Kind="Expression">
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

//Sorting 

//There is significant difference between query syntax
//	and method syntax

//Query syntax is much like SQL
// 	orderby (it does not have a space in LINQ and SQL there is a space in between)
//	orderby field {[ascending]|descending} [,field ....]

// ascending is the default option


//method syntax is a series of individual methods
// .OrderBy(x => x.field)
// .OrderByDescending( x => x.field) first field ONLY
// .ThenBy(x => x.field)
// .ThenByDescending(x => x.field)

//Find all of the album tracks for the band Queen. Order 
//	the track by the trackname alphabatically

//Query Syntax

from x in Tracks
where x.Album.Artist.Name.Contains("Queen")
orderby x.AlbumId, x.Name
select x

//Method syntax

Tracks
	.Where(x => x.Album.Artist.Name.Contains("Queen"))
	.OrderBy(x => x.Album.Title)
	.ThenBy(x => x.Name)

//Order of sorting can be interchanged
Tracks
	.OrderBy(x => x.Album.Title)
	.ThenBy(x => x.Name)
	.Where(x => x.Album.Artist.Name.Contains("Queen"))
	

