using Godot;

public partial class Player : Area2D
{
  [Export] public int Speed = 400;
  public Vector2 ScreenSize;

  public override void _Ready()
  {
    Hide();
    ScreenSize = GetViewportRect().Size;
  }

  public override void _Process(double delta)
  {
    Vector2 velocity = Vector2.Zero;
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

    if (velocity.X != 0)
    {
      sprite.Animation = "walk";
      sprite.FlipV = false;
      sprite.FlipH = velocity.X < 0;
    }
    else if (velocity.Y != 0)
    {
      sprite.Animation = "up";
      sprite.FlipV = velocity.Y > 0;
    }
    if (velocity.X < 0)
    {
      sprite.FlipH = true;
    }
    else
    {
      sprite.FlipH = false;
    }
  }
}
