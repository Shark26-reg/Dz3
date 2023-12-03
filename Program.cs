using System;
using System.Collections.Generic;


/*Доработайте приложение поиска пути в лабиринте, но на этот раз вам нужно определить сколько всего выходов имеется в лабиринте:
{1, 1, 1, 1, 1, 1, 1 },
{1, 1, 0, 0, 0, 0, 1 },
{1, 1, 1, 1, 1, 0, 1 },
{2, 0, 0, 0, 1, 0, 2 },
{1, 1, 0, 2, 1, 1, 1 },
{1, 1, 1, 1, 1, 1, 1 },
{1, 1, 1, 2, 1, 1, 1 }
*/


public class Program
{
    static Stack<Tuple<int, int>> _path = new Stack<Tuple<int, int>>();

    static int[,] labirynth1 = new int[,]
    {
        {1, 1, 1, 1, 1, 1, 1 },
        {1, 1, 0, 0, 0, 0, 1 },
        {1, 1, 1, 0, 1, 0, 1 },
        {2, 0, 0, 0, 1, 0, 2 },
        {1, 1, 0, 2, 1, 1, 1 },
        {1, 1, 1, 1, 1, 1, 1 },
        {1, 1, 1, 2, 1, 1, 1 }
    };

    static int FindAllExits(int i, int j)
    {
        // Проверяем, является ли начальная позиция стеной
        if (labirynth1[i, j] == 1)
        {
            return 0;
        }

        _path.Push(new Tuple<int, int>(i, j));

        // Счётчик найденных выходов
        int exitsCount = 0;

        while (_path.Count > 0)
        {
            var current = _path.Pop();

           
            if (labirynth1[current.Item1, current.Item2] == 2)
            {
                exitsCount++;
            }

            // Помечаем ячейку как посещённую
            labirynth1[current.Item1, current.Item2] = 1;

            PushIfAvailable(current.Item1 + 1, current.Item2);
            PushIfAvailable(current.Item1 - 1, current.Item2);
            PushIfAvailable(current.Item1, current.Item2 + 1);
            PushIfAvailable(current.Item1, current.Item2 - 1);
        }

        Console.WriteLine($"Количество найденных выходов: {exitsCount}");
        return exitsCount;
    }

    static void PushIfAvailable(int x, int y)
    {
        if (x >= 0 && x < labirynth1.GetLength(0) && y >= 0 && y < labirynth1.GetLength(1))
        {
            if (labirynth1[x, y] == 0 || labirynth1[x, y] == 2)
            {
                _path.Push(new Tuple<int, int>(x, y));
            }
        }
    }

    public static void Main()
    {
        int exitsFound = FindAllExits(3, 1);
        Console.WriteLine($"Общее количество выходов найдено: {exitsFound}");
    }
}