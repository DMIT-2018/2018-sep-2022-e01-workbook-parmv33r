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

//navigational properties and Anonymous data set (collection)

//reference: Student Notes/Demo/eRestaurant/Linq: Query and Method Syntax

//Find all albums released in the 90's (1990-1999)
//Order the Albums by assecending year and then  alphabetically by album title
//Display the YEAR, TITLE, ARTIST Name and Release Label

//Concerns: a) not all properties of Album are to be displayed
//			b) the order of the properties are to be displayed
//				in a different sequence then the definition of the
//				properties on the entity Album
//			c) the artist name is NOT on the Album table BUT is on
//				the Artist table

//Solution: use an anonymous data collection

//the anonymous data instance is defined within the select by
//		declare fields (Properties)
//the order of the fields on the new defined instance will be
//		done in specifying the properties of the anonymous data collection

Albums
	.Where(a => a.ReleaseYear >= 1990 && a.ReleaseYear <= 1999)
	//.OrderBy(a => a.ReleaseYear)
	//.ThenBy(a => a.Title)
	.Select (
		a =>
			new
			{
				Year = a.ReleaseYear,
				Title = a.Title,
				ArtistName = a.Artist.Name,
				ReleaseLabel = a.ReleaseLabel
			})
		.OrderBy(a => a.Year) //Year is in the anonymous data type definition, RealeaseYear is NOT
		.ThenBy(a => a.Title)	
			