/*
     Заполните спирально массив 4 на 4
* 1 2 3 4
* 12 13 14 5
* 11 16 15 6
* 10 9 8 7
 */
/*
общий принцып решения подсмотрел и адаптировал, теоретически если не делать все во-время, 
то с лекций Сергея где закрашвали псевдокартинку можно было бы и решить самому
*/
using System;
using static System.Console;
Clear();

int rows = new Random().Next(2, 10);
int columns = new Random().Next(2, 10);
WriteLine($"Необходимо заполнить по спирали по часовой стрелке массив  {rows}X{columns}: ");

int[,] matrixA = FillSpiralMatrix(rows, columns);
PrintArray(matrixA);


int[,] FillSpiralMatrix(int rows, int columns)
{
    int[,] result = new int[rows, columns];
    int elementValue = 1;
    for (int i = 0; i < columns; i++)
    {
        result[0, i] = elementValue;
        elementValue++;
    }
    for (int j = 1; j < rows; j++)
    {
        result[j, columns - 1] = elementValue;
        elementValue++;
    }
    for (int i = columns - 2; i >= 0; i--)
    {
        result[rows - 1, i] = elementValue;
        elementValue++;
    }
    for (int j = rows - 2; j > 0 ; j--)
    {
        result[j, 0] = elementValue;
        elementValue++;
    }
    //обозначаем координаты для последующего заполнения матрицы (замены нулей на необходимое значение)
    int columnPosition =1;
    int rowPosition =1;
    while (elementValue < rows*columns)
    {
        //проходим массив в право
        while (result[rowPosition,columnPosition+1]==0)
        {
            result[rowPosition,columnPosition]=elementValue;
            elementValue++;
            columnPosition++;
        }
        //проходим массив в вниз
        while (result[rowPosition+1,columnPosition]==0)
        {
            result[rowPosition,columnPosition]=elementValue;
            elementValue++;
            rowPosition++;
        }
        //проходим массив в влево
        while (result[rowPosition,columnPosition-1]==0)
        {
            result[rowPosition,columnPosition]=elementValue;
            elementValue++;
            columnPosition--;
        }
        //проходим массив в верх
        while (result[rowPosition-1,columnPosition]==0)
        {
            result[rowPosition,columnPosition]=elementValue;
            elementValue++;
            rowPosition--;
        }
    }
    //Убираем последний 0 в нашей матрице
    for (int i=0 ; i< rows ; i++)
    {
        for (int j=0; j<columns;j++)
        {
            if (result[i,j]==0) result[i,j] = elementValue;
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
            Write($"{array[i, j]}   ");
        }
        WriteLine("");
    }
}