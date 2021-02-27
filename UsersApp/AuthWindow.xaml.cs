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
using System.Windows.Shapes;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

  
        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string log = LoginLabel.Text.Trim();
            string pass = PassLabel.Password.Trim();
           
        

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
            {
                LoginLabel.ToolTip = "";
                LoginLabel.Background = Brushes.Transparent;
                PassLabel.ToolTip = "";
                PassLabel.Background = Brushes.Transparent;

                User authUser = null;
                using (ApplicationContext context=new ApplicationContext())
                {
                    authUser = context.Users.Where(b =>b.Login==log&&b.Pass==pass).FirstOrDefault();

                }
                if (authUser != null)
                {
                    MessageBox.Show("All is good!");
                    UserPageWindow userPage = new UserPageWindow();
                    userPage.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Wrong data!");
            }

        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Auth.Close();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
