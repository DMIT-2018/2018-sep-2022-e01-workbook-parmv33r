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
	//pretend that the Main() is the webpage
	
	
	//find songs by partial song name.
	//display the album title, songs and artist
	//order by song.
	//var songCollection = Tracks
	//
	//				.Where(a => a.Name.Contains("dance"))
	//				.OrderBy(a => a.Name)
	//				.Select(
	//				a =>
	//					new SongList {
	//					
	//					Album = a.Album.Title,
	//					Song = a.Name,
	//					Artist = a.Album.Artist.Name
	//					
	//					});
	
	//assume a value was entered into the webpage
	//assume that a post button was pressed 
	//assume Main() is the post event
	string inputvalue = "dance";
	List<SongList> songCollection = SongsByPartialName(inputvalue);
	songCollection.Dump();
	
}

// You can define other methods, fields, classes and namespaces here

//C# really enjoys strongly typed data fields 
//	whether these fields are primitive data types (int, double,.... etc)
//	or developer defined data types (classes)

public class SongList
{
	public string Album{get;set;}
	public string Song{get;set;}
	public string Artist{get;set;}

}

//imagine the following method exists in service in your BLL

//this method receives the webpage parameter value for the Query
//this method will need to return a collection

List<SongList> SongsByPartialName(string partialSongName){


	var songCollection = Tracks
							.Where(a => a.Name.Contains(partialSongName))
							.OrderBy(a => a.Name)
							.Select(
									a =>
										new SongList {
										
										Album = a.Album.Title,
										Song = a.Name,
										Artist = a.Album.Artist.Name
										
										}
									);
							
	return songCollection.ToList();

}







