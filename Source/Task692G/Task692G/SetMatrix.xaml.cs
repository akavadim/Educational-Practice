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
using System.Data;

namespace Task692G
{
    /// <summary>
    /// Логика взаимодействия для SetMatrix.xaml
    /// </summary>
    public partial class SetMatrix : Window
    {
        private DataTable tableMatrix;
        public Matrix matrix;

        public SetMatrix(Matrix matrix)
        {
            InitializeComponent();
            tableMatrix = matrix.GetDataTable();
            dataGridMatrix.ItemsSource = tableMatrix.DefaultView;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            matrix = new Matrix(tableMatrix);
            this.DialogResult = true;
        }
    }
}
