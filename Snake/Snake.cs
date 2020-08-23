using System;
using System.Runtime.InteropServices;
using System.Threading;

class Snake
{
    public int WidthBoard { get; set; }
    public int HeightBoard { get; set; }
    private int[] x = new int[80];
    private int[] y = new int[80];
    public ConsoleKeyInfo keyInfo;
    private char ch;
    public int SnakeLength;
    private int FruitX;
    private int FruitY;
    private Random rnd = new Random();
    public Snake()
    {
        x[0] = 3;
        y[0] = 3;
        SnakeLength = 3;
        WidthBoard = 60;
        HeightBoard = 20;
        FruitX = rnd.Next(3, WidthBoard);
        FruitY = rnd.Next(3, HeightBoard);
        Console.CursorVisible = false;
    }
    public void DrawBoard()
    {
        Console.Clear();
        for (int i = 1; i < WidthBoard; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write("-");
        }
        for (int i = 1; i < HeightBoard; i++)
        {
            Console.SetCursorPosition(1, i);
            Console.Write("|");
        }
        for (int i = 1; i < HeightBoard; i++)
        {
            Console.SetCursorPosition(WidthBoard, i);
            Console.Write("|");
        }
        for (int i = 1; i < WidthBoard; i++)
        {
            Console.SetCursorPosition(i, HeightBoard);
            Console.Write("-");
        }
    }
    public void InputKey()
    {
        if (Console.KeyAvailable)
        {
            keyInfo = Console.ReadKey(true);
            ch = keyInfo.KeyChar;
        }
    }
    public void DrawSnake(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write("*");
    }
    public void PlusSymb(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write("*");
    }
    public void LogicGame()
    {
        if (x[0] == FruitX)
        {
            if (y[0] == FruitY)
            {
                SnakeLength++;
                FruitX = rnd.Next(3, WidthBoard);
                FruitY = rnd.Next(5, HeightBoard);
            }
        }
        for (int i = SnakeLength; i > 1; i--)
        {
            x[i - 1] = x[i - 2];
            y[i - 1] = y[i - 2];
        }
        switch (ch)
        {
            case 'w':
                y[0]--;
                break;
            case 'a':
                x[0]--;
                break;
            case 's':
                y[0]++;
                break;
            case 'd':
                x[0]++;
                break;
        }
        for(int i = 0; i<SnakeLength; i++)
        {
            DrawSnake(x[i], y[i]);
            PlusSymb(FruitX, FruitY);
        }
        Thread.Sleep(100);
    }
}