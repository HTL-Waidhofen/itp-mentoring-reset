using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
    /// Interaktionslogik für SendEmail.xaml
    /// </summary>
    public partial class SendEmail : Page
    {
        public SendEmail()
        {
            InitializeComponent();
        }
        public void SendEmail_Click(object sender, RoutedEventArgs e)
        {

            if (recipientEmail.Text == "")
            {
                recipientEmail.Background = Brushes.Red;
                MessageBox.Show("Fülle alle Felder aus");
            }
            else if (Subject.Text == "")
            {
                Subject.Background = Brushes.Red;
                MessageBox.Show("Fülle alle Felder aus");
            }
            else if (EmailBody.Text == "")
            {
                EmailBody.Background = Brushes.Red;
                MessageBox.Show("Fülle alle Felder aus");
            }
            else
            {
                recipientEmail.Background = Brushes.White;
                EmailBody.Background = Brushes.White;
                Subject.Background = Brushes.White;
                try
                {
                    //Listbox
                    string fromMail = "";

                    using (var smtpClient = new SmtpClient("smtp-mail.outlook.com"))
                    {
                        smtpClient.Port = 587;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(fromMail, "Password");
                        smtpClient.EnableSsl = true;

                        using (var mailMessage = new MailMessage())
                        {
                            mailMessage.From = new MailAddress(fromMail);
                            mailMessage.Subject = Subject.Text;
                            mailMessage.Body = EmailBody.Text;
                            mailMessage.IsBodyHtml = true;
                            mailMessage.To.Add(recipientEmail.Text);
                            smtpClient.Send(mailMessage);
                        }
                    }
                    MessageBox.Show("E-Mail wurde erfolgreich gesendet.", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
                    recipientEmail.Text = "";
                    Subject.Text = "";
                    EmailBody.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Email konnte nicht gesendet werden");
                }
            }
        }


    }
}
