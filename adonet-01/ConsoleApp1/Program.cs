// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using Microsoft.Data.SqlClient;

Console.WriteLine("Starwars ADO.NET!");


//1 Connection
var conn = new SqlConnection("Server=.;Database=Starwars;Integrated Security=true;TrustServerCertificate=True;");


//2 Command
var querySql = "SELECT J.[Name], J.JediId FROM dbo.Jedi J  WHERE J.Name LIKE '%66%'";

//var command = new SqlCommand(querySql, conn);
var command = new SqlCommand();
command.Connection = conn;
command.CommandText = querySql;
command.CommandType = System.Data.CommandType.Text;
//command.Parameters.Add|new SqlParameter("@JediId", System.Data.SqlDbType.Int)).Value = 1;




Console.WriteLine("conn.Open()!");
conn.Open();

//3 DataReader
var reader = command.ExecuteReader();

var jedis = new List<Jedi>();

while (reader.Read()) {

    //var name1 = reader["Name"];
    //var name2 = reader["Name"].ToString();
    //var name3 = reader.GetString(1);
    //var name4 = reader.GetString(reader.GetOrdinal("Name"))

    var jediId = reader.GetInt32(reader.GetOrdinal("JediId"));
    var name = reader.GetString(reader.GetOrdinal("Name"));

    //  Console.WriteLine($"JediId: {jediId}, Name: {name}");

    var jedi = new Jedi() {
        JediId = jediId,
        Name = name
    };

    jedis.Add(jedi);


}


Console.WriteLine("conn.Close()!");
conn.Close();


Console.WriteLine($"Jedis counter: {jedis.Count}");



Console.WriteLine("Starwars EntityFramework!");

using (var starwarsDbContext = new StarwarsDbContext())
{

    //var jedis2 = starwarsDbContext.Jedis.ToList();
    var jedis2 = from j in starwarsDbContext.Jedis
                 where j.Name.Contains("66")
                 select j;

    Console.WriteLine($"Jedis counter (EF): {jedis2.Count()}");
}



