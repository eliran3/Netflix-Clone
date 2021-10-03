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

namespace WpfApp2
{
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        private void emailTextBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            PhoneEmailText.Text = "";
        }

        private void passwordBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            PasswordTextBlock.Text = "";
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.netflix.com/il-en/LoginHelp");
        }
        private void BackgroundImageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            Window win = (Window)Parent;
            win.Close();
        }
        private void FacebookLoginButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/v2.9/dialog/oauth?app_id=163114453728333&cbt=1584389791705&channel_url=https%3A%2F%2Fstaticxx.facebook.com%2Fconnect%2Fxd_arbiter.php%3Fversion%3D46%23cb%3Df35c0edc6c97504%26domain%3Dwww.netflix.com%26origin%3Dhttps%253A%252F%252Fwww.netflix.com%252Ff1e7e32517c0d98%26relation%3Dopener&client_id=163114453728333&display=popup&domain=www.netflix.com&e2e=%7B%7D&fallback_redirect_uri=https%3A%2F%2Fwww.netflix.com%2Fil-en%2Flogin&locale=en_US&logger_id=f243c9fe1bf7b2&origin=1&redirect_uri=https%3A%2F%2Fstaticxx.facebook.com%2Fconnect%2Fxd_arbiter.php%3Fversion%3D46%23cb%3Df25f46a591bcdec%26domain%3Dwww.netflix.com%26origin%3Dhttps%253A%252F%252Fwww.netflix.com%252Ff1e7e32517c0d98%26relation%3Dopener%26frame%3Df2d4517fab9065&response_type=token%2Csigned_request%2Cgraph_domain&sdk=joey&version=v2.9");
        }
        private void LearnMoreLabel_GotMouseCapture(object sender, MouseEventArgs e)
        {
            LearnMoreText.Text = "";
            PTextBlock.Visibility = Visibility.Visible;
            PrivacyPolicyLabel.Visibility = Visibility.Visible;
            TermsOfServiceLabel.Visibility = Visibility.Visible;
        }
        private void label_GotMouseCapture(object sender, MouseEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            Window win = (Window)Parent;
            win.Close();
        }

        private void Hyperlink_RequestNavigate_1(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://policies.google.com/privacy");
        }

        private void Hyperlink_RequestNavigate_2(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://policies.google.com/terms");
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsNumber(emailTextBox, passwordBox1) && passwordBox1.SecurePassword.Length > 3)
            {
                SignInSuccessLable.Visibility = Visibility.Visible;
                SignInFailedLabel.Visibility = Visibility.Hidden;
                passwordBox1.Clear();
                emailTextBox.Text = "";
                RevealPasswordbox.Text = "";
            }
        }

        bool IsNumber (TextBox textBox, PasswordBox passwordBox)
        {
            foreach (char c in textBox.Text)
            {
                if (char.IsDigit(c) && textBox.Text.Length == 10 || textBox.Text.Contains("@gmail.com"))
                {
                    return true;
                }

                else
                {
                    passwordBox.Clear();
                    textBox.Text = "";
                    SignInFailedLabel.Visibility = Visibility.Visible;
                }
            }

            return false;
        }

        private void EyeButton_Click(object sender, RoutedEventArgs e)
        {
            RevealPasswordbox.Visibility = Visibility.Visible;
            passwordBox1.Visibility = Visibility.Hidden;
            EyeButtonReveal.Visibility = Visibility.Hidden;
            EyeButtonUnreveal.Visibility = Visibility.Visible;
            RevealPasswordbox.Text = passwordBox1.Password;
        }

        public bool IsPBB (PasswordBox passwordBox)
        {
            if (passwordBox.Password.Length > 0) return true;

            else return false;
        }

        private void EyeButtonUnreveal_Click(object sender, RoutedEventArgs e)
        {
            RevealPasswordbox.Visibility = Visibility.Hidden;
            passwordBox1.Visibility = Visibility.Visible;
            EyeButtonReveal.Visibility = Visibility.Visible;
            EyeButtonUnreveal.Visibility = Visibility.Hidden;
            passwordBox1.Password = RevealPasswordbox.Text;
        }
    }
}
