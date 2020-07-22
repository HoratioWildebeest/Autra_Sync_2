using Godot;
using Array = Godot.Collections.Array;
using System;

class AoEBullet : Bullet {
   [Export] new public float Gravity = .02f;
   
   Area explosionHitbox;
   RayCast explodeConnectionCheck;

   public override void _Ready() {
      explosionHitbox = GetNode<Area>("Explosion");
      explodeConnectionCheck = GetNode<RayCast>("RayCast");
   }

   public override void _PhysicsProcess(float delta) {
      MoveDirection.y -= Gravity;
      Translate(MoveDirection * Speed * delta);

      Lifetime -= delta;
      if (Lifetime <= 0f) {
         Explode();
      }
   }

   void Explode() {
      Array affected = explosionHitbox.GetOverlappingAreas();
      for (int i = 0; i < affected.Count; i++) {
         if (affected[i] is GenericTarget) {
            GenericTarget target = affected[i] as GenericTarget;
            target.TakeDamage(Damage);
         }
      }

      QueueFree();
   }

   public void _onBodyEntered(PhysicsBody body) {
      if (!(body is Player)) {
         Explode();
      }
   }
}
