using Godot;
using System;

public class GenericTarget : Area
{
   [Export] public int Health = 10;

   public override void _Ready() {
      Connect("area_entered", this, "_OnHitboxAreaEntered");
   }

   public void TakeDamage(int damage) {
      Health -= damage;
      if (Health <= 0) {
         Destroy();
      }
   }

   void Destroy() {
      QueueFree();
   }

   public void _OnHitboxAreaEntered(Area area) {
      if (area is Bullet) {
         Bullet bullet = area as Bullet;
         TakeDamage(bullet.Damage);
      }
   }
}
