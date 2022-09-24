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

//Problem
//ONe needs to have processed information from a collection
//	to use agianst the same collection

//Solution to this type of problem is to use multiple queries
//	the early queries will produced the needed information/crateria
//	to exexute against the same collection later queries
//basically we need to do some pre-processing

//query one will generate data/information that will e used in the 
// next query

//Display the employees that have the most customers to support.
//Display the employee name and number of customers that employee supports.

//what is NOT want is a list of all employees sorted by number of customer supported.

//One could create a list of all employees, with customer support count, ordered
//	decsending by support count. BUT, this is NOT was is request


//What information do I need
// a) I need to know the maximum number of customers that an particular employee is supporting 
// b) I need to take that peice of data and compare to all emplyees


//a) get a list of employees and the count of the customers each supports
//b) from that list I can obtain the largest number 
//c) Using the number, review all the employees and their counts reporting ONLY the bussiest
//		employees

var PreprocessEmployeelist = Employees
									.Select(a => new
										{
											Name = a.FirstName + ", " + a.LastName,
											CustomerCount = a.SupportRepCustomers.Count()
										})
									//.Dump()
									;
									
var highcount = PreprocessEmployeelist
					.Max(a => a.CustomerCount)
					//.Dump()
					;
					
var BusyEmployees = PreprocessEmployeelist
						.Where(a => a.CustomerCount ==  highcount)
						.Dump();