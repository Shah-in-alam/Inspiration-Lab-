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

        private async void SendOtp_Click(object sender, RoutedEventArgs e)
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
                var apiKey = "Your-sendgrid-api-key";
                var client = new SendGrid.SendGridClient(apiKey);

                var from = new SendGrid.Helpers.Mail.EmailAddress("mshahinalam37@gmail.com", "LawFarm Support");
                var to = new SendGrid.Helpers.Mail.EmailAddress(email);
                var subject = "LawFarm - Your OTP Code";

                // Use a friendly and formatted HTML content
                var htmlContent = $@"
                <html>
                <body style='font-family: Arial, sans-serif;'>
                    <h2 style='color:#2E8B57;'>Dear User,</h2>
                    <p>Your <strong>One-Time Password (OTP)</strong> for resetting your password is:</p>
                    <h3 style='color:#d35400;'>{generatedOtp}</h3>
                    <p>This code is valid for <strong>10 minutes</strong>. Please do not share this code with anyone.</p>
                    <br/>
                    <p>Best regards,<br/>LawFarm Team</p>
                </body>
                </html>";

                var plainTextContent = $"Dear User,\n\nYour OTP for password reset is: {generatedOtp}\n\nDo not share this with anyone.\n\n- LawFarm";

                var msg = SendGrid.Helpers.Mail.MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                // HIGHLY RECOMMENDED: Set reply-to for legit sender score
                msg.ReplyTo = new SendGrid.Helpers.Mail.EmailAddress("lawfarmbe@gmail.com", "LawFarm Helpdesk");

                var response = await client.SendEmailAsync(msg);

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
