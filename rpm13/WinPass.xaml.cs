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

namespace rpm13
{
    /// <summary>
    /// Логика взаимодействия для WinPass.xaml
    /// </summary>
    public partial class WinPass : Window
    {
        public WinPass()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (txtPass.Password == "123")
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль. Повторите попытку");
                txtPass.Clear();
                txtPass.Focus();
            }
        }

        private void btnEsc_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult boxResult = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo);
            if (boxResult == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            txtPass.Focus();
        }
    }
}
