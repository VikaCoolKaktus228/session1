using session1.agentpages;
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

namespace session1.auth_reg
{
    /// <summary>
    /// Логика взаимодействия для authorization.xaml
    /// </summary>
    public partial class authorization : Page
    {
        public authorization()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void regbtn_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.agentframe.Navigate(new registration());
        }

        private void authbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var password = AppConect.agentmod.Users.FirstOrDefault(x => x.password == passtb.Password);
                if (password == null)
                {
                    MessageBox.Show("неверный пароль",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                var user = AppConect.agentmod.Users.FirstOrDefault(x => x.login == logintb.Text && x.password == passtb.Password);
                if (user == null)
                {
                    MessageBox.Show("Такого пользователя не существует",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;

                }
                else
                {
                    switch (user.idRole)
                    {
                        case 1:
                            MessageBox.Show("здраствйте админ",
                    "уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.agentframe.Navigate(new agents());
                            break;
                        case 2:
                            MessageBox.Show("здраствйте пользователь",
                    "уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.agentframe.Navigate(new agents());
                            break;
                        default:
                            MessageBox.Show("данные не обнаружены!",
                    "уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message.ToString(),
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
