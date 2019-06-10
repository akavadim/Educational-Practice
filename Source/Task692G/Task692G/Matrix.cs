using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Task692G
{
    public class Matrix : IEnumerable, ICloneable
    {

        #region Конструкторы

        public Matrix(DataTable table):this(table.Rows.Count,table.Columns.Count)
        {
            for (int i = 0; i < countRows; i++)
                for (int j = 0; j < countColumns; j++)
                {
                    matrix[i, j] = (int)table.Rows[i][j];
                }
        }

        public Matrix(int size) : this(size, size) { }

        public Matrix(int rows, int columns)
        {
            matrix = new int[rows, columns];
            count = rows * columns;
            countRows = rows;
            countColumns = columns;
        }

        #endregion

        #region Свойства

        int[,] matrix;
        int count;
        int countRows;
        int countColumns;

        public int Count { get { return count; } }
        public int CountRows { get { return countRows; } }
        public int CountColumns { get { return countColumns; } }

        #endregion

        public int this[int a, int b]
        {
            get { return matrix[a, b]; }
            set { matrix[a, b] = value; }
        }

        #region Интерфейсы

        public IEnumerator GetEnumerator()
        {
            return matrix.GetEnumerator();
        }

        public object Clone()
        {
            Matrix res = new Matrix(countRows, countColumns);
            res.matrix = matrix.Clone() as int[,];
            return res;
        }

        #endregion

        public DataTable GetDataTable()
        {
            DataTable res = new DataTable();
            for (int i = 0; i < countColumns; i++)
            {
                DataColumn column = new DataColumn();
                column.DataType = typeof(int);
                res.Columns.Add(column);
            }

            for (int i = 0; i < countRows; i++)
            {
                DataRow row = res.NewRow();
                for (int j = 0; j < countColumns; j++)
                {
                    row[j] = matrix[i,j];
                }
                res.Rows.Add(row);
            }
            return res;
        }

        public Matrix SortTable()
        {
            if (this.countColumns != this.countRows)
                throw new FormatException("Отсортировать можно только квадратичную матрицу");
            Matrix res = new Matrix(this.countColumns);
            int x = 0;
            int y = 0;
            bool up = true;
            bool bordered = false;

            foreach (int cell in this)
            {
                 res[x, y] = cell;
                if (!bordered)
                {
                    if (y == 0 || y == countColumns-1)
                    {
                        x++;
                        if (y == 0)
                            up = true;
                        else up = false;
                        bordered = true;
                        continue;
                    }
                    if (x == 0 || x == countRows-1)
                    {
                        y++;
                        if (x == 0)
                            up = false;
                        else up = true;
                        bordered = true;
                        continue;
                    }
                }
                else bordered = false;
                if (up)
                {
                    y++;
                    x--;
                }
                else
                {
                    x++;
                    y--;
                }
            }
            return res;
        }
    }
}
