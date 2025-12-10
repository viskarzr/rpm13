using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rpm13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tbCol.Focus();

        }
        int[,] matr;
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №13\r\nСоздание масштабируемого интерфейса приложения.\r\n5. Дана целочисленная матрица размера M * N. Найти номер первого из ее столбцов, \r\nсодержащих только нечетные числа. Если таких столбцов нет, то вывести 0.");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRez_Click(object sender, RoutedEventArgs e)
        {
            
            int row, col;
            try
            {
                row = Convert.ToInt32(tbRow.Text);
                col = Convert.ToInt32(tbCol.Text);
                Libmas.InitMatr(out matr, row, col);
                for (int j = 0; j < matr.GetLength(1); j++)
                {

                    for(int i =0; i< matr.GetLength(0); i++)
                    {
                        if (matr[i,j]/2!=0)
                        {
                        

                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                {
                    MessageBox.Show("Данные не верны!");
                    tbCol.Focus();
                }
            }
        }
    }
}