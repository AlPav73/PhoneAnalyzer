using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhoneAnalyzer.Helpers
{
    public static class GridHelper
    {
        private static readonly DateComparer DateComparer = new DateComparer();
        private static readonly PriceComparer PriceComparer = new PriceComparer();

        public static void SetHeaders(DataGridView dataGridView, string[] names)
        {
            int count = Math.Min(dataGridView.Columns.Count, names.Length);
            for (int i = 0; i < count; i++)
            {
                DataGridViewColumn column = dataGridView.Columns[i];
                column.HeaderText = String.Concat(names[i]);
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        public static void SetInvisible(DataGridView dataGridView, int[] colimnIndexes)
        {
            int count = Math.Min(dataGridView.Columns.Count, colimnIndexes.Length);
            for (int i = 0; i < count; i++)
            {
                int index = colimnIndexes[i];
                dataGridView.Columns[index].Visible = false;
            }
        }

        internal static void SetVisible(DataGridView dataGridView, int[] colimnIndexes)
        {
            int count = Math.Min(dataGridView.Columns.Count, colimnIndexes.Length);
            for (int i = 0; i < count; i++)
            {
                int index = colimnIndexes[i];
                dataGridView.Columns[index].Visible = true;
            }
        }

        public static int GetIntFromRow(DataGridViewRow dataGridViewRow, int cellIndex)
        {
            int value = 0;
            string cellValue = dataGridViewRow.Cells[cellIndex].Value.ToString();
            return int.TryParse(cellValue, out value) ? value : 0;
        }

        public static string GetStringFromRow(DataGridViewRow dataGridViewRow, int cellIndex)
        {
            string cellValue = dataGridViewRow.Cells[cellIndex].Value.ToString();
            return cellValue;
        }

        public static string BoolString(bool b)
        {
            return b ? "Да" : "Нет";
        }
    }

    public class PriceComparer : IComparer<Object>
    {
        public int Compare(Object stringA, Object stringB)
        {
            string strValueA = stringA.ToString().Replace(" руб.", "");
            string strValueB = stringB.ToString().Replace(" руб.", "");

            int valueA = 0;
            int valueB = 0;

            int.TryParse(strValueA, out valueA);
            int.TryParse(strValueB, out valueB);

            return valueA.CompareTo(valueB);
        }
    }

    public class DateComparer : IComparer<Object>
    {
        public int Compare(Object stringA, Object stringB)
        {
            DateTime valueA = DateTime.Parse(stringA.ToString());
            DateTime valueB = DateTime.Parse(stringB.ToString());

            return valueA.CompareTo(valueB);
        }
    }
}