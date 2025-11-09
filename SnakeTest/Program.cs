List<int> snakeTrackY = [];
List<int> snakeTrackX = [];

int snakeHeadPosY = 5; // Y = Up/Down
int snakeHeadPosX = 3; // X = Left/Right

bool keyPressed = false;

// Top left (X/Y), top right, bottom left, bottom right
int[] playableArea = {5, 2, 5, 128, 28, 2, 128, 28 };

int speedMs = 200;

// axis 1 = -x, axis 2 = +x, axis 3 = -y, axis 4 = +y
int axis = 2;

string snakeBody = "▓";
string snakeFood = "@";
int availableFood = 0;

int foodLocationX = 0;
int foodLocationY = 0;
int snakeLength = 1;
int score = snakeLength - 1;

int windowWidth = Console.WindowWidth;
int windowHeight = Console.WindowHeight;

Console.CursorVisible = false;

//Console Width: 120, Console Height: 30

//Draws scoreboard border top
Console.SetCursorPosition(0, 0);
Console.WriteLine("╔" + new string('═', windowWidth - 2) + "╗");
Console.SetCursorPosition(0, 1);
Console.WriteLine("║" + new string(' ', windowWidth - 2) + "║");
Console.SetCursorPosition(0, 2);
Console.WriteLine("║" + new string(' ', windowWidth - 2) + "║");

//Draws top border
Console.SetCursorPosition(0,3);
Console.WriteLine("╠" + new string('═', windowWidth -2) + "╣");

//Draws side borders
for(int i = 4; i < windowHeight - 1; i++)
{
    Console.SetCursorPosition(0, i);
    Console.Write("║" + new string(' ', windowWidth -2) + "║");
    
}

//Draws bottom border
Console.SetCursorPosition(0, windowHeight -1);
Console.Write("╚" + new string('═', windowWidth -2) + "╝");


while (true)
{
    //Die when you hit the wall
    //Weird behavior? Have to use weird numbers. Something weird about the math.
    //Console Width: 120, Console Height: 30
    if (snakeHeadPosY == 3 || snakeHeadPosY == 30 || snakeHeadPosX == -1 || snakeHeadPosX == 118)
    {
        Console.Write("You lost!");
        break;
    }

    //Draw Scoreboard, add better UI later
    Console.SetCursorPosition(1, 1);
    Console.Write($"Score: {snakeLength - 1}");


    if (availableFood == 0)
    {
        Random rand = new Random();
        foodLocationY = rand.Next(4, 29);
        foodLocationX = rand.Next(-1, 118);

        availableFood++;
    }

    if(snakeHeadPosX == foodLocationX && snakeHeadPosY == foodLocationY)
    {
        availableFood--;
        snakeLength++;
    }

    
    //Debug Position
    //Console.Write($"Position X: {snakeHeadPosX}; Position Y: {snakeHeadPosY}\n");
    //Console.Write($"Window Width: {windowWidth}; Window height: {windowHeight}");

    Thread.Sleep(speedMs);
    Console.SetCursorPosition(foodLocationX, foodLocationY);
    Console.Write(snakeFood);
    Console.SetCursorPosition(snakeHeadPosX, snakeHeadPosY);

    //Adds cordinates to list
    snakeTrackX.Add(snakeHeadPosX);
    snakeTrackY.Add(snakeHeadPosY);
    
    if(snakeTrackX.Count > snakeLength)
    {
        snakeTrackX.RemoveAt(0);
        snakeTrackY.RemoveAt(0);
        
        Console.SetCursorPosition(snakeTrackX[0], snakeTrackY[0]);
        Console.Write(" ");
    }

    Console.Write(snakeBody);


    //Runs every time
    if (keyPressed == false)
    {
        if (axis == 1)
        {
            snakeHeadPosX--;
        }
        else if (axis == 2) 
        {
            snakeHeadPosX++;
        }
        else if(axis == 3)
        {
            snakeHeadPosY--;
        }
        else if(axis == 4)
        {
            snakeHeadPosY++;
        }
    }

    if (Console.KeyAvailable)
    {
        
        var k = Console.ReadKey(true);
        if (k.Key == ConsoleKey.S)
        {
            axis = 4;
            keyPressed = false;
            continue;
        }
        else if (k.Key == ConsoleKey.W)
        {
            axis = 3;
            keyPressed = false;
        }
        else if (k.Key == ConsoleKey.A)
        {
            axis = 1;
            keyPressed = false;
        }
        else if (k.Key == ConsoleKey.D)
        {
            axis = 2;
            keyPressed = false;
        }
    }
}