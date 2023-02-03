using Raylib_cs;
using System.Numerics;

interface Shape {

    public string Name();
    public float Area();
    public Rectangle Rect();
}

class GameObject {
    
    public Vector2 Position { get; set; } = new Vector2(0, 0);
    public Vector2 Velocity { get; set; } = new Vector2(0, 0);

    virtual public void Draw() {
        // Base game objects do not have anything to draw
    }

    virtual public void Move() {
        Vector2 NewPosition = Position;
        NewPosition.X += Velocity.X;
        NewPosition.Y += Velocity.Y;
        Position = NewPosition;
    }
}


class ColoredObject: GameObject {
    public Color Color { get; set; }

    public ColoredObject(Color color) {
        Color = color;
    }
}

class GameRectangle: ColoredObject {
    // Declaring the height and width
    int Width;
    int Height;
    // I am giving the rectangle heigh width and color
    public GameRectangle(int x, int y, int width, int height, Color color): base(color) {
        var NewPosition = new Vector2(x , y);
        Position = NewPosition;

        Width = width;
        Height = height;
        // I want a random height 
    }
    public Rectangle Rect() {
        // The rectangle will be able to be placed with a certain size
        return new Rectangle(Position.X, Position.Y, Width, Height);
    }

    override public void Draw() {
        // Draw rectangle when called
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, Width, Height, Color);
        
    }
    
}

class GameText: ColoredObject {
    string Text;

    public GameText(string text, Color color): base(color) {
        Text = text;
    }

    public override void Draw() {
        Raylib.DrawText(this.Text, (int)Position.X, (int)Position.Y, 20, this.Color);
    }
}