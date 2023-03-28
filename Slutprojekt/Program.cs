using Raylib_cs;
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
Rectangle star = new Rectangle(1150, 400, Avatar.width, Avatar.height);
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
     if (Level == "Spel")
     {
        if (Raylib.CheckCollisionRecs(avatar, star))
        {
            Level = "Spel2";
            points++;
        }
     }
     if (Level == "Spel")
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
    Raylib.DrawTexture(Avatar, (int)avatar.x, (int)avatar.y, Color.WHITE);
    Raylib.DrawTexture(Star, (int)star.x, (int)star.y, Color.YELLOW);
    Raylib.DrawRectangleRec(one, Color.VIOLET);
    Raylib.DrawText(points.ToString(), 50, 50, 50, Color.BLACK);
}
if (Level == "Spel2")
{
        Raylib.ClearBackground(Color.LIGHTGRAY);
    Raylib.DrawTexture(Avatar, (int)avatar.x, (int)avatar.y, Color.WHITE);
    Raylib.DrawTexture(Star, (int)star.x, (int)star.y, Color.YELLOW);
    Raylib.DrawText(points.ToString(), 50, 50, 50, Color.BLACK);
}

Raylib.EndDrawing();

}
