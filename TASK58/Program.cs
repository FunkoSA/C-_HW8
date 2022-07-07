/* 
    Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
    Массив A:
* 6 0 2
* 0 4 8
* 0 7 9

    Массив В:
* 0 0 3
* 5 0 4
* 8 2 0

    Результат
* 16 4 18
* 84 16 16
* 107 18 28 
*/

using System;
using static System.Console;
Clear();

int rows = new Random().Next(2, 6);
int columns = new Random().Next(2, 6);
WriteLine($"Сгенерирован случайный массив A {rows}X{columns}: ");

int[,] matrixA = GetRandomArray(rows, columns);
PrintArray(matrixA);

WriteLine($"Сгенерирован случайный массив B {columns}X{rows}: ");
int[,] matrixB = GetRandomArray(columns, rows);
PrintArray(matrixB);

int[,] matrixAB = MultipliedMatrix(matrixA, matrixB);

WriteLine($"Получен массив в результате произведения массивов А и B {rows}X{rows}: ");
PrintArray(matrixAB);

int[,] MultipliedMatrix(int[,] firstArray, int[,] secondArray)
{
    int[,] resultArray = new int[firstArray.GetLength(0), secondArray.GetLength(1)];
    for (int i = 0; i < firstArray.GetLength(0); i++)
    {
        for (int j = 0; j < secondArray.GetLength(1); j++)
        {
            for (int k = 0; k < firstArray.GetLength(1); k++)
            {
                resultArray[i, j] += firstArray[i, k] * secondArray[k, j];
            }

        }
    }
    return resultArray;
}


int[,] GetRandomArray(int rows, int columns)
{
    int[,] result = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = new Random().Next(0, 11);
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