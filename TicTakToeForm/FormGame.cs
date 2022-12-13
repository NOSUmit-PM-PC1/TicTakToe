using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTakToeForm
{
    public partial class FormGame : Form
    {
        const int SIZE = 3;
        byte[,] field = new byte[SIZE, SIZE];
        string[] gameEnd = { "ничья", "крестики", "нолики" };
        byte player = 2; // ход крестиков или ноликов
        int step = 0;

        void showField(byte[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (mas[i, j] == 1)
                        dataGridViewField.Rows[i].Cells[j].Value = "x";
                    else
                        if (mas[i, j] == 2)
                            dataGridViewField.Rows[i].Cells[j].Value = "o";
                }
            }
        }

        public FormGame()
        {
            InitializeComponent();
            for (int i = 0; i < SIZE; i++)
            {
                dataGridViewField.Rows.Add();
            }
            //field[1, 1] = 1;
            //field[2, 2] = 2;
            //showField(field);
        }

        bool isGameOver(byte[,] mas, byte player)
        {
            // проверка по вертикалям и горизонталям
            for (int j = 0; j < SIZE; j++)
            {
                int kStr = 0;
                int kStlb = 0;
                for (int i = 0; i < SIZE; i++)
                {
                    if (mas[j, i] == player) kStr++;
                    if (mas[i, j] == player) kStlb++;
                }
                if (kStr == SIZE)
                {
                    Console.WriteLine(player); return true;
                }
                if (kStlb == SIZE) return true;
            }
            // проверка по диагонали
            int kMainDiag = 0;
            int kPobDiag = 0;
            for (int i = 0; i < SIZE; i++)
            {
                if (mas[i, i] == player) kMainDiag++;
                if (mas[i, SIZE - i - 1] == player) kPobDiag++;
            }
            if (kMainDiag == SIZE) return true;
            if (kPobDiag == SIZE) return true;

            return false;
        }

        private void dataGridViewField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex + " " + e.ColumnIndex);
            if (field[e.RowIndex, e.ColumnIndex] == 0)
            {
                player = (byte)(player % 2 + 1); // переход хода к другому игроку
                field[e.RowIndex, e.ColumnIndex] = player;
                step++;
                showField(field);
                if (isGameOver(field, player))
                    MessageBox.Show("Победил " + gameEnd[player]);
                else
                    if (step == 9)
                        MessageBox.Show("Ничья!");
            }
            else
            {
                MessageBox.Show("НиЗЯ!");
            }
        }
    }
}
