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
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.HideMenuItems();
            }
        }

        private void LogUserIn(object sender, RoutedEventArgs e)
        {


            //NavigationService?.Navigate(new Uri("User.xaml", UriKind.Relative));
            //NavigationService?.Navigate(new Uri("Admin.xaml", UriKind.Relative));

            //NavigationService?.Navigate(new Uri("Mentoren.xaml", UriKind.Relative));
            //Output if Login failed
            //if(false == true)
            //MessageBox.Show("Ein Fehler ist aufgetreten. Bitte kontrollieren sie ihre Eingaben. Wenn sie noch nicht registriet sind klicken sie auf 'Registrieren'","Fehler bei Verarbeitung", MessageBoxButton.OK);

            
            MainWindow mainWindow = new MainWindow();
            foreach (var User in mainWindow.allUsers)
            {
                if (User.isLoginDataCorrect(LoginMail.Text, LoginPwd.SecurePassword.ToString()))
                    mainWindow.currentUser = User;
            }
            if(mainWindow.currentUser.Role.Contains('s'))
                NavigationService?.Navigate(new Uri("User.xaml", UriKind.Relative));
            else if (mainWindow.currentUser.Role.Contains('m'))
                NavigationService?.Navigate(new Uri("Mentoren.xaml", UriKind.Relative));
            else if(mainWindow.currentUser.Role.Contains('a'))
                NavigationService?.Navigate(new Uri("Admin.xaml", UriKind.Relative));
            else
                MessageBox.Show("Ein Fehler ist aufgetreten","Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            
        }
        public void GoToRegistration(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("Registrierung.xaml", UriKind.Relative));
        }

    }
}

