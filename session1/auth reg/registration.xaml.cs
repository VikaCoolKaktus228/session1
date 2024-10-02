using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace session1.auth_reg
{
    /// <summary>
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Page
    {
        public registration()
        {
            InitializeComponent();
            logintb.MaxLength = 50;
            passtb.MaxLength = 50;
            repeatpasstb.MaxLength = 50;
            nametb.MaxLength = 50;


        }



        private void regbtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(logintb.Text) || string.IsNullOrEmpty(passtb.Password) || string.IsNullOrEmpty(repeatpasstb.Password) || string.IsNullOrWhiteSpace(nametb.Text))
            {
                MessageBox.Show("заполните все поля!!");
            }
            else
            {
                try
                {
                    Users user = new Users()
                    {
                        Iduser = 1,
                        username = nametb.Text,
                        login = logintb.Text,
                        password = passtb.Password,
                        idRole = 2
                    };
                    AppConect.agentmod.Users.Add(user);
                    AppConect.agentmod.SaveChanges();
                    MessageBox.Show("вы успешно зарегистрировались");
                    AppFrame.agentframe.Navigate(new authorization());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ошибка данных");
                }
            }
            
        }

        private void toauthbtn_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.agentframe.Navigate(new authorization());
        }

        private void nametb_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.A || e.Key > Key.Z) && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void repeatpasstb_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void repeatpasstb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passtb.Password != repeatpasstb.Password)
            {
                regbtn.IsEnabled = false;
            }
            else if (passtb.Password == repeatpasstb.Password)
            {
                regbtn.IsEnabled = true;
            }
        }
    }
}
