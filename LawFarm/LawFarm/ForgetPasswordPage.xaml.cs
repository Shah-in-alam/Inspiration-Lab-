using SendGrid.Helpers.Mail;
using SendGrid;
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
                var apiKey = "your-real-sendgrid-key";
                var client = new SendGrid.SendGridClient(apiKey);
                var from = new SendGrid.Helpers.Mail.EmailAddress("mshahinalam37@gmail.com", "LawFarm Support");
                var subject = "Your OTP Code";
                var to = new SendGrid.Helpers.Mail.EmailAddress(email);
                var plainTextContent = $"Your OTP for password reset is: {generatedOtp}";
                var htmlContent = $"<strong>Your OTP for password reset is: {generatedOtp}</strong>";
                var msg = SendGrid.Helpers.Mail.MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                var response = client.SendEmailAsync(msg).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("OTP sent to your email.");
                }
                else
                {
                    MessageBox.Show("Failed to send OTP. Try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending OTP: " + ex.Message);
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
