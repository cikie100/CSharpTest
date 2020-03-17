using System;
using System.Data;
using System.Data.SqlClient;

namespace CSharpTest
{
    public class Class1
    {

        string sql = "CREATE DATABASE CSharpTest";
        string sqlCreateContinents = "CREATE TABLE Continents(ContinentName nvarchar(100), CountryId bigint,Population bigint)";
        string sqlCreateJson = "CREATE TABLE ContJson(Info nvarchar(max))";

        string insertSql1 = $"INSERT INTO Continents (ContinentName, CountryId, Population) VALUES (“Europe”, 32, 10400000);";
        string insertSql2 = $"INSERT INTO Continents (ContinentName, CountryId, Population) VALUES (“Europe”, 31, 7180000);";

        string updateSql = $"UPDATE Continents SET Population = 11400000 WHERE CountryId = 32 ";
        //AdoCrudConn
       
        static void Main(string[] args)
        {
            var con = new SqlConnection("Data Source =./SQLEXPRESS;Initial Catalog = master; Integrated Security = True");


            using (con) { 
                DataTable schemaTable;
                SqlDataReader myReader;
                SqlCommand cmd = new SqlCommand();

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Continents WHERE CountryId = 32";
                myReader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
                schemaTable = myReader.GetSchemaTable();

                foreach (DataRow myField in schemaTable.Rows)
                {
                    //For each property of the field...
                    foreach (DataColumn myProperty in schemaTable.Columns)
                    {
                        //Display the field name and value.
                        Console.WriteLine(myProperty.ColumnName + " = " + myField[myProperty].ToString());
                        string insertSql1 = $"INSERT INTO ContJson (Info) VALUES (“Europe”, 32, 10400000);";

                    }
                    Console.WriteLine();

                    //Pause.
                    Console.ReadLine();
                }

                myReader.Close();
                con.Close();

                SqlCommand command = new SqlCommand("DROP TABLE Info", con);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();

            }
            con.Dispose();
        }
    }
}
