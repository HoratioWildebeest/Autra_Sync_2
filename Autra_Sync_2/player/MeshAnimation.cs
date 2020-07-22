using Godot;
using System;

public class MeshAnimation : AnimationPlayer
{
   [Export]
   public NodePath PlayerPath;

   Player player;
   string lastAnimation = "";

   public override void _Ready() {
      player = GetNode<Player>(PlayerPath);
   }

   public override void _Process(float delta) {
      if (player.IsJumping()) {
         if (IsShooting()) {
            PlayAnimation("JumpShoot");
         } else {
            PlayAnimation("Jump");
         }
      } else if (player.IsMoving()) {
         if (IsShooting()) {
            PlayAnimation("RunShoot");
         } else {
            PlayAnimation("Run");
         }
      } else {
         if (IsShooting()) {
            PlayAnimation("StandShoot");
         } else {
            PlayAnimation("Stand");
         }
      }
   }

   bool IsShooting() {
      return player.IsShooting();
   }

   void PlayAnimation(string animation) {
      if (lastAnimation != animation) {
         lastAnimation = CurrentAnimation;
         Play(animation);
      }
   }

   public void _on_AnimationPlayer_animation_finished(string animation) {
      
   }
}
