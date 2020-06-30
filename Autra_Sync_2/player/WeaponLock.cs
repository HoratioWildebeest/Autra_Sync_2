using Godot;
using System;

public class WeaponLock : Spatial {
   //PackedScene _bulletScene = ResourceLoader.Load<PackedScene>("res://gun/Bullet.tscn");
   PackedScene _bulletScene = ResourceLoader.Load<PackedScene>("res://gun/AoEBullet.tscn");

   public void UseWeapon() {
      Shoot(GlobalTransform);
   }

   public void Shoot(Transform transform) {
      Bullet bullet = _bulletScene.Instance() as Bullet;
      GetTree().CurrentScene.AddChild(bullet);
      bullet.GlobalTransform = transform;
   }
}