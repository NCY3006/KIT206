﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; //for generating a MessageBox upon encountering an error

using MySql.Data.MySqlClient;
using MySql.Data.Types;
using RAP.Research;

namespace RAP.Database
{
    class ERDAdapter
    {
        //If including error reporting within this class (as this sample does) then you'll need a way
        //to control whether the errors are actually shown or silently ignored, since once you have
        //connected the GUI to the Boss object then the GUI designer will execute its code, which
        //will try to connect to the database to load live data into the GUI at design time.
        private static bool reportingErrors = false;

        //These would not be hard coded in the source file normally, but read from the application's settings (and, ideally, with some amount of basic encryption applied)
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        //Part of step 2.3.3 in Week 8 tutorial. This method is a gift to you because .NET's approach to converting strings to enums is so horribly broken
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Creates and returns (but does not open) the connection to the database.
        /// </summary>
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                //Note: This approach is not thread-safe
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        //Fetch details in researcher
        public static List<Researcher> FetchBasicResearcher()
        {
            List<Researcher> researchers = new List<Researcher>();
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select id, type, given_name, family_name, title, unit, campus, email, photo, degree, supervisor_id, level, utas_start, current_start from researcher", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Note that in your assignment you will need to inspect the *type* of the
                    //employee/researcher before deciding which kind of concrete class to create.
                    researchers.Add(new Researcher { ID = rdr.GetInt32(0), GivenName = rdr.GetString(1) + " " + rdr.GetString(2) });
                    
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Connecting to Databse Failure: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            researchers.Sort((rsr1, rsr2) => rsr1.GivenName.CompareTo(rsr2.GivenName));
            return researchers;
        }

        //Fetch publication 
        public static List<Publication> FetchBasicPublication(int id)
        {
            List<Publication> publications = new List<Publication>();
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select title, year, type, available " +
                                                    "from publication as pub, researcher_publication as respub " +
                                                    "where pub.doi=respub.doi and researcher_id=?id", conn);

                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    publications.Add(new Publication
                    {
                        Title = rdr.GetString(0),
                        PublicationYear = rdr.GetInt32(1),
                        Type = ParseEnum<OutputType>(rdr.GetString(2)),
                        Available = rdr.GetDateTime(3)
                    });
                } 
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connecting to Database Failure: "+ e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return publications;
        }

        public static void FetchFullReseacher(Researcher r)
        {
            List<Publication> publications = new List<Publication>();
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select id, givenname, lastname, campus from researcher where id ='" + r.ID + "'", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    r.ID = rdr.GetInt32(0);
                    r.GivenName = rdr.GetString(1);
                    r.LastName = rdr.GetString(2);
                    r.Campus = rdr.GetString(3);
                 
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(" Connecting to Database Failure: " + e);
            }

            finally
            {
                // Close any connections
                if (rdr != null) { rdr.Close(); }
                if (conn != null) { conn.Close(); }


            }
        }

        public static void FetchFullPublication(Publication p)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select authors, type, citeas, available from publication where doi = '" + p.Doi + "'", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    p.Authors = rdr.GetString(0);
                    p.Type = ParseEnum<OutputType>(rdr.GetString(1));
                    p.CiteAs = rdr.GetString(2);
                    p.Available = rdr.GetDateTime(3);
                }
            }

            catch (MySqlException e)
            {
                Console.WriteLine(" Connecting to Database Failure: " + e);
            }

            finally
            {
                // Close any connections
                if (rdr != null) { rdr.Close(); }
                if (conn != null) { conn.Close(); }
            }
        }
    }
}
