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
using System.Windows.Media.Animation;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {

        ApplicationContext db;
        public UserPageWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();

            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0;
            btnAnimation.To = 268;
            btnAnimation.Duration = TimeSpan.FromSeconds(3);
            Profile.BeginAnimation(Button.WidthProperty, btnAnimation);
            HelpBtn.BeginAnimation(Button.WidthProperty, btnAnimation);
            Settings.BeginAnimation(Button.WidthProperty, btnAnimation);
        }

 

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            
        }

    

        private void Profile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();

        }

        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
