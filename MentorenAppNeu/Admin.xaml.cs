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
    /// Interaktionslogik für Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.ShowMenuItems();

                mainWindow.writeBenuterToListBox(mainWindow.schuelerListe, SchuelerList);
                mainWindow.writeBenuterToListBox(mainWindow.mentorListe, MentorList);


            }
        }


        public void showUserInfo(Benutzer user)
        {
            nameBox.Text = user.Vorname + " " + user.Nachname;
            idBox.Text = user.ID.ToString();
            mailBox.Text = user.Email;
            roleBox.Text = user.Role;
        }


        private void SelectProfileSchueler(object sender, SelectionChangedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            char idChar = SchuelerList.SelectedItem.ToString().ElementAt(0);
            int id = int.Parse(idChar.ToString());
            showUserInfo(mainWindow.GetBenutzerByID(id));
        }

        private void SelectProfileMentor(object sender, SelectionChangedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            char idChar = MentorList.SelectedItem.ToString().ElementAt(0);
            int id = int.Parse(idChar.ToString());
            showUserInfo(mainWindow.GetBenutzerByID(id));
        }

        private void ChangeData(object sender, RoutedEventArgs e)
        {

        }
    }
}
