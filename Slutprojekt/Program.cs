using Raylib_cs;

// Skriv psuedokod å grejer

Raylib.InitWindow(1000, 800, "IDunno"); // 1000 = bredden 800 = höjden
Raylib.SetTargetFPS(60);

//string Level = "Start";

while (Raylib.WindowShouldClose() == false)
{
    //     if (Level == "Start")
    // {
    //     if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)) //När man trycker ENTER startar level 1
    //     {
    //         Level = "Spel";
    //     }
    //  }
}


Raylib.BeginDrawing();

//if (Level == "Start")
//{ 
    Raylib.ClearBackground(Color.WHITE);
    Raylib.DrawText("START", 400, 300, 100, Color.BLACK);

//}

Raylib.EndDrawing();
