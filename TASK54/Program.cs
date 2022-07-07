/*  
   Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

    Исходный массив:
* 1 4 7 2
* 5 9 2 3
* 8 4 2 4

    Результат:
* 7 4 2 1
* 9 5 3 2
* 8 4 4 2
 */



using System;
using static System.Console;
Clear();

int rows = new Random().Next(4, 11);
int columns = new Random().Next(4, 11);
WriteLine($"Сгенерирован случайный массиве {rows}X{columns}: ");

int[,] matrix = GetRandomArray(rows, columns);
PrintArray(matrix);
int [,] sortedMatrix = GetSortrdMatrix (matrix);
WriteLine("Сортированная матрица:");
PrintArray(sortedMatrix);

int [,] GetSortrdMatrix(int[,] array)
{
    int [,] result = new int [array.GetLength(0),array.GetLength(1)];
    
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int maxElement = array[i,j];
            int maxElementPosition = j;
            for (int k=j; k < array.GetLength(1); k++)
            {
                if (maxElement<array[i,k]) 
                {
                    maxElement=array[i,k];
                    maxElementPosition = k;
                }
            }
            int tempElementValue = array[i,j];
            result[i,j] = maxElement;
            array[i,maxElementPosition] =   tempElementValue;     
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