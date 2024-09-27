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
        }

        private void regbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Users user = new Users()
                {
                    Iduser = 1,
                    username = nametb.Text,
                    login = logintb.Text,
                    password = passtb.Text,
                    idRole = 2
                };
                AppConect.agentmod.Users.Add(user);
                AppConect.agentmod.SaveChanges();
                MessageBox.Show("вы успешно зарегистрировались");
            }
            catch (Exception ex)
            {
                MessageBox.Show("jib,rf");
            }
        }
    }
}
