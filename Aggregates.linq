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

//Aggregates
//.Count() counts the number of instances in the collection
//.Sum() - Sums (Total) a numeric field (Numeric experession)
//.Min() - finds the minimum value of a collection for a field
//.Max() - finds the maximum value of a collection for a field.
//.Average() - finds the average of numveric field

//IMPORTANT!!!
//Aggregates work ONLY on a collection of values
//Aggregates DO NOT work on a single instance (non declare collection)

//.Sum(), .Min(), .Max() and .Average() must have at least one record  in their collection
//.Sum and .Average MUST work on numveric fields and the fields CANNOT be null.

//sytax: method 

//collectionset.aggregate(a => expression)
//collectionset.Select(...).Aggregate()
//collection.Count() //.Count() does not contain an expression.

//for Sum, Min, Max and Average: the result is a single value 

//you can use multiple aggregates on a single column
//	.Sum(a => expression).Min(a => expression)

//Find the average playing time (length) of tracks in our music collection

//thought process
//average is an aggregate
//average needs a collection? the tracks table is a collection
//what is the expression? Milliseconds

Tracks.Average(a => a.Milliseconds)

Tracks.Select(a => a.Milliseconds).Average()


//list all albums of the 60's showing the title artist and various
//aggregates for albums containing tracks

//for each album show the number of tracks, the total price of
//	all tracks and the average playing length of the album tracks

//thought process
//start at Albums
//Can I get the artist name (.Artist)
//can I get a collection of tracks for an album(a.tracks)
//can i get the number of tracks in the collection (.Count())
//cam I get the total price the tracks (.Sum())
//can I get the average of the play length (.Average())

Albums
	.Where(a => a.Tracks.Count() > 0 && (a.ReleaseYear >1959 && a.ReleaseYear < 1970))
	.Select(a => new 
	{
		Title = a.Title,
		Artist = a.Artist.Name,
		NumberofTracks = a.Tracks.Count(),
		Price = a.Tracks.Sum(tr => tr.UnitPrice),
		AverageTrackLength = a.Tracks.Average(tr => tr.Milliseconds)
	
	})