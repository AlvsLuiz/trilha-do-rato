using System;
using System.Collections.Generic;
using System.Threading;
class Labirinto
{
    private const int limit = 15;

    static void mostrarLabirinto(char[,] array)
    {
        for (int i = 0; i < limit; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < limit; j++)
            {
                Console.Write($" {array[i, j]} ");
            }
        }
        Console.WriteLine();
    }

    static void criaLabirinto(char[,] meuLab)
    {
        Random random = new Random();
        for (int i = 0; i < limit; i++)
        {
            for (int j = 0; j < limit; j++)
            {
                meuLab[i, j] = random.Next(4) == 1 ? '|' : '.';
            }
        }

        for (int i = 0; i < limit; i++)
        {
            meuLab[0, i] = '*';
            meuLab[limit - 1, i] = '*';
            meuLab[i, 0] = '*';
            meuLab[i, limit - 1] = '*';
        }

        int x = random.Next(limit);
        int y = random.Next(limit);
        meuLab[x, y] = 'Q'; 
    }

    static void resolveLabirinto(char[,] labirinto, int i, int j)
    {
        Stack<int> pilha_i = new Stack<int>();
        Stack<int> pilha_j = new Stack<int>();
        bool encontrou = false;
        while (encontrou == false){
            labirinto[i, j] = 'v';
            if (labirinto[i, j + 1] == 'Q')
            {
                pilha_i.Push(i);
                pilha_j.Push(j);
                j++;
                encontrou = true;
                labirinto[i, j] = 'V';
            }
            else if (labirinto[i + 1, j] == 'Q')
            {
                pilha_i.Push(i);
                pilha_j.Push(j);
                i++;
                encontrou = true;
                labirinto[i, j] = 'V';
            }
            else if (labirinto[i, j - 1] == 'Q')
            {
                pilha_i.Push(i);
                pilha_j.Push(j);
                j--;
                encontrou = true;
                labirinto[i, j] = 'V';
            }
            else if (labirinto[i - 1, j] == 'Q')
            {
                pilha_i.Push(i);
                pilha_j.Push(j);
                i--;
                encontrou = true;
                labirinto[i, j] = 'V';
            }else  if (labirinto[i, j+1] == '.')
            {
                pilha_i.Push(i);
                pilha_j.Push(j);
                j++;
            }else if (labirinto[i + 1, j] == '.')
            {
                pilha_i.Push(i);
                pilha_j.Push(j);
                i++;
            }else if (labirinto[i,j-1] == '.')
            {
                pilha_i.Push(i);
                pilha_j.Push(j);
                j--;
            }else if (labirinto[i-1,j] == '.')
            {
                pilha_i.Push(i);
                pilha_j.Push(j);
                i--;
            }
            else
            {
                labirinto[i, j] = 'x';
                if (pilha_j.Count > 0 || pilha_i.Count > 0)
                {
                    i = pilha_i.Pop();
                    j = pilha_j.Pop();
                }
                else
                {
                    Console.WriteLine("O acesso ao queijo é impossivel!");
                    break;
                }
            }

            Thread.Sleep(100);
            Console.Clear();
            mostrarLabirinto(labirinto);
            if (encontrou == true)
                Console.WriteLine($"Q queijo foi encontrado na posição {i},{j}");
        }


    }

    static void Main(string[] args)
    {
        char[,] maze = new char[limit, limit];
        int x, y;
        criaLabirinto(maze);
        mostrarLabirinto(maze);
        Console.WriteLine("\nPosições iniciais (linha e coluna):");
        x = Convert.ToInt32( Console.ReadLine());
        y = Convert.ToInt32(Console.ReadLine());
        resolveLabirinto(maze, x, y);
        Console.ReadKey();
    }
}