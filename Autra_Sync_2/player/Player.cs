using Godot;
using System;

public class Player : KinematicBody {
   [Export] public float Gravity = 1f;
   [Export] public float Speed = 10f;
   [Export] public float JumpSpeed = 24f;

   const float FLOOR_GRAVITY = .01f;

   CameraLock CameraLock;
   WeaponLock WeaponLock;
   Spatial Mesh;

   Vector3 _moveDirection = new Vector3();
   bool _jumping = false;
   bool isShooting = false;
   Vector3 _velocity = new Vector3();

   public override void _Ready() {
      CameraLock = GetNode<CameraLock>("CameraLock");
      WeaponLock = GetNode<WeaponLock>("CameraLock/WeaponLock");
   }

   public override void _PhysicsProcess(float delta) {
      if (IsOnFloor()) {
         _velocity.y = FLOOR_GRAVITY;
         DoJump();
      } else {
         _velocity.y -= Gravity;
      }

      DoMove();
      _velocity = MoveAndSlide(_velocity, Vector3.Up);
   }

   public override void _UnhandledInput(InputEvent pEvent) {
      bool isMouseEvent = pEvent is InputEventMouse; 

      if (!isMouseEvent) {
         InputMovement();
      }

      if (Input.IsActionJustPressed("jump")) {
         _jumping = true;
      } else if (Input.IsActionJustReleased("jump")) {
         _jumping = false;
      }

      if (Input.IsActionJustPressed("shoot")) {
         isShooting = true;
         WeaponLock.UseWeapon();
      } else if (Input.IsActionJustReleased("shoot")) {
         isShooting = false;
      }
   }

   public bool IsMoving() {
      return _moveDirection != Vector3.Zero;
   }

   public bool IsJumping() {
      var collision = MoveAndCollide(new Vector3(0f, -.1f, 0f), false, true, true);
      return collision is null;
   }

   public bool IsShooting() {
      return isShooting;
   }

   void InputMovement() {
      _moveDirection = Vector3.Zero;
      Basis cameraBasis = CameraLock.Transform.basis;

      if (Input.IsActionPressed("move_right")) {
         _moveDirection += cameraBasis.x;
      }
      if (Input.IsActionPressed("move_left")) {
         _moveDirection -= cameraBasis.x;
      }
      if (Input.IsActionPressed("move_up")) {
         _moveDirection -= cameraBasis.z;
      }
      if (Input.IsActionPressed("move_down")) {
         _moveDirection += cameraBasis.z;
      }
      _moveDirection.y = 0f;
      _moveDirection = _moveDirection.Normalized();
   }

   void DoJump() {
      if (_jumping) {
         _velocity.y += JumpSpeed;
      }
   }

   void DoMove() {
      _velocity.x = _moveDirection.x * Speed;
      _velocity.z = _moveDirection.z * Speed;
   }
}
