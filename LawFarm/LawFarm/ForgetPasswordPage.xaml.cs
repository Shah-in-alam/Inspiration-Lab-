using System;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LawFarm
{
    public partial class ForgetPasswordPage : Page
    {
        private Database db = new Database();
        private string generatedOtp = "";

        public ForgetPasswordPage()
        {
            InitializeComponent();
        }

        private void SendOtp_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email.");
                return;
            }

            generatedOtp = new Random().Next(100000, 999999).ToString();

            try
            {
                MailMessage message = new MailMessage("your-email@gmail.com", email);
                message.Subject = "Your OTP Code";
                message.Body = $"Your OTP for password reset is: {generatedOtp}";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("shahinalam111024@gmail.com", "Lawfarm"); // Use App Password if Gmail

                smtp.Send(message);
                MessageBox.Show("OTP sent to your email.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send OTP: " + ex.Message);
            }
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailBox.Text.Trim();
            string otpInput = OtpBox.Text.Trim();
            string newPassword = NewPasswordBox.Password;

            if (otpInput != generatedOtp)
            {
                MessageBox.Show("Invalid OTP.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please enter a new password.");
                return;
            }

            bool updated = db.UpdatePasswordByEmail(email, newPassword);
            if (updated)
            {
                MessageBox.Show("Password updated successfully.");
                NavigationService?.Navigate(new StartPage());
            }
            else
            {
                MessageBox.Show("Failed to update password.");
            }
        }

        private void BackToLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StartPage());
        }
    }
}
