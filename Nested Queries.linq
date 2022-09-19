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
	//Nested Queries
	//sometimes reffered as subqueries
	//
	//simply put: it is a query whithin a query [.....]
	
	//List all sales support employees showing their 
	//fullname (last, First), title and phone
	//for each employee name, show a list of customers they support
	// show the customer fullname(last, first), city and State
	
	//employee 1, title, phone
	
	//	customer 2000, city, state
	//	customer 2109, city, state
	//	customer 5000, city, state
	
	//employee 2, title, phone
	
	//	customer 301, city, state
	//	customer 302, city, state
	//	customer 303, city, state
	
	//there appears to be 2 separate lists than need to be 
	//	within one final dataset collection
	// list of employees
	// list of employee customers
	//concern: the list are intermixed!!!!
	
	//C# point of view in a class definition
	//first: this is a composite class
	//	the class is describing an employee
	//	each instance of the employee will have a list of employee
	
	//class EmployeeList
	//	Fullname(property)
	//	Title(property)
	//	phone(property)
	//	collection of customers(property:List<T>)
	
	//class CustomerList
	//	Fullname (Property)
	//	city (property)
	//	state (property)
	var results = Employees
						.Where(a => a.Title.Contains("Sales Support"))
						.Select(a =>
							new EmployeeItem
							{
								FullName = a.LastName + ", " + a.FirstName,
								Title = a.Title,
								Phone = a.Phone,
								CustomerList = a.SupportRepCustomers
															.Select( a => new CustomerItem
															{
																FullName = a.LastName + ", " + a.FirstName,
																City = a.City,
																State = a.State == null ? "Unknown": a.State
															})
								
							}
						);
	results.Dump();
	
	//list all the albums that are from 1990.
	//display the album Title, and artist name
	// for each album, displau its tracks.
	
	var albums = Albums
					.Where(a => a.ReleaseYear == 1990)
					.OrderBy(a => a.Title)
					.Select(a =>
								new 
								{
								
								Title = a.Title,
								Artist = a.Artist.Name,
								Tracks = a.Tracks
												.Select(a => new {
													Songs = a.Name,
													Genre = a.Genre.Name
												})
								
								}
					);
	albums.Dump();
}

// You can define other methods, fields, classes and namespaces here

public class CustomerItem
{
	public string FullName {get; set;}
	public string City {get; set;}
	public string State {get; set;}

}

public class EmployeeItem
{
	public string FullName {get; set;}
	public string Title {get; set;}
	public string Phone {get; set;}
	public IEnumerable<CustomerItem> CustomerList {get;set;}

}