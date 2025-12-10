using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace rpm13
{
    public static class Libmas
    {

        /// <summary>
        /// создание пустой матрицы
        /// </summary>
        /// <param name="matr">матрица</param>
        /// <param name="colomn">кол-во столбцов</param>
        /// <param name="row">кол-во строк</param>
        public static void CrMatr(out int[,] matr, int colomn, int row)
        {
            matr = new int[row, colomn];
        }

        /// <summary>
        /// Заполнение матрицы
        /// </summary>
        /// <param name="matr">матрица</param>
        /// <param name="colomn">кол-во столбцов</param>
        /// <param name="row">кол-во строк</param>
        public static void InitMatr(out int[,] matr, int row, int colomn)
        {
            Random rnd = new Random();
            matr = new int[row, colomn];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    matr[i, j] = rnd.Next(-20,20);
                }
            }
        }

        /// <summary>
        /// Сохранение матрицы
        /// </summary>
        /// <param name="matr">матрица</param>
        public static void SaveMatr(ref int[,] matr) 
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* |Текстовые документы| *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение документа";

            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);
                file.WriteLine(matr.GetLength(0));
                file.WriteLine(matr.GetLength(1));
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        file.WriteLine(matr[i, j]);
                    }
                }
                file.Close();
            }
        }

        /// <summary>
        /// открытие файлв с  матрицей
        /// </summary>
        /// <param name="matr">матрица</param>
        public static void OpMatr(ref int[,] matr) 
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* |Текстовые документы| *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие документа";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);
                int row = Convert.ToInt32(file.ReadLine());
                int colomn = Convert.ToInt32(file.ReadLine());

                matr = new int[row, colomn];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < colomn; j++)
                    {
                        matr[i, j] = Convert.ToInt32(file.ReadLine());
                    }
                }
                file.Close();
            }           
        }
        /// <summary>
        /// Расчет номера столбца с нечетными числами
        /// </summary>
        /// <param name="matr">матрица</param>
        /// <returns>номер столбца</returns>
        public static int Raz(int[,] matr)
        {
            for (int j = 0; j < matr.GetLength(1); j++)
            {
                bool nechet = true; 
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    if (matr[i, j] % 2 == 0)
                    {
                        nechet = false;
                        break; 
                    }
                }
                if (nechet)
                {
                    return j + 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// Очищение матрицы
        /// </summary>
        /// <param name="colomn">кол-во столбцов</param>
        /// <param name="row">кол-во строк</param>
        /// <returns>матрица с нулями</returns>
        public static int[,] CleanMatr(int row, int colomn)
        {
            try
            {
                if (row <= 0 || colomn <= 0)
                    MessageBox.Show("Размеры матрицы должны быть положительными");
                int[,] newMatrix = new int[row, colomn];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < colomn; j++)
                    {
                        newMatrix[i, j] = 0;
                    }
                }

                return newMatrix;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка очистки матрицы");
                return new int[row, colomn];
            }
            
        }
            
    }
}
