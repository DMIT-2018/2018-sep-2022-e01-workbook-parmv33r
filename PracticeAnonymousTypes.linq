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

//List all albums by Release Label. Any Album with no label 
//Should be indicated as UnKnown
//List Title, Label and Artist Name

//understand the problem
//	collection: albums
//	selective data: anonymous dataset
//	label(nullable): either Unknown or Label name


//design
//

Albums
	.Select(
		
		a => new 
	{
		
		Title = a.Title,
		Label = a.ReleaseLabel == null ? "Unknown" : a.ReleaseLabel,
		Artist = a.Artist.Name
		
	})
	.OrderBy(a => a.Label)
	
	
//List all albums showing the title, artist name, year and decade of release
//	using oldies, 70's, 80's, 90's or modern
//Order by decade

Albums
	.Select
	( 
		a => new{
			
			Title = a.Title,
			Artist = a.Artist.Name,
			Year = a.ReleaseYear,
			Decade= a.ReleaseYear < 1970 ? "Oldies":
									a.ReleaseYear < 1980 ? "70's": 
									a.ReleaseYear < 1990 ? "80's" :
									a.ReleaseYear < 1990 ? "90's" : "Modern"
		}
	)
	.OrderBy(a=> a.Year)