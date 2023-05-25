using Raylib_cs;
using System;
using System.Numerics;

// Skriv psuedokod å grejer

Raylib.InitWindow(1200, 800, "IDunno"); // 1200 = bredden 800 = höjden
Raylib.SetTargetFPS(60);

string Level = "Start";
int points = 0;
// Color LightGray = new Color(245, 245, 245, 0);
// Color LightBlue = new Color(137, 207, 240, 0);

Texture2D Avatar = Raylib.LoadTexture("Avatar.png");
float speed = 3f;
Texture2D Star = Raylib.LoadTexture("Star.png");

Rectangle avatar = new Rectangle(0, 400, Avatar.width, Avatar.height); // (0, 400)
//Rectangle avatar2 = new Rectangle(0, 400, Avatar.width, Avatar.height);
Rectangle star = new Rectangle(1150, 400, Star.width, Star.height);
Rectangle star2 = new Rectangle(50, 400, Star.width, Star.height);

Rectangle upp1 = new Rectangle(0, 0, 260, 395);
Rectangle upp2 = new Rectangle(260, 0 , 295, 535);
Rectangle upp3 = new Rectangle(555, 0, 370, 295);
Rectangle upp4 = new Rectangle(925, 0, 275, 395);

Rectangle ner1 = new Rectangle(0, 455, 200, 345);
Rectangle ner2 = new Rectangle(200, 595, 415, 205);
Rectangle ner3 = new Rectangle(615, 355, 250, 445);
Rectangle ner4 = new Rectangle(865, 455, 335, 345);

List<Rectangle> rectangles = new List<Rectangle>(); // Lista med alla rektanglar som skapar banan
rectangles.Add(new Rectangle(0, 0, 260, 395)); 
rectangles.Add(new Rectangle(260, 0 , 295, 535));
rectangles.Add(new Rectangle(555, 0, 370, 295));
rectangles.Add(new Rectangle(925, 0, 275, 395));     // Alla rektanglar på ovansidan

rectangles.Add(new Rectangle (0, 455, 200, 345));
rectangles.Add(new Rectangle(200, 595, 415, 205));
rectangles.Add(new Rectangle(615, 355, 250, 445));
rectangles.Add(new Rectangle(865, 455, 335, 345));   // Alla rektanglar på undersidan



while (Raylib.WindowShouldClose() == false)
{
        if (Level == "Start")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)) //När man trycker ENTER startar level 1
        {
            Level = "Spel";
        }
     }
     if (Level == "Spel")
     {
        if (Raylib.CheckCollisionRecs(avatar, star))
        {
            Level = "Spel2";
            points++;
        }
        else if (Raylib.CheckCollisionRecs(avatar, upp1))
        {
            Level = "GameOver";
        }
        else if (Raylib.CheckCollisionRecs(avatar, upp2))
        {
            Level = "GameOver";
        }
        else if (Raylib.CheckCollisionRecs(avatar, upp3))
        {
            Level = "GameOver";
        }
        else if (Raylib.CheckCollisionRecs(avatar, upp4))
        {
        Level = "GameOver";
        }
        else if (Raylib.CheckCollisionRecs(avatar, ner1))
        {
            Level = "GameOver";
        }
        else if (Raylib.CheckCollisionRecs(avatar, ner2))
        {
            Level = "GameOver";
        }
        else if (Raylib.CheckCollisionRecs(avatar, ner3))
        {
            Level = "GameOver";
        }
        else if (Raylib.CheckCollisionRecs(avatar, ner4))
        {
            Level = "GameOver";
        }
     }

     else if (Level == "Spel2")
     {
        if (Raylib.CheckCollisionRecs(avatar, star2))
        {
            Level = "Slut";
            points++;
        }
     }
     if (Level == "Spel" || Level == "Spel2")
     {
        Vector2 AvatarMovement = new Vector2();

        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP) || Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            AvatarMovement.Y = -speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) || Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            AvatarMovement.Y = +speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) || Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            AvatarMovement.X = +speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) || Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            AvatarMovement.X = -speed;
        }
        
        avatar.x += AvatarMovement.X;
        avatar.y += AvatarMovement.Y;
        //gör så att gubben inte kan gå utanför skärmen
        if (avatar.x < 0 || avatar.x > Raylib.GetScreenWidth() - avatar.width)
        {
            avatar.x -= AvatarMovement.X;
        }
        if (avatar.y < 0 || avatar.y > Raylib.GetScreenHeight() - avatar.height)
        {
            avatar.y -= AvatarMovement.Y;
        }

        Vector2 AvatarPosition = new Vector2(avatar.x, avatar.y); 
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

    foreach (Rectangle rectangle in rectangles)
    {
        Raylib.DrawRectangleRec(rectangle, Color.PURPLE); // foreachloop med min lista av rektanglar

    }

    Raylib.DrawTexture(Avatar, (int)avatar.x, (int)avatar.y, Color.WHITE);
    Raylib.DrawTexture(Star, (int)star.x, (int)star.y, Color.BLACK);
    Raylib.DrawText(points.ToString(), 50, 50, 50, Color.BLACK);
}

