using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Libraries for database access
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.ComponentModel.Design;

namespace YhteysTietokantaan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a connection to SQL Server using Windows authentication
            using (SqlConnection conn = new SqlConnection("Data Source=ek3-a253-04\\SQLEXPRESS;Initial Catalog=Henkilosto;Integrated Security=True"))
            // Open the connection and see status
            {
                conn.Open();
                Console.WriteLine(conn.State);
                Console.WriteLine("Yhteyteen vastaa SQL Server versio " + conn.ServerVersion);

                // Create a sql command to inser new employee to Tyontekija table
                string insertEmployee = "INSERT INTO dbo.Tyontekija (Etunimi, Sukunimi) VALUES ('Kim', 'Moronen');";

                // Send command to connection
                SqlCommand cmd = new SqlCommand(insertEmployee, conn);

                // Execute command which does not return a result set
                cmd.ExecuteNonQuery();

                // Close the connection
                conn.Close();

            }
            // Create an other connection to the Db
            using (SqlConnection conn2 = new SqlConnection("Data Source=ek3-a253-04\\SQLEXPRESS;Initial Catalog=Henkilosto;Integrated Security=True"))
            {
                conn2.Open();

                // Create a sql command to update Calles commune in table
                string updateEmplyeeCommune = "UPDATE dbo.Tyontekija SET Postitoimipaikka = 'Raisio' WHERE TyontekijaID = 1011;";
                SqlCommand cmd2 = new SqlCommand(updateEmplyeeCommune, conn2);
                cmd2.ExecuteNonQuery();
                conn2.Close();
            }

            using (SqlConnection conn3 = new SqlConnection("Data Source=ek3-a253-04\\SQLEXPRESS;Initial Catalog=Henkilosto;Integrated Security=True"))
            {
                conn3.Open();

                // Create SQL query to retrieve all rows from Tyontekija table
                string queryAllEmployees = "SELECT Etunimi, Sukunimi FROM dbo.Tyontekija;";
                SqlCommand cmd3 = new SqlCommand(queryAllEmployees, conn3);

                // To avoid eternal loop use timeout
                cmd3.CommandTimeout = 20;

                // Use reader to handle result set
                SqlDataReader reader = cmd3.ExecuteReader();

                // Print data to screen while reader gets more rows
                while (reader.Read())
                {
                    // Format output with tabs
                    Console.WriteLine("{0}\t{1}", reader.GetString(0), reader.GetString(1));
                }
                conn3.Close();
            }
            using (SqlConnection conn4 = new SqlConnection("Data Source=ek3-a253-04\\SQLEXPRESS;Initial Catalog=Henkilosto;Integrated Security=True"))
            {
                conn4.Open();
                string deleteEmployee = "DELETE FROM dbo.Tyontekija WHERE TyontekijaID IN (1012);";
                SqlCommand cmd4 = new SqlCommand(deleteEmployee, conn4);
                cmd4.ExecuteNonQuery();
                conn4.Close();
            }


                Console.ReadLine();
        }
    }
}