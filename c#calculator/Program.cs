using System;
using System.Text;

namespace MatrixCalculator
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("Для генерації випадкової матриці введіть 'random'");
                Console.WriteLine("Для виходу з програми введіть 'exit'\n");

                Console.Write("Розмір матриці: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                int size;
                int[,] matrixA;
                int[,] matrixB;

                if (input.ToLower() == "random")
                {
                    Console.Write("Введіть розмір матриці: ");
                    string sizeInput = Console.ReadLine();

                    if (!int.TryParse(sizeInput, out size))
                    {
                        Console.WriteLine("Некоректний ввід розміру матриці. Спробуйте ще раз.\n");
                        continue;
                    }

                    matrixA = GenerateRandomMatrix(size);
                    matrixB = GenerateRandomMatrix(size);

                    Console.WriteLine("Елементи матриці A:");
                    PrintMatrix(matrixA);

                    Console.WriteLine("Елементи матриці B:");
                    PrintMatrix(matrixB);
                }
                else
                {
                    if (!int.TryParse(input, out size))
                    {
                        Console.WriteLine("Некоректний ввід. Спробуйте ще раз.\n");
                        continue;
                    }

                    Console.WriteLine("Елементи матриці A:");
                    matrixA = ReadMatrix(size);
                    PrintMatrix(matrixA);

                    Console.WriteLine("Елементи матриці B:");
                    matrixB = ReadMatrix(size);
                    PrintMatrix(matrixB);
                }

                Console.WriteLine("Виберіть операцію:");
                Console.WriteLine("1 - додавання матриць");
                Console.WriteLine("2 - віднімання матриць");
                Console.WriteLine("3 - множення матриць");
                int operation;
                if (!int.TryParse(Console.ReadLine(), out operation))
                {
                    Console.WriteLine("Некоректний ввід операції. Спробуйте ще раз.\n");
                    continue;
                }

                int[,] resultMatrix;

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
                        Console.WriteLine("Некоректний ввід операції. Спробуйте ще раз.\n");
                        continue;
                }

                Console.WriteLine("Результат:");
                PrintMatrix(resultMatrix);
                Console.WriteLine();
            }
        }

        static int[,] GenerateRandomMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next(0, 100);
                }
            }

            return matrix;
        }
        
        static int[,] ReadMatrix(int size)
        {
            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"Елемент [{i + 1},{j + 1}]: ");
                    string input = Console.ReadLine();
                    int value;

                    if (!int.TryParse(input, out value))
                    {
                        Console.WriteLine("Некоректний ввід елементу матриці. Спробуйте ще раз.\n");
                        j--;
                        continue;
                    }

                    matrix[i, j] = value;
                }
            }

            return matrix;
        }

        static int[,] AddMatrices(int[,] matrixA, int[,] matrixB)
        {
            int size = matrixA.GetLength(0);
            int[,] result = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            return result;
        }

        static int[,] SubtractMatrices(int[,] matrixA, int[,] matrixB)
        {
            int size = matrixA.GetLength(0);
            int[,] result = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }

            return result;
        }

        static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
        {
            int size = matrixA.GetLength(0);
            int[,] result = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return result;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
