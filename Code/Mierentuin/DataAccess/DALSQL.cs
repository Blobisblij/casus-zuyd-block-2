using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using casus.Mierentuin;
using casus.Mierentuin.Models;

namespace casus.Mierentuin.DataAccess
{
    public class DALSQL

    {

        private string webserver;

        private string database;

        private readonly string connectionString;



        public DALSQL()

        {

            webserver = ".";

            database = "Mierentuin";

            connectionString = $"Server={webserver};Database={database};Trusted_Connection=True;TrustServerCertificate=True;";

        }

        // voor elk object wat naar de database geschreven kan worden moet er een van deze methodes gemaakt worden

        /*        public void Add{objectnaam}(Class naam)

            {

             string query = "INSERT INTO [tabel naam] (waarde, waarde) VALUES (@colom, @colom)";


             using SqlConnection connection = new SqlConnection(connectionString);

             using SqlCommand command = new SqlCommand(query, connection);


             command.Parameters.AddWithValue("@colom", naam.waarde);

             command.Parameters.AddWithValue("@colom", naam.waarde);


             connection.Open();

             command.ExecuteNonQuery();

             }

        ook moet er in de class van het object wat je naar de database wil stuuren deze methode nodig

        public void CreateClassNaamData()

        {

            DALSQL dalSql = new DALSQL();

            dalSql.AddClassNaam(this);

        }

                */
        public void AddDier(Dieren Dier)

    {

     string query = "INSERT INTO Dieren (Naam, DierID) VALUES (@Naam, @DierID)";


     using SqlConnection connection = new SqlConnection(connectionString);

     using SqlCommand command = new SqlCommand(query, connection);


     command.Parameters.AddWithValue("@Naam", Dier.Naam);

     command.Parameters.AddWithValue("@DierID", Dier.DierID);


     connection.Open();

     command.ExecuteNonQuery();

    }

        /*
         Select code Moet ook per class aangepast worden
          
         public List<ClassNaam> GetAllClassNaam()

    {

        string query = "SELECT colom, colom, colom FROM Tabel";

        List<ClassNaam> naam = new List<ClassNaam>();


        using (SqlConnection connection = new SqlConnection(connectionString))

        using (SqlCommand command = new SqlCommand(query, connectionString))

        {

            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())

            {

                while (reader.Read())

                {

                    DataType Tabel = reader.GetInt32(0);

                    DataType Tabel = reader.GetString(1);

                    DataType Tabel = reader.GetDecimal(2);


                    var naam = new ClassNaam(Tabel, Tabel);


                    listnaam.Add(naam);

                }

            }

        }


        return listnaam;

    }
        
         ook moet er in de class zelf dit als methode toegevoegd worden

            public List<ClassNaam> GetAllClassNaam()

    {

        //Maak hier de bijbehorende logica om via de DALSQL alle producten op te halen.

    }
         */
    }
}
