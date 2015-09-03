using System;
using System.Collections.Generic;
using System.Threading;

class DwarfRocks
{
    // Game constants
    const string stoneTypes = "^@*&+%$#!.;";
    const int fieldMaxX = 40;
    const int fieldMaxY = 30;

    static List<GameObject> objectList = new List<GameObject>();    // List of all GameObjects
    static int score = 0;                                           // Curent score
    static int playerLives = 5;
    static int nmbrStoneMax = 20;
    static int nmbrStone = 0;                                       // Number of Stones on the screen
    static bool isFieldChanged = false;                             // Flag to redraw objects if something changed
    static Random randGen = new Random(DateTime.Now.Millisecond);   // Init random generator - only one for the program

    // GameObject structure
    public struct GameObject
    {
        public int posX;                                            // Current position X of th object
        public int posY;                                            // Current position Y of th object
        public ConsoleColor foreColor;
        public ConsoleColor backColor;
        public string type;                                         // Object type
        public string label;                                        // String to display
        public int SizeOfLabel { get { return label.Length; } }     // Size of the label
        public DateTime lastPrintedTime;                            // Store the time when object has printed for the last time
        public int printSpeed;                                      // Waiting interval since last printed object time
    }

    // Start of the program - main loop of the game
    static void Main()
    {
        InitializeGame();       // Set initial game data

        // Main loop
        while (true)
        {
            GenerateStones();               // Generate random stones at line 0

            if (CheckObjectCollisions())    // Check for collisions
            {
                if (playerLives > 0)        // Decrease lives of player if > 0
                {
                    playerLives--;
                    Thread.Sleep(1000);
                }
                else
                {
                    GameOver();             // If no more lives - GAME OVER
                }
            }

            DrawObjects();                  // Draw all game objects

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                ProcessKeyAction(key);      // Manage all key pressed
            }

            ProcessOtherAction();           // Manage all actions diferent then press key
        }
    }

    // 
    private static void GameOver()
    {
        nmbrStone = 0;

        for (int i = 0; i < objectList.Count; i++)
        {
            // For all objects
            GameObject obj = objectList[i];

            if (obj.type == "STONE" || obj.type == "DWARF")
            {
                objectList.Remove(obj);
                i--;
            }
        }

        objectList.Add(new GameObject               // Print Game Over
        {
            posX = fieldMaxX / 2 - 5,
            posY = fieldMaxY / 2 - 3,
            foreColor = ConsoleColor.Red,
            backColor = ConsoleColor.Black,
            label = "GAME OVER",
            type = "GAMEOVER"
        });
    }

    // Check objects for colisions
    private static bool CheckObjectCollisions()
    {
        GameObject dwarf = objectList.Find(delegate(GameObject obj) { return obj.type == "DWARF"; });

        for (int i = 0; i < objectList.Count; i++)
        {
            // For all objects
            GameObject obj = objectList[i];

            if (obj.type == "STONE")
            {
                if ((dwarf.posY == obj.posY) &&
                    ((dwarf.posX <= obj.posX && obj.posX <= dwarf.posX + dwarf.SizeOfLabel - 1) ||
                    (dwarf.posX <= obj.posX + obj.SizeOfLabel - 1 && obj.posX + obj.SizeOfLabel - 1 <= dwarf.posX + dwarf.SizeOfLabel - 1)
                    ))
                {
                    objectList.Remove(obj);     // Remove object if collision
                    isFieldChanged = true;
                    nmbrStone--;
                    return true;
                }
            }
        }

        return false;                           // No collisions
    }

    // Initialize game's world with initial data
    private static void InitializeGame()
    {
        Console.SetWindowSize(fieldMaxX, fieldMaxY);            // Set console window size
        Console.SetBufferSize(fieldMaxX, fieldMaxY);            // Set console window buffer size
        Console.CursorVisible = false;                          // Cursor will be invisible
        Console.Title = "DwarfRocks";

        // Create and add Dwarf to the game's world
        objectList.Add(new GameObject
        {
            posX = fieldMaxX / 2 - 1,
            posY = fieldMaxY - 3,
            foreColor = ConsoleColor.Blue,
            backColor = ConsoleColor.Black,
            label = "(o)",
            type = "DWARF"
        });

        // Create and add lives count object to the game's world
        objectList.Add(new GameObject
        {
            posX = 0,
            posY = fieldMaxY - 2,
            foreColor = ConsoleColor.Blue,
            backColor = ConsoleColor.DarkYellow,
            label = (" Lives : " + playerLives).PadRight(fieldMaxX / 2, ' '),
            type = "LIVES"
        });

        // Create and add score count object to the game's world
        objectList.Add(new GameObject
        {
            posX = fieldMaxX / 2,
            posY = fieldMaxY - 2,
            foreColor = ConsoleColor.Blue,
            backColor = ConsoleColor.DarkYellow,
            label = ("Score : " + score).PadLeft(fieldMaxX / 2, ' ') + " ",
            type = "SCORE"
        });

        // Create and add info object to the game's world
        objectList.Add(new GameObject
        {
            posX = fieldMaxX / 2 - 5,
            posY = fieldMaxY - 1,
            foreColor = ConsoleColor.Blue,
            backColor = ConsoleColor.Black,
            label = ("DwarfRocks"),
            type = "INFO"
        });
    }

    // Generate stones objects and add them to the game's world
    private static void GenerateStones()
    {
        if (nmbrStone < nmbrStoneMax && playerLives > 0)                    // Create stone object only if player is alive and stones number is less then limit
        {
            int stoneNumber = randGen.Next(0, 5);                           // Random stones per line - max 4

            for (int i = 0; i < stoneNumber; i++)
            {
                char stoneChar = stoneTypes[randGen.Next(0, stoneTypes.Length)];    // Get a symbol for the stone
                int stoneWidth = randGen.Next(1, 4);

                objectList.Add(new GameObject                                       // Add stone to the game's world
                {
                    posX = randGen.Next(0, fieldMaxX - stoneWidth + 1),
                    posY = 0,
                    foreColor = (ConsoleColor)randGen.Next(1, 16),
                    backColor = ConsoleColor.Black,
                    label = new string(stoneChar, stoneWidth),
                    type = "STONE",
                    lastPrintedTime = DateTime.Now,                                 // Store the time of creation ot the object
                    printSpeed = randGen.Next(100, 700)                             // Speed of stone
                });

                nmbrStone++;
                isFieldChanged = true;
            }
        }
    }

    // Manage all actions diferent then press key
    private static void ProcessOtherAction()
    {
        for (int i = 0; i < objectList.Count; i++)
        {
            // For all objects
            GameObject obj = objectList[i];

            // Process stones
            if (obj.type == "STONE")
            {
                if (obj.posY < fieldMaxY - 3)           // Move the stone if it is not the end of field
                {
                    if ((DateTime.Now - obj.lastPrintedTime).Milliseconds >= obj.printSpeed)
                    {
                        obj.posY++;
                        obj.lastPrintedTime = DateTime.Now;
                        objectList[i] = obj;
                        isFieldChanged = true;
                    }
                }
                else
                {
                    // Increase score if stone is out of the game area
                    score = score + obj.SizeOfLabel;
                    objectList.Remove(obj);
                    isFieldChanged = true;
                    nmbrStone--;
                    i--;
                }
            }
            // Prosess Lives
            else if (obj.type == "LIVES")
            {
                obj.label = (" Lives : " + playerLives).PadRight(fieldMaxX / 2, ' ');
                objectList[i] = obj;
            }
            // Process Score
            else if (obj.type == "SCORE")
            {
                obj.label = ("Score : " + score + " ").PadLeft(fieldMaxX / 2, ' ');
                objectList[i] = obj;
            }
        }
    }

    // Manage all key pressed
    private static void ProcessKeyAction(ConsoleKeyInfo key)
    {
        for (int i = 0; i < objectList.Count; i++)
        {
            // For all objects
            GameObject obj = objectList[i];

            // Move DWARF
            if (obj.type == "DWARF")
            {
                if (key.Key == ConsoleKey.LeftArrow && obj.posX > 0)
                {
                    obj.posX--;
                    isFieldChanged = true;
                }

                if (key.Key == ConsoleKey.RightArrow && obj.posX + obj.SizeOfLabel < fieldMaxX)
                {
                    obj.posX++;
                    isFieldChanged = true;
                }

                if (key.Key == ConsoleKey.UpArrow && obj.posY > 0)
                {
                    obj.posY--;
                    isFieldChanged = true;
                }

                if (key.Key == ConsoleKey.DownArrow && obj.posY < fieldMaxY - 3)
                {
                    obj.posY++;
                    isFieldChanged = true;
                }
            }

            // For all objects
            if (key.Key == ConsoleKey.Escape)           // Press "ESC" to exit the game
            {
                Environment.Exit(0);
            }

            if (key.Key == ConsoleKey.Spacebar)         // Press "Space" for new game if game is over
            {
                objectList = new List<GameObject>();
                playerLives = 5;
                score = 0;
                InitializeGame();
            }

            objectList[i] = obj;
        }
    }

    // Draw all game objects
    private static void DrawObjects()
    {
        if (isFieldChanged == true)
        {
            Console.Clear();

            foreach (var obj in objectList)
            {
                ConsoleColor tmpColor = Console.BackgroundColor;
                Console.ForegroundColor = obj.foreColor;
                Console.BackgroundColor = obj.backColor;
                Console.SetCursorPosition(obj.posX, obj.posY);
                Console.Write(obj.label);
                Console.BackgroundColor = tmpColor;
            }

            isFieldChanged = false;
        }
    }
}