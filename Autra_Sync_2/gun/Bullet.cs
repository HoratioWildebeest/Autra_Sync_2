using Godot;
using System;

public class Bullet : Area
{
   [Export] public float Lifetime = 1f;
   [Export] public float Speed = 40f;
   [Export] public int Damage = 1;

   public Vector3 MoveDirection = Vector3.Forward;

   public override void _Ready() {

   }

   public override void _PhysicsProcess(float delta) {
      Translate(MoveDirection * Speed * delta);

      Lifetime -= delta;
      if (Lifetime <= 0f) {
         Destroy();
      }
   }

   void Destroy() {
      QueueFree();
   }
}
