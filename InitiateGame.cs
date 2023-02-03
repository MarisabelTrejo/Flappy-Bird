using Raylib_cs;
using System.Numerics;

class Floppy {

    Random Rdm = new Random();


    public void Play() {

        // The size of the players screen
        var ScreenHeight = 720;
        var ScreenWidth = 1280; 

        // This will initiate the window opening 
        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Floppy");
        // The frames per second
        Raylib.SetTargetFPS(60);

        // dedclaring variables.
        var Player = new Player();
        var Title = new GameText("Score:", Color.WHITE);
        var Objects = new List<GameObject>();


        
        // Player position
        Player.Position = new Vector2(200, 200);
        Title.Position = new Vector2(20);

        // Add the objects to the screen
        Objects.Add(Player);
        Objects.Add(Title);

        int count = 0;

        // Keep window open 
        while (!Raylib.WindowShouldClose())
        {   
            // Keep drawing while window is open
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLUE);

            // Draw all of the objects in their current location
            foreach (var obj in Objects) {
                obj.Draw();
            }

            
            if (count == 150){
                // Have the rectangles be random sized
                Random newRandom = new Random();
                // Each gap should be 150 pixels 
                int Gap = 150;
                // Set the random height and gaps between the rectangles
                int RandomHeight = newRandom.Next(ScreenHeight/2);
                var TopRectangle = new GameRectangle(ScreenWidth ,0 , 100, RandomHeight,  Color.GREEN);
                int BottomHeight = ScreenHeight - (Gap + RandomHeight);
                var BottomRectangle = new GameRectangle(ScreenWidth , Gap + RandomHeight, 100, BottomHeight,  Color.GREEN);
                

                // Generate a rectangle that is screenheight/2 
                TopRectangle.Velocity = new Vector2(-2, 0);
                BottomRectangle.Velocity = new Vector2(-2, 0);

                // Add the objects to the the screen 
                Objects.Add(TopRectangle);
                Objects.Add(BottomRectangle);
                count = 0;
            }

            // Check if bird is on any of the shapes
            foreach (var obj in Objects) {
                if (obj is GameRectangle) {
                    var shape = (GameRectangle)obj;
                    if (Raylib.CheckCollisionRecs(Player.Rect(), shape.Rect())) {
                    
                        Raylib.CloseWindow();
                    }
                }
            }

            Raylib.EndDrawing();

            // Move all of the objects to their next location
            foreach (var obj in Objects) {
                obj.Move();
            }
            count ++;
        }
    }

}