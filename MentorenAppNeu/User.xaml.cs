using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaktionslogik für User.xaml
    /// </summary>
    public partial class User : Page
    {
        public MainWindow mainWindow = new MainWindow();
        public User()
        {

            InitializeComponent();

            mainWindow.ShowMenuItems();

            mainWindow.writeBenuterToListBox(mainWindow.mentorListe, MentorOutput);

        }

        private void subjectChanged(object sender, SelectionChangedEventArgs e)
        {
            sortMentorsBySubject();

        }


        private void GoToEmailPage(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("SendEmail.xaml", UriKind.Relative));
        }

        public void sortMentorsBySubject()
        {
            List<Benutzer> sortedMentors = new List<Benutzer>();
            foreach (Benutzer mentor in mainWindow.mentorListe)
            {
                //   foreach (Feacher fach in mentor.Subjects)
                sortedMentors.Add(mentor);

            }
            showMentors(sortedMentors);
        }
        public void showMentors(List<Benutzer> sortedMentors)
        {
            foreach (Benutzer mentor in sortedMentors)


                MentorOutput.Items.Add(mentor.ToString());
        }
        public void showUserInfo(Benutzer user)
        {
            nameBox.Text = user.Vorname + " " + user.Nachname;
            idBox.Text = user.ID.ToString();
            mailBox.Text = user.Email;
            roleBox.Text = user.Role;
        }

        private void mentorSelected(object sender, SelectionChangedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            char idChar = MentorOutput.SelectedItem.ToString().ElementAt(0);
            int id = int.Parse(idChar.ToString());
            showUserInfo(mainWindow.GetBenutzerByID(id));
        }
    }
}

