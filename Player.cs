using Godot;

public partial class Player : Area2D
{
    [Export] public int Speed = 400;
    public Vector2 ScreenSize;

    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
    }

    public override void _Process(double delta)
    {
        var velocity = Vector2.Zero;
        var sprite = GetNode<AnimatedSprite2D>("Sprite");

        if (Input.IsActionPressed("MoveRight"))
        {
            velocity.X += 1;
        }
        if (Input.IsActionPressed("MoveLeft"))
        {
            velocity.X -= 1;
        }
        if (Input.IsActionPressed("MoveDown"))
        {
            velocity.Y += 1;
        }
        if (Input.IsActionPressed("MoveUp"))
        {
            velocity.Y -= 1;
        }
        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
            sprite.Play();
        }
        else
        {
            sprite.Stop();
        }

        Position += velocity * (float)delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
            y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
        );
    }
}
