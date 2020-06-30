using Godot;
using System;

public class CameraLock : Spatial {
   [Export] public float MouseLookDelay = .2f;
   [Export] public float MouseLookDeadzone = 10f;

   Vector2 _inputDirection = new Vector2();
   RotationGrid _rotationGrid = new RotationGrid();
   float _mouseLookDelayTime = Mathf.Inf;

   public override void _Ready() {
      Input.SetMouseMode(Input.MouseMode.Captured);
   }

   public override void _PhysicsProcess(float delta) {
      if (_mouseLookDelayTime < MouseLookDelay) {
         _mouseLookDelayTime += delta;
         if (_mouseLookDelayTime >= MouseLookDelay) {
            _mouseLookDelayTime = Mathf.Inf;
         }
      }
   }

   public override void _UnhandledInput(InputEvent @event) {
      bool isMouseMotion = @event is InputEventMouseMotion;

      if (isMouseMotion) {
         if (_mouseLookDelayTime == Mathf.Inf) {
            InputEventMouseMotion motion = @event as InputEventMouseMotion;

            bool isPastX = Mathf.Abs(motion.Relative.x) > MouseLookDeadzone;
            bool isPastY = Mathf.Abs(motion.Relative.y) > MouseLookDeadzone;

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
      } else {
         if (Input.IsActionJustPressed("camera_right")) {
            _inputDirection.x += 1;
         }
         if (Input.IsActionJustPressed("camera_left")) {
            _inputDirection.x -= 1;
         }
         if (Input.IsActionJustPressed("camera_up")) {
            _inputDirection.y += 1;
         }
         if (Input.IsActionJustPressed("camera_down")) {
            _inputDirection.y -= 1;
         }
         Look();
      }
   }

   void Look() {
      int x = Mathf.Sign(_inputDirection.x);
      int y = Mathf.Sign(_inputDirection.y);
      _inputDirection = Vector2.Zero;

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
      
      Transform = Transform.LookingAt(_rotationGrid.LookOn, Vector3.Up);
   }
}
