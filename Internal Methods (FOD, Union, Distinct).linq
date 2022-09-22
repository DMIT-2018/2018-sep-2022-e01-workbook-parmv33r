<Query Kind="Program">
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

void Main()
{
	//Conversions
	//Collections we will look at Iqueryable, IEnumerable and List
	
	//Display all albums and their tracks. Display the album title
	//artist name and album tracks. For each track show the song name
	// and play time. Show only albums with 25 or more tracks.
	
	List<AlbumTracks> albumlist = Albums
						.Where(a => a.Tracks.Count >= 25)
						.Select(a => new AlbumTracks
						{
							Title = a.Title,
							Artist = a.Artist.Name,
							Songs = a.Tracks
										.Select(tr => new SongItem
										{
											Song = tr.Name,
											Playtime = tr.Milliseconds / 1000.0
										}).ToList()
						}).ToList()
						//.Dump()
						;
						
		//Using .FirstOrDefault()
		//first saw in CPSC1517 when check to see if a record existed in a BLL service method
		
		//Find the first album by Deep Purple
		
		var artistParam = "Deep purple";
		var resultsFOD = Albums
							.Where(a => a.Artist.Name.Equals(artistParam))
							.Select(a => a)
							.OrderBy(a => a.ReleaseYear)
							.FirstOrDefault()
							//.Dump()
							;
							
							//if(resultsFOD != null)
							//{
							//	resultsFOD.Dump();
							//}
							//
							//else
							//{
							// Console.WriteLine($"No albums found for artist {artistParam}");
							//}
							
							//Distinct()
							//remove duplicate reported  lines
							
							//get a list of customer countries 
							var resultsDistinct = Customers
														.OrderBy(c => c.Country)
														.Select(c => c.Country)
														.Distinct()
														//.Dump()
														;
														
							//.Take() and .Skip()
							//in CPSC1517, when you want to your supplied Paginator
							//	the query method was to return ONLY need 
							//	records for display NOT the entire collection
							//	a) the query was executed returning a collection of size x
							//	b) obtained the total count (x) of return records
							//	c) calculated the number of records to skip (pagenumber - 1) * pagesize
							//	d) on the return method statement you used
							//		return variablename.Skip(rowSkipped).Take(pagesize).ToList()
							
							
							//Union
							//rules in Linq are the same as SQL
							//result is the same as sql, combine separate collections into one.
							//syytax of (queryA).Union(queryB)[.Union(query....)]
							//rules:
							//	number of columns the same
							//	column datatypes must be the same
							//	ordering should be done as a method after the last Union
							
							var resultsUnionA = ( Albums
												.Where(x => x.Tracks.Count() > 0)
												.Select(x => new
												{
													title = x.Title,
													totalTracks = 0,
													totalCost = 0.00m,
													averageLength = 0.00d
												})
												)
												//.Dump()
										.Union(Albums
												.Where(x => x.Tracks.Count() > 0)
												.Select(x => new
												{
													title = x.Title,
													totalTracks = x.Tracks.Count(),
													totalCost = x.Tracks.Sum(tr => tr.UnitPrice),
													averageLength = x.Tracks.Average(tr => tr.Milliseconds)
												})
												)
												.OrderBy(x=> x.totalTracks)
												.Dump()
												;
}

// You can define other methods, fields, classes and namespaces here

public class SongItem
{
	public string Song{get; set;}
	public double Playtime{get; set;}
	
}

public class AlbumTracks
{
	public string Title{get;set;}
	public string Artist{get;set;}
	public List<SongItem> Songs{get;set;}
}