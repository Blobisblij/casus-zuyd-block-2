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
        public static string connectionString =
            $"Server=tcp:mierentuin.database.windows.net,1433;Initial Catalog=Mierentuin;Persist Security Info=False;User ID=MierentuinAdmin;Password=Welkom1234567890;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

// Insert en select scripts voor sql 
// om een object te schijven naar sql moet je DALSQL.adddata(object) doen zorg er voor dat de opjecten gevuld zijn voordat je ze schijft
// 
//select gaat met alle van dat type 
//dus als je alle dieren wil doe je DALSQL.GetAllDieren
//als je een geen dieren wil verander je het woord met het ding wat je wel wil
        
        #region Dieren

        public static void Adddata(Dier Dier)

        {
            string query =
                "INSERT INTO Dier (Naam,Typedier,Notitie,Verblijfid) VALUES (@Naam, @DierID,@Notitie,@VerblijfID)";
            
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@Naam", Dier.Naam);
            command.Parameters.AddWithValue("@Typedier", Dier.Typedier);
            command.Parameters.AddWithValue("@Notitie", Dier.Notitie);
            command.Parameters.AddWithValue("@VerblijfID", Dier.VerblijfID);
            
            connection.Open();
            command.ExecuteNonQuery();
        }

        public static List<Dier> GetAllDieren()
        {
            string query = "SELECT * FROM Dier";
            List<Dier> Dierlist = new List<Dier>();

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(query, connection);

            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Dierid = reader.GetInt32(0);
                        int VerblijfID = reader.GetInt32(3);
                        string Naam = reader.GetString(2);
                        string DierType = reader.GetString(1);
                        string Notitie = reader.GetString(4);
                        Dier Dier = new Dier(Dierid, Naam, Notitie, DierType, VerblijfID);
                        Console.WriteLine($"{Dierid} - {DierType} - {Notitie}");
                        Dierlist.Add(Dier);
                    }
                }
            }
            return Dierlist;
        }

        #endregion

        #region Werknemers

        public static void Adddata(Werknemer werknemer)

        {

            string query = "INSERT INTO Werknemer (Naam,Functie) VALUES (@Naam, @Functie)";


            using SqlConnection connection = new SqlConnection(connectionString);

            using SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@Naam", werknemer.Naam);

            command.Parameters.AddWithValue("@Functie", werknemer.Functie);

            connection.Open();

            command.ExecuteNonQuery();

        }

        public static List<Werknemer> GetAllWerknemers()
        {
            string query = "SELECT * FROM Werknemer";
            List<Werknemer> werknemers = new List<Werknemer>();

            using SqlConnection connection = new SqlConnection(connectionString);

            using SqlCommand command = new SqlCommand(query, connection);

            {

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())

                {


                    while (reader.Read())

                    {

                        int WerknemerID = reader.GetInt32(0);

                        string naam = reader.GetString(1);

                        string Functie = reader.GetString(2);

                        Werknemer werknemer = new Werknemer(WerknemerID, naam, Functie);


                        werknemers.Add(werknemer);

                    }

                }

            }


            return werknemers;

        }

        #endregion

        #region Verblijf

        public static void Adddata(Verblijf verblijf)

        {

            string query = "INSERT INTO Verblijf (Naam,Beschrijving) VALUES (@Naam, @Beschrijving)";


            using SqlConnection connection = new SqlConnection(connectionString);

            using SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@Naam", verblijf.Naam);

            command.Parameters.AddWithValue("@Beschrijving", verblijf.Beschrijving);

            connection.Open();

            command.ExecuteNonQuery();

        }

        public static List<Verblijf> GetAllVerblijf()
        {
            string query = "SELECT * FROM Verblijf";
            List<Verblijf> verblijflijst = new List<Verblijf>();

            using SqlConnection connection = new SqlConnection(connectionString);

            using SqlCommand command = new SqlCommand(query, connection);

            {

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())

                {


                    while (reader.Read())

                    {

                        int verblijfID = reader.GetInt32(0);

                        string naam = reader.GetString(1);

                        string beschrijving = reader.GetString(2);

                        bool poortopten = reader.GetBoolean(3);
                        
                        Verblijf verblijf = new Verblijf(verblijfID, naam, beschrijving, poortopten);
                        
                        verblijflijst.Add(verblijf);
                        
                    }
                }
            }
            return verblijflijst;
        }
        #endregion

        #region voerbeurt

        public static void Adddata(VoerBeurt voerbeurt)

        {

            string query =
                "INSERT INTO VoerBeurt (Typevoer,HoeveelheidVoer,Tijdstip,VerblijfID,Voltooid) VALUES (@Typevoer,@HoeveelheidVoer,@Tijdstip,@VerblijfID,@Voltooid)";


            using SqlConnection connection = new SqlConnection(connectionString);

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Naam", voerbeurt.Typevoer);

            command.Parameters.AddWithValue("@Beschrijving", voerbeurt.Hoeveelheidvoer);

            command.Parameters.AddWithValue("@Tijdstip", voerbeurt.Tijdstip);

            command.Parameters.AddWithValue("VerblijfID", voerbeurt.Verblijf.Verblijfid);

            command.Parameters.AddWithValue("Tijdstip", voerbeurt.Tijdstip);

            command.Parameters.AddWithValue("Voltooid", voerbeurt.Voltooid);
            
            connection.Open();

            command.ExecuteNonQuery();
        }

        public static List<VoerBeurt> GetAllVoerbeurt()
        {
            string query = "SELECT * FROM VoerBeurt";
            List<VoerBeurt> Voerbeurten = new List<VoerBeurt>();

            using SqlConnection connection = new SqlConnection(connectionString);

            using SqlCommand command = new SqlCommand(query, connection);

            {

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())

                {


                    while (reader.Read())

                    {

                        int VerblijfID = reader.GetInt32(4);
                        
                        int VoerBeurtID = reader.GetInt32(0);
                        
                        string Typevoer = reader.GetString(1);

                        Decimal HoeveelheidVoer = reader.GetDecimal(2);

                        DateTime Tijdstip = reader.GetDateTime(3);

                        bool Voltooid = reader.GetBoolean(5);
                        Console.WriteLine("tot hier");
                        VoerBeurt Voerbeurt = new VoerBeurt(VoerBeurtID,Typevoer, Tijdstip, HoeveelheidVoer, Voltooid,VoerBeurtID);



                        Voerbeurten.Add(Voerbeurt);

                    }

                }

            }
            return Voerbeurten;
        }

        #endregion

        #region VoerBeurtWerknemer

        public static void Adddata(VoerBeurtWerknemer voerBeurtWerknemer)
        {

            string query =
                "INSERT INTO VoerBeurtWerknemer (VoerbeurtID,WerknemerID) VALUES (@VoerBeurtID, @WerknemerID)";
            
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@VoerBeurtID", voerBeurtWerknemer.VoerBeurtID);
            command.Parameters.AddWithValue("@WerknemerID", voerBeurtWerknemer.WerknemerID);

            connection.Open();
            command.ExecuteNonQuery();

        }

        public static List<VoerBeurtWerknemer> GetAllVoerbeurtWerknemer()
        {
            string query = "SELECT * FROM VoerBeurtWerknemer";
            List<VoerBeurtWerknemer> voerBeurtWerknemers = new List<VoerBeurtWerknemer>();

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(query, connection);

            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int VoerBeurtID = reader.GetInt32(0);
                        int WerknemerID = reader.GetInt32(1);
                        
                        VoerBeurtWerknemer voerBeurtWerknemer = new VoerBeurtWerknemer(VoerBeurtID, WerknemerID);
                        
                        voerBeurtWerknemers.Add(voerBeurtWerknemer);

                    }

                }

            }
            return voerBeurtWerknemers;
        }
        #endregion

        #region SchoonmaakWerknemer
        public static void Adddata(SchoonmaakWerknemer schoonmaakWerknemer)
        {
            string query =
                "INSERT INTO SchoonmaakWerknemer (SchoonmaakbeurtID,WerknemerID) VALUES (@SchoonmaakBeurtID, @WerknemerID)";
            
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@VoerBeurtID", schoonmaakWerknemer.SchoonmaakBeurtID);
            command.Parameters.AddWithValue("@WerknemerID", schoonmaakWerknemer.WerknemerID);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public static List<SchoonmaakWerknemer> GetAllSchoonmaakWerknemer()
        {
            string query = "SELECT * FROM SchoonmaakWerknemer";
            List<SchoonmaakWerknemer> schoonmaakWerknemers = new List<SchoonmaakWerknemer>();

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(query, connection);
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int SchoonmaakbeurtID = reader.GetInt32(0);
                        int WerknemerID = reader.GetInt32(1);

                        SchoonmaakWerknemer schoonmaakWerknemer = new SchoonmaakWerknemer(SchoonmaakbeurtID, WerknemerID);
                        
                        schoonmaakWerknemers.Add(schoonmaakWerknemer);
                    }
                }
            }
            return schoonmaakWerknemers;
        }
        #endregion

        #region Schoonmaakbeurt

        public static void Adddata(SchoonMaakBeurt schoonmaakbeurt)

        {

            string query =
                "INSERT INTO SchoonMaakBeurt (schoonmaakID,tijdstip,verblijfID,voltooid) VALUES (@Naam, @DierID,@Notitie,@VerblijfID)";


            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@schoonmaakID", schoonmaakbeurt.SchoonmaakBeurtID);
            command.Parameters.AddWithValue("@tijdstip", schoonmaakbeurt.Tijdstip);
            command.Parameters.AddWithValue("@verblijfID", schoonmaakbeurt.Verblijf.Verblijfid);
            command.Parameters.AddWithValue("@voltooid", schoonmaakbeurt.Voltooid);
            
            connection.Open();
            command.ExecuteNonQuery();
        }
        public static List<SchoonMaakBeurt> GetAllSchoonMaakBeurt()
        {
            string query = "SELECT * FROM SchoonMaakBeurt";
            List<SchoonMaakBeurt> SchoonMaakBeurten = new List<SchoonMaakBeurt>();

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(query, connection);
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int SchoonmaakBeurtID = reader.GetInt32(0);
                        int VerblijfID = reader.GetInt32(2);
                        DateTime Tijdstip = reader.GetDateTime(1);
                        bool Voltooid = reader.GetBoolean(3);
                        
                        SchoonMaakBeurt schoonmaakbeurt = new SchoonMaakBeurt(SchoonmaakBeurtID, Tijdstip,  Voltooid,VerblijfID);
                        SchoonMaakBeurten.Add(schoonmaakbeurt);
                    }
                }
            }
            return SchoonMaakBeurten;
        }
        #endregion
    }
}
        

