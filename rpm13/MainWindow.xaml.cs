using System.Data;
using System.Data.Common;
using System.Drawing;
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
                int nech = Libmas.Raz(matr);
                tbRez.Text = nech.ToString();
            }
            catch (FormatException ex)
            {
                {
                    MessageBox.Show("Данные не верны!");
                    tbCol.Focus();
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Libmas.SaveMatr(ref matr);
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Libmas.OpMatr(ref matr);
            DataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
        }

        private void btnFull_Click(object sender, RoutedEventArgs e)
        {
            tbRez.Clear();
            bool f1 = Int32.TryParse(tbCol.Text, out int colomn);
            bool f2 = Int32.TryParse(tbRow.Text, out int row);
            if (f1 && f2)
            {
                Libmas.InitMatr(out matr, row, colomn);
                DataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
            else
            {
                MessageBox.Show("Введите корректные значения");
            }

        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            bool f1;
            int value;
            f1 = Int32.TryParse(((TextBox)e.EditingElement).Text, out value);
            if (f1 == true)
            {
                int indexColumn = e.Column.DisplayIndex;
                int indexRow = e.Row.GetIndex();
                matr[indexRow, indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);

            }
            else
            {
                MessageBox.Show("Введите корректные значения");
            }
        }

        private void cmClean_Click(object sender, RoutedEventArgs e)
        {
            tbRez.Clear();
            tbRow.Clear();
            tbCol.Clear();
            DataGrid.ItemsSource = null;
            matr = null;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.CurrentCell.Item != null && DataGrid.CurrentCell.Column != null)
            {
                if (DataGrid.CurrentCell.Item is DataRowView dataRowView)
                {
                    int rowIndex = dataRowView.Row.Table.Rows.IndexOf(dataRowView.Row);
                    int columnIndex = DataGrid.CurrentCell.Column.DisplayIndex;
                    tbMatrix.Text = $"Строка: {rowIndex + 1}, Столбец: {columnIndex + 1}";
                }
                else
                {
                    int rowIndex = DataGrid.Items.IndexOf(DataGrid.CurrentCell.Item);
                    int columnIndex = DataGrid.CurrentCell.Column.DisplayIndex;
                    tbMatrix.Text = $"Строка: {rowIndex + 1}, Столбец: {columnIndex + 1}";
                }
            }
            else
            {
                tbMatrix.Text = "Не выбрано";
            }
        }
    }
}