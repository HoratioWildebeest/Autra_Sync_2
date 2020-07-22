using Godot;
using System;

public class CameraLock : Spatial {
   [Export] public float MouseLookDelay = .2f;
   [Export] public float MouseLookDeadzoneX = 20f;
   [Export] public float MouseLookDeadzoneY = 25f;
   [Export] public float JoypadLookDelay = .15f;

   [Export] public NodePath MeshPath;

   InputManager inputManager;
   Spatial Mesh;

   Vector2 _inputDirection = new Vector2();
   RotationGrid _rotationGrid = new RotationGrid();
   float _mouseLookDelayTime = Mathf.Inf;
   float joypadLookDelayTime = Mathf.Inf;

   public override void _Ready() {
      inputManager = GetTree().Root.GetNode<InputManager>("InputManager");
      Mesh = GetNode<Spatial>(MeshPath);

      Input.SetMouseMode(Input.MouseMode.Captured);
   }

   public override void _PhysicsProcess(float delta) {
      if (_mouseLookDelayTime < MouseLookDelay) {
         _mouseLookDelayTime += delta;
         if (_mouseLookDelayTime >= MouseLookDelay) {
            _mouseLookDelayTime = Mathf.Inf;
         }
      }

      if (joypadLookDelayTime < JoypadLookDelay) {
         joypadLookDelayTime += delta;
         if (joypadLookDelayTime >= JoypadLookDelay) {
            joypadLookDelayTime = Mathf.Inf;
         }
      }

      if (!inputManager.IsKeyboardMode()) {
         HandleJoypad();
      }
   }

   public override void _UnhandledInput(InputEvent @event) {
      if (inputManager.IsKeyboardMode()) {
         if (@event is InputEventMouseMotion) {
            HandleMouseMotion(@event);
         } else {
            // For keyboard camera motion
            if (Input.IsActionJustPressed("camera_right")) {
               _inputDirection.x = 1;
            }
            if (Input.IsActionJustPressed("camera_left")) {
               _inputDirection.x = -1;
            }
            if (Input.IsActionJustPressed("camera_up")) {
               _inputDirection.y = 1;
            }
            if (Input.IsActionJustPressed("camera_down")) {
               _inputDirection.y = -1;
            }

            if (_inputDirection != Vector2.Zero) {
               Look();
               _inputDirection = Vector2.Zero;
            }
         }
      }
   }

   bool IsDelayInactive(float delay) {
      return delay == Mathf.Inf;
   }

   void HandleMouseMotion(InputEvent e) {
      if (IsDelayInactive(_mouseLookDelayTime)) {
         var motion = e as InputEventMouseMotion;

         bool isPastX = Mathf.Abs(motion.Relative.x) > MouseLookDeadzoneX;
         bool isPastY = Mathf.Abs(motion.Relative.y) > MouseLookDeadzoneY;

         if (isPastX || isPastY) {
            _mouseLookDelayTime = 0f;
            if (isPastX) {
               _inputDirection.x = motion.Relative.x;
            }
            if (isPastY) {
               _inputDirection.y = -motion.Relative.y;
            }
            Look();
         }
      }
   }

   void HandleJoypad() {
      if (IsDelayInactive(joypadLookDelayTime)) {
         joypadLookDelayTime = 0f;
         _inputDirection.x = Input.GetActionStrength("camera_right") - Input.GetActionStrength("camera_left");
         _inputDirection.y = Input.GetActionStrength("camera_up") - Input.GetActionStrength("camera_down");
         Look();
      }
   }

   void Look() {
      int x = Mathf.Sign(_inputDirection.x);
      int y = Mathf.Sign(_inputDirection.y);

      if (x == 1) {
         _rotationGrid.LookRight();
      } else if (x == -1) {
         _rotationGrid.LookLeft();
      }

      if (y == 1) {
         _rotationGrid.LookUp();
      } else if (y == -1) {
         _rotationGrid.LookDown();
      }

      if (x != 0 || y != 0) {
         Transform = Transform.LookingAt(_rotationGrid.LookOn, Vector3.Up);

         Vector3 meshLook = -_rotationGrid.LookOn;
         meshLook.y = 0f;
         Mesh.Transform = Transform.LookingAt(meshLook, Vector3.Up);
      }
   }
}
