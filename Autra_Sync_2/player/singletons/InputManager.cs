using Godot;
using System;

public class InputManager : Node {
   bool keyboardMode = true;

   public override void _Ready() {
      
   }

   public override void _UnhandledInput(InputEvent @event) {
      if (IsKeyboardEvent(@event) && !keyboardMode) {
         keyboardMode = true;
      }
      if (IsGamepadEvent(@event) && keyboardMode) {
         keyboardMode = false;
      }
   }

   public bool IsKeyboardMode() {
      return keyboardMode;
   }

   bool IsKeyboardEvent(InputEvent e) {
      return e is InputEventKey || e is InputEventMouseButton;
   }

   bool IsGamepadEvent(InputEvent e) {
      return e is InputEventJoypadButton || e is InputEventJoypadMotion;
   }
}
