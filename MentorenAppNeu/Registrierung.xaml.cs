using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MentorenAppNeu
{
    /// <summary>
    /// Interaktionslogik für Registrierung.xaml
    /// </summary>
    public partial class Registrierung : Page
    {
        public Registrierung()
        {
            InitializeComponent();
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.HideMenuItems();
            }
        }

        private void RegistrateUser(object sender, RoutedEventArgs e)
        {
            //Registrierungsfunktion
            if (AreFieldsFilled() == false)
            {
            }
            else if (IsValidEmail(Mail.Text.ToString()) == false)
                MessageBox.Show("Ihre Email hat ein falsches Format. Bitte überprüfen sie ihre Eingabe", "Fehler bei Email", MessageBoxButton.OK);
            else if (PwAreEqual() == false)
                MessageBox.Show("Die Passwörter stimmen nich überein", "Felher bei Passwort", MessageBoxButton.OK);
            else if (PwMeetReq() == false)
                MessageBox.Show("Ihr Passwort entspiricht nicht dem richtigen Format \n (min. 1 Großbuchstabe, Zahl und zwischen 8-20 Zeichen lang)", "Felher bei Passwort", MessageBoxButton.OK);
            else
            {
                //Crud Funktion für Benutzer erstellen
                MessageBox.Show("Registrierung wurde verarbeitet. Sie können sich nun einloggen.", "Registrierung", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService?.Navigate(new Uri("Login.xaml", UriKind.Relative));
            }
        }
        public bool IsValidEmail(string email)
        {

            string pat = "(@htlwy.at){1}$";
            Regex mailPat = new Regex(pat);
            MatchCollection matchCollection = mailPat.Matches(email);
            if (matchCollection.Count == 1)
            {
                return true;
            }
            else
                return false;
        }

        public bool AreFieldsFilled()
        {
            List<Control> fields = new List<Control>();
            fields.Add(VName);
            fields.Add(NName);
            fields.Add(Mail);

            List<PasswordBox> pwds = new List<PasswordBox>();
            pwds.Add(pwd);
            pwds.Add(pwdBestaetigt);


            bool isFilled = true;
            SolidColorBrush brightRedBrush = new SolidColorBrush(Colors.Red);
            SolidColorBrush whiteBrush = new SolidColorBrush(Colors.White);

            foreach (TextBox field in fields)
            {
                if (string.IsNullOrWhiteSpace(field.Text))
                {
                    field.Background = brightRedBrush;
                    isFilled = false;

                }
                else
                {
                    field.Background = whiteBrush;
                }
            }
            foreach (PasswordBox pw in pwds)
            {
                if (string.IsNullOrEmpty(pw.Password))
                {
                    pw.Background = brightRedBrush;
                    isFilled = false;

                }
                else
                {
                    pw.Background = whiteBrush;
                }
            }
            if (student.IsChecked == false && mentor.IsChecked == false)
            {
                isFilled = false;
            }
            else
            {
                isFilled = true;
            }
            if (isFilled == false)
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus", "Felder ausfüllen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Schüler Mentor
            return isFilled;
        }

        public bool IsNameCorrect()
        {
            string[] names = Mail.Text.Split('@');

            string[] seperatedNames = names[0].Split(".");

            if (VName.Text == seperatedNames[0] && NName.Text == seperatedNames[1])
                return true;

            MessageBox.Show("Ihr Vor- und Nachname soll gleich denen in der Email sein", "Inkorrekter Name", MessageBoxButton.OK, MessageBoxImage.Information);
            return false;
        }
        public bool PwAreEqual()
        {
            string pw = pwd.Password.ToString();
            string verPw = pwdBestaetigt.Password.ToString();

            if (pw.Equals(verPw))
                return true;

            return false;
        }
        public bool PwMeetReq()
        {
            string pw = pwd.Password.ToString();
            Regex pwdPat = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,20}$");
            MatchCollection pwdCol = pwdPat.Matches(pw);

            if (pwdCol.Count() == 1)
                return true;

            return false;
        }
    }
}
