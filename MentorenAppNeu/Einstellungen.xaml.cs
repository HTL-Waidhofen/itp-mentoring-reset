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
    /// Interaktionslogik für Einstellungen.xaml
    /// </summary>
    public partial class Einstellungen : Page
    {
        public MainWindow mainWindow = new MainWindow();
        public Einstellungen()
        {
            InitializeComponent();
            showUserInSettings();
        }

        private void showUserInSettings()
        {
            MainWindow mainWindow = new MainWindow();
            VName.Text = mainWindow.currentUser.Vorname;
            NName.Text = mainWindow.currentUser.Nachname;
            ID.Text = mainWindow.currentUser.ID.ToString();
            Email.Text = mainWindow.currentUser.Email;
        }
        private void changeProfileInfo(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Sollen die Änderungen übernommen werden?", "Profil bearbeiten", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                //User Bearbeiten
                VName.IsReadOnly = false;
                NName.IsReadOnly = false;
                Email.IsReadOnly = false;
                //mainWindow.currentUser.UpdateBenutzerEmail(Email.Text);
            }
        }

        private void deleteProfile(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Möchten Sie das Profil wirklich löschen? Dies kann nicht rückgängig gemacht werden", "Profil löschen", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                //mainWindow.currentUser.DeleteBenutzer();
            }
        }
    }
}
