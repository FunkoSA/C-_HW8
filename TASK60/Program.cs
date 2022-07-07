/*
     Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

    массив размером 2 x 2 x 2
* 12(0,0,0) 22(0,0,1)
* 45(0,1,0) 53(0,1,1)
* 32(1,0,0) 41(1,0,1)
* 66(1,1,0) 88(1,1,1)
 */

using System;
using static System.Console;
Clear();
int firstDimension;
int secondDimension;
int thirdDimension;
//максимально удобная для вывода таблица значений из куба данных 7х4х3, можно и рандомно, но не красиво иногда
do
{
    firstDimension = 7; //new Random().Next(2, 10);
    secondDimension = 4; //new Random().Next(2, 10);
    thirdDimension = 3; //new Random().Next(2, 10);
} while (firstDimension * secondDimension * thirdDimension > 89);

WriteLine($"Сгенерирован случайный массиве {firstDimension}X{secondDimension}X{thirdDimension} ");

int[,,] matrix = GetRandomArray(firstDimension, secondDimension, thirdDimension);
PrintArray(matrix);

int[,,] GetRandomArray(int rows, int columns, int pole)
{
    int[,,] result = new int[rows, columns, pole];
    int elementNumber =0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            for (int k = 0; k < pole; k++)
            {

                elementNumber++;
                do
                {
                    result[i, j, k] = new Random().Next(10, 100);

                } while (SerchElement(result, result[i, j, k],elementNumber) != 0);


            }

        }
    }
    return result;
}

int SerchElement(int[,,] array, int number, int elementPosition)
{
    int count = 0;
    int linearСounter =0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                linearСounter++;
                if (linearСounter !=elementPosition)
                if (number == array[i, j, k]) count++;
                
            }
        }
    }
    return count;
}


void PrintArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
                Write($"{array[i, j, k]} ({i},{j},{k})  ");
        }
        WriteLine("");
    }
}



