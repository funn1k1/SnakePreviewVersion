using System;
class Game
{
    static void Main()
    {
        Snake snake = new Snake();
        while (true)
        {
            snake.DrawBoard();
            snake.InputKey();
            snake.LogicGame();
        }
    }
}