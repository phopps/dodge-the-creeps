using Godot;

public partial class Mob : RigidBody2D
{
  public override void _Ready()
  {
    AnimatedSprite2D sprite = GetNode<AnimatedSprite2D>("Sprite");
    string[] mobTypes = sprite.SpriteFrames.GetAnimationNames();
    sprite.Play(mobTypes[GD.Randi() % mobTypes.Length]);
  }

  private void OnNotifierScreenExited()
  {
    QueueFree();
  }
}
