using Raylib_cs;

// Skriv psuedokod å grejer

Raylib.InitWindow(1200, 800, "IDunno"); // 1000 = bredden 800 = höjden
Raylib.SetTargetFPS(60);


string Level = "Start";
//Color LightGray = new Color(245, 245, 245, 0);
//Color LightBlue = new Color(137, 207, 240, 0);

Rectangle Avatar = new Rectangle(0, 400, 40, 40);
Rectangle one = new Rectangle (0, 600, 1200, 200);


while (Raylib.WindowShouldClose() == false)
{
        if (Level == "Start")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)) //När man trycker ENTER startar level 1
        {
            Level = "Spel";
        }
     }


Raylib.BeginDrawing();

if (Level == "Start")
{ 
    Raylib.ClearBackground(Color.LIGHTGRAY);
    Raylib.DrawText("START", 425, 300, 100, Color.BLACK);
    Raylib.DrawText("Press ENTER to play", 425, 650, 30, Color.BLACK);

}

if (Level == "Spel")
{
    Raylib.ClearBackground(Color.LIGHTGRAY);
    Raylib.DrawRectangleRec(Avatar, Color.BLACK);
    Raylib.DrawRectangleRec(one, Color.VIOLET);
}

Raylib.EndDrawing();

}