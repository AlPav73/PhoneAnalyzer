using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhoneAnalyzer.Helpers
{
    /// <summary>
    /// Содержит методы для работы с DataGridView
    /// </summary>
    public static class GridHelper
    {
        /// <summary>
        /// Устанавливает подписи в DataGridView 
        /// </summary>
        /// <param name="dataGridView">DataGridView</param>
        /// <param name="names">Массив заголовков</param>
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

        /// <summary>
        /// Скрывает столбцы в DataGridView
        /// </summary>
        /// <param name="dataGridView">DataGridView</param>
        /// <param name="colimnIndexes">Массив столбцов, которые надо скрыть</param>
        public static void SetInvisible(DataGridView dataGridView, int[] colimnIndexes)
        {
            int count = Math.Min(dataGridView.Columns.Count, colimnIndexes.Length);
            for (int i = 0; i < count; i++)
            {
                int index = colimnIndexes[i];
                dataGridView.Columns[index].Visible = false;
            }
        }

        /// <summary>
        /// Показывает столбцы в DataGridView
        /// </summary>
        /// <param name="dataGridView">DataGridView</param>
        /// <param name="colimnIndexes">Массив столбцов, которые надо показать</param>
        internal static void SetVisible(DataGridView dataGridView, int[] colimnIndexes)
        {
            int count = Math.Min(dataGridView.Columns.Count, colimnIndexes.Length);
            for (int i = 0; i < count; i++)
            {
                int index = colimnIndexes[i];
                dataGridView.Columns[index].Visible = true;
            }
        }

        /// <summary>
        /// Получает число из DataGridViewRow
        /// </summary>
        /// <param name="dataGridViewRow">DataGridViewRow</param>
        /// <param name="cellIndex">Индекс ячейки</param>
        /// <returns>Значение в ячейке</returns>
        public static int GetIntFromRow(DataGridViewRow dataGridViewRow, int cellIndex)
        {
            int value = 0;
            string cellValue = dataGridViewRow.Cells[cellIndex].Value.ToString();
            return int.TryParse(cellValue, out value) ? value : 0;
        }

        /// <summary>
        /// Получает строку из DataGridViewRow
        /// </summary>
        /// <param name="dataGridViewRow">DataGridViewRow</param>
        /// <param name="cellIndex">Индекс ячейки</param>
        /// <returns>Значение в ячейке</returns>
        public static string GetStringFromRow(DataGridViewRow dataGridViewRow, int cellIndex)
        {
            string cellValue = dataGridViewRow.Cells[cellIndex].Value.ToString();
            return cellValue;
        }

        /// <summary>
        /// Преобразует bool в человекскую строку
        /// </summary>
        /// <param name="b">bool</param>
        /// <returns>Да или Нет</returns>
        public static string BoolString(bool b)
        {
            return b ? "Да" : "Нет";
        }
    }
}