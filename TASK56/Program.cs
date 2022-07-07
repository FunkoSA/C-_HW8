/* 
    Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
    Исходный массив:

* 1 4 7 2
* 5 9 2 3
* 8 4 2 4
* 5 2 6 7
    Результат:
* 1-строка 
*/



using System;
using static System.Console;
Clear();

int rows = new Random().Next(4, 11);
int columns = new Random().Next(4, 11);
WriteLine($"Сгенерирован случайный массиве {rows}X{columns}: ");

int[,] matrix = GetRandomArray(rows, columns);
PrintArray(matrix);
int [] arraySums = MinSumElelents  (matrix);
RowMinSum(arraySums);


void RowMinSum (int [] array)
{
    int minElement=array[0];
    int minPosition=0;
    for (int i=0; i<array.Length;i++)
    {
        if (array[i]<minElement) minPosition = i;
    }
    WriteLine($"Строка {minPosition+1} с минимальной суммой значений элементов");

}

int [] MinSumElelents (int[,] array)
{
    int [] result = new int [array.GetLength(0)];    
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sum =0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            result[i]+=array[i,j];
        }
        
    }
    return result;
}

int[,] GetRandomArray(int rows, int columns)
{
    int[,] result = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = new Random().Next(-100, 120);
        }
    }
    return result;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Write($"{array[i, j]} ");
        }
        WriteLine("");
    }
}