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
using System.Data;

namespace Task5_691G
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Matrix matrix;

        public MainWindow()
        {
            InitializeComponent();

            matrix = new Matrix(8);
            CreateMatrix(matrix);
            updateDataGrid();
        }

        private void CreateMatrix(Matrix matrix)
        {
            int number = 1;
            for (int i = 0; i < matrix.CountRows; i++)
                for (int j = 0; j < matrix.CountColumns; j++)
                {
                    matrix[i, j] = number;
                    number++;
                }
        }

        private void ButtonSetMatrix_Click(object sender, RoutedEventArgs e)
        {
            SetMatrix setMatrix = new SetMatrix(matrix);
            if(setMatrix.ShowDialog()==true)
            {
                matrix = setMatrix.matrix;
                updateDataGrid();
            }
        }

        private void updateDataGrid()
        {
            dataGridMatrix.ItemsSource = matrix.SortTable().GetDataTable().DefaultView;
        }
    }
}
