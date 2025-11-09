List<int> snakeTrackY = new List<int> { };
List<int> snakeTrackX = new List<int> { };

int snakeHeadPosY = 3; // Y = Up/Down
int snakeHeadPosX = 1; // X = Left/Right

int scoreBoxY = 0;
int scoreBoxX = 0;

int borderBoxY = 3;
int borderBoxX = 0;
bool keyPressed = false;

int speedMs = 200;

// axis 1 = -x, axis 2 = +x, axis 3 = -y, axis 4 = +y
int axis = 2;

string snakeBody = "▓";
string snakeFood = "@";
string borderChar = "║";
int availableFood = 0;

int foodLocationX = 0;
int foodLocationY = 0;
int snakeLength = 1;
int score = snakeLength - 1;

int windowWidth = Console.WindowWidth;
int windowHeight = Console.WindowHeight;

Console.CursorVisible = false;

while (true)
{
    //Die when you hit the wall
    if (snakeHeadPosX == windowWidth - 1 || snakeHeadPosY == windowHeight - 1 || snakeHeadPosY < 0 || snakeHeadPosX < 0)
    {
        Console.Write("You lost!");
        break;
    }

    if(borderBoxX < windowWidth)
    {
        //Not working as intended, fixing later
        //Draw borders

        //Console.SetCursorPosition(borderBoxX, borderBoxY);
        //Console.Write("║");
        //borderBoxY++;
    }

    //Draw Scoreboard, add better UI later
    Console.SetCursorPosition(1, 1);
    Console.Write($"Score: {snakeLength - 1}");


    if (availableFood == 0)
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
            keyPressed = true;
            axis = 4;
            keyPressed = false;
            continue;
        }
        else if (k.Key == ConsoleKey.W)
        {
            keyPressed = true;
            axis = 3;
            keyPressed = false;
        }
        else if (k.Key == ConsoleKey.A)
        {
            keyPressed = true;
            axis = 1;
            keyPressed = false;
        }
        else if (k.Key == ConsoleKey.D)
        {
            keyPressed = true;
            axis = 2;
            keyPressed = false;
        }
    }
}