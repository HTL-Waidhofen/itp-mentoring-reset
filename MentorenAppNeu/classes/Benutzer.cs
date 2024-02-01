using Mentoren_App;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using static System.Net.WebRequestMethods;


public class Benutzer : DbConnection
{
    public int ID { get; }
    public string Vorname { get; }
    public string Nachname { get; }
    public string Role { get; set; }
    public string Email { get; set; }
    private string Passwort { get; set; }

    private List<Benutzer> schuelerListe;
    private List<Benutzer> mentorListe;

    public override string ToString()
    {
        return Vorname + " " + Nachname + ", Email: " + Email;
    }

    public Benutzer(int id, string vorname, string nachname, string role, string email, string passwort) : base()
    {
        this.ID = id;
        this.Vorname = vorname;
        this.Nachname = nachname;
        this.Role = role;
        this.Email = email;
        this.Passwort = passwort;
        //this.schuelerListe = GetAllSchueler();
        //this.mentorListe = GetAllMentoren();

        this.ConnectionString = base.ConnectionString;
    }
    /*
    public void AktualisiereBenutzerListe()
    {
        schuelerListe = GetAllSchueler();

        mentorListe = GetAllMentoren();
    }

    public void AktualisiereBenutzerListeBeiDatenbankAenderung()
    {
        List<Benutzer> aktualisierteSchuelerListe = GetAllSchueler();
        List<Benutzer> aktualisierteMentorListe = GetAllMentoren();

        if (!IstGleich(schuelerListe, aktualisierteSchuelerListe))
        {
            schuelerListe = aktualisierteSchuelerListe;
        }

        if (!IstGleich(mentorListe, aktualisierteMentorListe))
        {
            mentorListe = aktualisierteMentorListe;
        }
    }

    private List<Benutzer> GetAllMentoren()
    {
        {
            List<Benutzer> result = new List<Benutzer>();
            string query = "SELECT * FROM Benutzer WHERE Role = 'Mentor'";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string vorname = Convert.ToString(reader["Vorname"]);
                            string nachname = Convert.ToString(reader["Nachname"]);
                            string role = Convert.ToString(reader["Role"]);
                            string email = Convert.ToString(reader["Email"]);
                            string passwort = Convert.ToString(reader["Passwort"]);

                            result.Add(new Benutzer(id, vorname, nachname, role, email, passwort));
                        }
                    }
                }
            }

            return result;
        }
    }
    private List<Benutzer> GetAllSchueler()
    {
        {
            List<Benutzer> result = new List<Benutzer>();
            string query = "SELECT * FROM Benutzer WHERE Rolle = 'Schüler'";
            using (
                SqlConnection connection = new SqlConnection(@"C:\Users\Silke\Documents\Schule\Ittp\Mentoren\Mentoren - App\Datenbank\Mentor.db"))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string vorname = Convert.ToString(reader["Vorname"]);
                            string nachname = Convert.ToString(reader["Nachname"]);
                            string role = Convert.ToString(reader["Role"]);
                            string email = Convert.ToString(reader["Email"]);
                            string passwort = Convert.ToString(reader["Passwort"]);

                            result.Add(new Benutzer(id, vorname, nachname, role, email, passwort));
                        }
                    }
                }
            }
            return result;
        }
    }
    private bool IstGleich(List<Benutzer> listeA, List<Benutzer> listeB)
    {
        // Überprüfe, ob beide Listen die gleichen Elemente in der gleichen Reihenfolge enthalten
        return listeA.Count == listeB.Count && Enumerable.SequenceEqual(listeA, listeB);
    }


    public static void CreateBenutzer(string vorname, string nachname, string rolle, string email, string passwort, string ConnectionString)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "INSERT INTO Benutzer (Vorname, Nachname, Rolle, Email, Passwort) VALUES (@Vorname, @Nachname, @Rolle, @Email, @Passwort)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Vorname", vorname);
                cmd.Parameters.AddWithValue("@Nachname", nachname);
                cmd.Parameters.AddWithValue("@Rolle", rolle);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Passwort", passwort);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static Benutzer ReadBenutzerByID(int id, string ConnectionString)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Benutzer WHERE ID = @ID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Benutzer(
                            Convert.ToInt32(reader["ID"]),
                            Convert.ToString(reader["Vorname"]),
                            Convert.ToString(reader["Nachname"]),
                            Convert.ToString(reader["Rolle"]),
                            Convert.ToString(reader["Email"]),
                            Convert.ToString(reader["Passwort"])
                        );
                    }
                }
            }
        }
        return null;
    }

    public void UpdateBenutzerEmail(string neueEmail, string ConnectionString)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "UPDATE Benutzer SET Email = @NeueEmail WHERE ID = @ID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NeueEmail", neueEmail);
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteBenutzer(string ConnectionString)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "DELETE FROM Benutzer WHERE ID = @ID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.ExecuteNonQuery();
            }
        }
    }
    public static List<Benutzer> GetAllSchueler(string ConnectionString)
    {
        List<Benutzer> result = new List<Benutzer>();
        string query = "SELECT * FROM Benutzer WHERE Rolle = 'Schüler'";

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        string vorname = Convert.ToString(reader["Vorname"]);
                        string nachname = Convert.ToString(reader["Nachname"]);
                        string role = Convert.ToString(reader["Role"]);
                        string email = Convert.ToString(reader["Email"]);
                        string passwort = Convert.ToString(reader["Passwort"]);

                        result.Add(new Benutzer(id, vorname, nachname, role, email, passwort));
                    }
                }
            }
        }

        return result;
    }

    public static List<Benutzer> GetAllMentoren(string ConnectionString)
    {
        List<Benutzer> result = new List<Benutzer>();
        string query = "SELECT * FROM Benutzer WHERE Role = 'Mentor'";

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        string vorname = Convert.ToString(reader["Vorname"]);
                        string nachname = Convert.ToString(reader["Nachname"]);
                        string role = Convert.ToString(reader["Role"]);
                        string email = Convert.ToString(reader["Email"]);
                        string passwort = Convert.ToString(reader["Passwort"]);

                        result.Add(new Benutzer(id, vorname, nachname, role, email, passwort));
                    }
                }
            }
        }

        return result;
    }*/

    public string ListBoxFormat()
    {
        return ID.ToString() + " | " + Vorname + " " + Nachname;
    }

    public bool isLoginDataCorrect(string email, string passwort)
    {
        if (email == Email && passwort == Passwort)
            return true;
        return false;
    }


}
