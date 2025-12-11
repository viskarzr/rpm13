using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(tbRow1.Text) && !string.IsNullOrEmpty(tbCol1.Text))
            //{
            //    int.TryParse(tbRow1.Text, out int rows);
            //    int.TryParse(tbCol1.Text, out int cols);
            //    if (rows == 0 || cols == 0)
            //    {
            //        MessageBox.Show("Нулевые или текстовые значения.", "Ошибка");
            //    }
            //    else
            //    {
            //        StreamWriter file = new StreamWriter("config.ini", false);

            //        file.WriteLine(rows);
            //        config.rows = rows;

            //        file.WriteLine(cols);
            //        config.cols = cols;

            //        file.Close();

            //        config.wasChanged = true;

            //        this.Close();
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Заполните поля");
            //}
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            tbRow1.Focus();
            tbCol1.Text = Data1.Col1.ToString();
            tbRow1.Text = Data1.Row1.ToString();
        }
    }    
}
