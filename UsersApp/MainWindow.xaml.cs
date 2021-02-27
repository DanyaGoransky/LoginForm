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
using System.Windows.Media.Animation;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0;
            btnAnimation.To = 268;
            btnAnimation.Duration = TimeSpan.FromSeconds(3);
            regButton.BeginAnimation(Button.WidthProperty,btnAnimation);

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string log = LoginLabel.Text.Trim();
            string pass = PassLabel.Password.Trim();
            string pass2 = PassLabel2.Password.Trim();
            string email = EmailLabel.Text.Trim().ToLower();

            if (log.Length < 5)
            {
                LoginLabel.ToolTip = "Login must be more than 5 characters!";
                LoginLabel.Background = Brushes.MediumPurple;
            }
            else if (pass.Length < 5)
            {
                PassLabel.ToolTip = "Password must be more than 5 characters!";
                PassLabel.Background = Brushes.MediumPurple;
            }
            else 
            if (pass != pass2)
            {
                PassLabel2.ToolTip = "Password mismatch!";
                PassLabel2.Background = Brushes.MediumPurple;
            }
            else
            if (email.Length<5 || !email.Contains("@")|| !email.Contains("."))
            {
                EmailLabel.ToolTip = "Incorrect email!";
                EmailLabel.Background = Brushes.MediumPurple;
            }
            else
            {
                LoginLabel.ToolTip = "";
                LoginLabel.Background = Brushes.Transparent;
                PassLabel.ToolTip = "";
                PassLabel.Background = Brushes.Transparent;
                PassLabel2.ToolTip = "";
                PassLabel2.Background = Brushes.Transparent;
                EmailLabel.ToolTip = "";
                EmailLabel.Background = Brushes.Transparent;
                MessageBox.Show("All is good!");
              
                User user = new User(log,email,pass);
                db.Users.Add(user);
                db.SaveChanges();
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Hide();

            }
           
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            App.Close();
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }
    }
}
