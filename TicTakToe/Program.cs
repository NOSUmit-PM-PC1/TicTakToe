using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTakToe
{
    class Program
    {
        const byte SIZE = 3; // размер поля
        static void showField(byte[,] mas)
        {
            for (int i = 0; i < mas. GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.Write(mas[i,j]);
                }
                Console.WriteLine();
            }
        }

        static bool isGameOver(byte[,] mas, byte player)
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

        static bool isRightInput(out byte i, out byte j)
        {
            Console.WriteLine("Введите координаты x и y вашего хода в одной строке через пробел");
            string[]  temp = Console.ReadLine().Split();
            byte x = Convert.ToByte(temp[0]);
            byte y = Convert.ToByte(temp[1]);
            if (x > 0 && x < 4 && y > 0 && y < 4)
            {
                i = (byte)(3 - y);
                j = (byte)(x - 1);
                return true;
            }
            else
            {
                i = Byte.MaxValue;
                j = Byte.MaxValue;
                return false;
            }
        }

        static void Main(string[] args)
        {
            byte[,] field = new byte[3, 3];
            byte i, j;
            byte player = 2; // ход крестиков
            showField(field);
            while (!isGameOver(field, player))
            {
                if (isRightInput(out i, out j))
                {
                    if (field[i, j] == 0)
                    {
                        player = (byte)(player % 2 + 1); // переход хода к другому игроку
                        field[i, j] = player;
                        showField(field);
                    }
                    else
                        Console.WriteLine("Поле занято");
                }
                else
                {
                    Console.WriteLine("Плохие координаты");
                }
            }
        }
    }
}
