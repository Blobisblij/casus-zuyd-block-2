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
        private static string webserver = ".";

        private static string database = "Mierentuin";

        public static string connectionString =
            $"Server={webserver};Database={database};Trusted_Connection=True;TrustServerCertificate=True;";


        #region Dieren

        public static void Adddata(Dier Dier)

        {

            string query =
                "INSERT INTO Dieren (Naam,Typedier,Notitie,Verblijfid) VALUES (@Naam, @DierID,@Notitie,@VerblijfID)";


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
            string query = "SELECT * FROM Dieren";
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

                        int VerblijfID = reader.GetInt32(0);

                        string naam = reader.GetString(0);

                        string DierType = reader.GetString(0);

                        string Notitie = reader.GetString(0);


                        Dier Dier = new Dier(Dierid, naam, Notitie, DierType, VerblijfID);


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

            string query = "INSERT INTO Werknemers (Naam,Functie) VALUES (@Naam, @Functie)";


            using SqlConnection connection = new SqlConnection(connectionString);

            using SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@Naam", werknemer.Naam);

            command.Parameters.AddWithValue("@Functie", werknemer.Functie);

            connection.Open();

            command.ExecuteNonQuery();

        }

        public static List<Werknemer> GetAllWerknemers()
        {
            string query = "SELECT * FROM Werknemers";
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

                        string naam = reader.GetString(0);

                        string Functie = reader.GetString(0);

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

                        string naam = reader.GetString(0);

                        string beschrijving = reader.GetString(0);

                        bool poortopten = reader.GetBoolean(1);

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

                        int VerblijfID = reader.GetInt32(0);
                        
                        int VoerBeurtID = reader.GetInt32(0);
                        
                        string Typevoer = reader.GetString(0);

                        int HoeveelheidVoer = reader.GetInt32(0);

                        DateTime Tijdstip = reader.GetDateTime(0);

                        bool Voltooid = reader.GetBoolean(0);

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
                        int WerknemerID = reader.GetInt32(0);

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
                        int WerknemerID = reader.GetInt32(0);

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
            string query = "SELECT * FROM SchoonmaakBeurt";
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

                        int VerblijfID = reader.GetInt32(0);

                        DateTime Tijdstip = reader.GetDateTime(0);

                        bool Voltooid = reader.GetBoolean(0);




                        SchoonMaakBeurt schoonmaakbeurt =
                            new SchoonMaakBeurt(SchoonmaakBeurtID, Tijdstip,  Voltooid,VerblijfID);


                        SchoonMaakBeurten.Add(schoonmaakbeurt);

                    }

                }

            }


            return SchoonMaakBeurten;

        }

        #endregion
    }
}
        