if (Level == "Spel2")
{
    Raylib.ClearBackground(Color.LIGHTGRAY);

        foreach (Rectangle rectangle in rectangles)
    {
        Raylib.DrawRectangleRec(rectangle, Color.PURPLE); // foreachloop med min lista av rektanglar

    }

    Raylib.DrawTexture(Avatar, (int)avatar.x, (int)avatar.y, Color.WHITE);
    Raylib.DrawTexture(Star, (int)star2.x, (int)star2.y, Color.BLACK);
    Raylib.DrawText(points.ToString(), 50, 50, 50, Color.BLACK);
}

if (Level == "Slut")
{
    Raylib.ClearBackground(Color.PURPLE);
    Raylib.DrawText("GRATTIS! DU VANN!", 365, 300, 50, Color.BLACK);
    Raylib.DrawText("Du fick " + points + "poäng", 480, 400, 30, Color.BLACK);
}

if (Level == "GameOver")
{
    Raylib.ClearBackground(Color.BLACK);
    Raylib.DrawText("GAME OVER", 300, 300, 100, Color.RED);
}

Raylib.EndDrawing();

}




    // Raylib.DrawRectangleRec(one, Color.LIGHTGRAY);
    // Raylib.DrawRectangleRec(two, Color.LIGHTGRAY);
    // Raylib.DrawRectangleRec(three, Color.LIGHTGRAY);
    // Raylib.DrawRectangleRec(four, Color.LIGHTGRAY);
    // Raylib.DrawRectangleRec(five, Color.LIGHTGRAY);
    // Raylib.DrawRectangleRec(six, Color.LIGHTGRAY);
    // Raylib.DrawRectangleRec(seven, Color.LIGHTGRAY);

    // Raylib.DrawRectangleRec(upp1, Color.PURPLE);
    // Raylib.DrawRectangleRec(upp2, Color.PURPLE);
    // Raylib.DrawRectangleRec(upp3, Color.PURPLE);
    // Raylib.DrawRectangleRec(upp4, Color.PURPLE);

    // Raylib.DrawRectangleRec(ner1, Color.PURPLE);
    // Raylib.DrawRectangleRec(ner3, Color.PURPLE);
    // Raylib.DrawRectangleRec(ner2, Color.PURPLE);
    // Raylib.DrawRectangleRec(ner4, Color.PURPLE);

//Rectangle one = new Rectangle (0, 550, 1200, 300);
// Rectangle one = new Rectangle(0, 395, 200, 60);
// Rectangle two = new Rectangle (200, 395, 60, 200 );
// Rectangle three = new Rectangle(260, 535, 300, 60);
// Rectangle four = new Rectangle(555, 295, 60, 300);
// Rectangle five = new Rectangle(615, 295, 250, 60);
// Rectangle six = new Rectangle(865, 295, 60, 160);
// Rectangle seven = new Rectangle(925, 395, 300, 60);