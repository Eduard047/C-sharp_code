using System;
using System.Text;

class MatrixCalculator
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8; 

        Console.Write("Розмір матриці: ");
        int size = int.Parse(Console.ReadLine());

        double[,] matrixA = new double[size, size];
        double[,] matrixB = new double[size, size];
        double[,] resultMatrix = new double[size, size];

        Console.WriteLine("Елементи матриці A:");
        ReadMatrix(matrixA);

        Console.WriteLine("Елементи матриці B:");
        ReadMatrix(matrixB);

        Console.WriteLine("Виберіть операцію:");
        Console.WriteLine("1 - додавання матриць");
        Console.WriteLine("2 - віднімання матриць");
        Console.WriteLine("3 - множення матриць");
        int operation = int.Parse(Console.ReadLine());

        switch (operation)
        {
            case 1:
                resultMatrix = AddMatrices(matrixA, matrixB);
                break;
            case 2:
                resultMatrix = SubtractMatrices(matrixA, matrixB);
                break;
            case 3:
                resultMatrix = MultiplyMatrices(matrixA, matrixB);
                break;
            default:
                Console.WriteLine("Некоректний вибір операції.");
                break;
        }

        Console.WriteLine("Результат:");
        PrintMatrix(resultMatrix);
    }

    static void ReadMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Елемент [{i}, {j}]: ");
                matrix[i, j] = double.Parse(Console.ReadLine());
            }
        }
    }

    static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static double[,] AddMatrices(double[,] matrixA, double[,] matrixB)
    {
        int rows = matrixA.GetLength(0);
        int cols = matrixA.GetLength(1);

        double[,] resultMatrix = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                resultMatrix[i, j] = matrixA[i, j] + matrixB[i, j];
            }
        }

        return resultMatrix;
    }

    static double[,] SubtractMatrices(double[,] matrixA, double[,] matrixB)
    {
        int rows = matrixA.GetLength(0);
        int cols = matrixA.GetLength(1);

        double[,] resultMatrix = new double[rows, cols];

                for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                resultMatrix[i, j] = matrixA[i, j] - matrixB[i, j];
            }
        }

        return resultMatrix;
    }

    static double[,] MultiplyMatrices(double[,] matrixA, double[,] matrixB)
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        int rowsB = matrixB.GetLength(0);
        int colsB = matrixB.GetLength(1);

        double[,] resultMatrix = new double[rowsA, colsB];

        if (colsA != rowsB)
        {
            Console.WriteLine("Множення матриць неможливе.");
            return resultMatrix;
        }

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                double sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += matrixA[i, k] * matrixB[k, j];
                }
                resultMatrix[i, j] = sum;
            }
        }

        return resultMatrix;
    }
}

