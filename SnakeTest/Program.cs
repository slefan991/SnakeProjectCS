int snakeHeadPosY = 3; // Y = Up/Down
int snakeHeadPosX = 0; // X = Left/Right
bool keyPressed = false;

int speedMs = 200;


// axis 1 = -x, axis 2 = +x, axis 3 = -y, axis 4 = +y
int axis = 2;

string snakeBody = "#";
string snakeFood = "@";
int availableFood = 0;

int foodLocationX = 0;
int foodLocationY = 0;
int snakeLength = 1;

int windowWidth = Console.WindowWidth;
int windowHeight = Console.WindowHeight;

Console.CursorVisible = false;




while (true)
{
    //Collision box
    if (snakeHeadPosX == windowWidth - 1 || snakeHeadPosY == windowHeight - 1 || snakeHeadPosY < 0 || snakeHeadPosX < 0)
    {
        Console.Clear();
        Console.Write("You lost!");
        break;
    }

    if(availableFood == 0)
    {
        Random rand = new Random();
        foodLocationX = rand.Next(0, windowWidth);
        foodLocationY = rand.Next(0, windowHeight);

        availableFood++;

    }

    if(snakeHeadPosX == foodLocationX && snakeHeadPosY == foodLocationY)
    {
        availableFood--;
        snakeLength++;
    }

    

    //Debug Position
    Console.Write($"Position X: {snakeHeadPosX}; Position Y: {snakeHeadPosY}\n");
    Console.Write($"Window Width: {windowWidth}; Window height: {windowHeight}");

    Thread.Sleep(speedMs);
    Console.Clear();
    Console.SetCursorPosition(foodLocationX, foodLocationY);
    Console.Write(snakeFood);
    Console.SetCursorPosition(snakeHeadPosX, snakeHeadPosY);
    Console.Write(snakeBody);


    //Runs every time
    if (keyPressed == false)
    {
        if (axis == 1)
        {
            snakeHeadPosY--;
        }
        else if (axis == 2) 
        {
            snakeHeadPosY++;
        }
        else if(axis == 3)
        {
            snakeHeadPosX--;
        }
        else if(axis == 4)
        {
            snakeHeadPosX++;
        }
    }

    if (Console.KeyAvailable)
    {
        
        var k = Console.ReadKey(true);
        if (k.Key == ConsoleKey.S)
        {
            keyPressed = true;
            axis = 2;
            keyPressed = false;
            continue;

        }
        else if (k.Key == ConsoleKey.W)
        {
            keyPressed = true;
            axis = 1;
            keyPressed = false;
        }
        else if (k.Key == ConsoleKey.A)
        {
            keyPressed = true;
            axis = 3;
            keyPressed = false;
        }
        else if (k.Key == ConsoleKey.D)
        {
            keyPressed = true;
            axis = 4;
            keyPressed = false;
        }
    }
}