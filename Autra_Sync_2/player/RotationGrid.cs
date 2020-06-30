using Godot;
using System;

public class RotationGrid {
   public Vector3 LookOn = Forward;

   public void LookRight() {
      if (LookOn == Forward) {
         LookOn = ForwardRight;
      } else if (LookOn == ForwardRight) {
         LookOn = Right;
      } else if (LookOn == Right) {
         LookOn = BackRight;
      } else if (LookOn == BackRight) {
         LookOn = Back;
      } else if (LookOn == Back) {
         LookOn = BackLeft;
      } else if (LookOn == BackLeft) {
         LookOn = Left;
      } else if (LookOn == Left) {
         LookOn = ForwardLeft;
      } else if (LookOn == ForwardLeft) {
         LookOn = Forward;
      } else if (LookOn == UpForward) {
         LookOn = UpForwardRight;
      } else if (LookOn == UpForwardRight) {
         LookOn = UpRight;
      } else if (LookOn == UpRight) {
         LookOn = UpBackRight;
      } else if (LookOn == UpBackRight) {
         LookOn = UpBack;
      } else if (LookOn == UpBack) {
         LookOn = UpBackLeft;
      } else if (LookOn == UpBackLeft) {
         LookOn = UpLeft;
      } else if (LookOn == UpLeft) {
         LookOn = UpForwardLeft;
      } else if (LookOn == UpForwardLeft) {
         LookOn = UpForward;
      } else if (LookOn == DownForward) {
         LookOn = DownForwardRight;
      } else if (LookOn == DownForwardRight) {
         LookOn = DownRight;
      } else if (LookOn == DownRight) {
         LookOn = DownBackRight;
      } else if (LookOn == DownBackRight) {
         LookOn = DownBack;
      } else if (LookOn == DownBack) {
         LookOn = DownBackLeft;
      } else if (LookOn == DownBackLeft) {
         LookOn = DownLeft;
      } else if (LookOn == DownLeft) {
         LookOn = DownForwardLeft;
      } else if (LookOn == DownForwardLeft) {
         LookOn = DownForward;
      }
   }

   public void LookLeft() {
      if (LookOn == Forward) {
         LookOn = ForwardLeft;
      } else if (LookOn == ForwardLeft) {
         LookOn = Left;
      } else if (LookOn == Left) {
         LookOn = BackLeft;
      } else if (LookOn == BackLeft) {
         LookOn = Back;
      } else if (LookOn == Back) {
         LookOn = BackRight;
      } else if (LookOn == BackRight) {
         LookOn = Right;
      } else if (LookOn == Right) {
         LookOn = ForwardRight;
      } else if (LookOn == ForwardRight) {
         LookOn = Forward;

      } else if (LookOn == UpForward) {
         LookOn = UpForwardLeft;
      } else if (LookOn == UpForwardLeft) {
         LookOn = UpLeft;
      } else if (LookOn == UpLeft) {
         LookOn = UpBackLeft;
      } else if (LookOn == UpBackLeft) {
         LookOn = UpBack;
      } else if (LookOn == UpBack) {
         LookOn = UpBackRight;
      } else if (LookOn == UpBackRight) {
         LookOn = UpRight;
      } else if (LookOn == UpRight) {
         LookOn = UpForwardRight;
      } else if (LookOn == UpForwardRight) {
         LookOn = UpForward;

      } else if (LookOn == DownForward) {
         LookOn = DownForwardLeft;
      } else if (LookOn == DownForwardLeft) {
         LookOn = DownLeft;
      } else if (LookOn == DownLeft) {
         LookOn = DownBackLeft;
      } else if (LookOn == DownBackLeft) {
         LookOn = DownBack;
      } else if (LookOn == DownBack) {
         LookOn = DownBackRight;
      } else if (LookOn == DownBackRight) {
         LookOn = DownRight;
      } else if (LookOn == DownRight) {
         LookOn = DownForwardRight;
      } else if (LookOn == DownForwardRight) {
         LookOn = DownForward;
      }
   }

   public void LookUp() {
      if (LookOn == DownForward) {
         LookOn = Forward;
      } else if (LookOn == Forward) {
         LookOn = UpForward;
      } else if (LookOn == DownForwardRight) {
         LookOn = ForwardRight;
      } else if (LookOn == ForwardRight) {
         LookOn = UpForwardRight;
      } else if (LookOn == DownRight) {
         LookOn = Right;
      } else if (LookOn == Right) {
         LookOn = UpRight;
      } else if (LookOn == DownBackRight) {
         LookOn = BackRight;
      } else if (LookOn == BackRight) {
         LookOn = UpBackRight;
      } else if (LookOn == DownBack) {
         LookOn = Back;
      } else if (LookOn == Back) {
         LookOn = UpBack;
      } else if (LookOn == DownBackLeft) {
         LookOn = BackLeft;
      } else if (LookOn == BackLeft) {
         LookOn = UpBackLeft;
      } else if (LookOn == DownLeft) {
         LookOn = Left;
      } else if (LookOn == Left) {
         LookOn = UpLeft;
      } else if (LookOn == DownForwardLeft) {
         LookOn = ForwardLeft;
      } else if (LookOn == ForwardLeft) {
         LookOn = UpForwardLeft;
      }
   }

   public void LookDown() {
      if (LookOn == UpForward) {
         LookOn = Forward;
      } else if (LookOn == Forward) {
         LookOn = DownForward;
      } else if (LookOn == UpForwardRight) {
         LookOn = ForwardRight;
      } else if (LookOn == ForwardRight) {
         LookOn = DownForwardRight;
      } else if (LookOn == UpRight) {
         LookOn = Right;
      } else if (LookOn == Right) {
         LookOn = DownRight;
      } else if (LookOn == UpBackRight) {
         LookOn = BackRight;
      } else if (LookOn == BackRight) {
         LookOn = DownBackRight;
      } else if (LookOn == UpBack) {
         LookOn = Back;
      } else if (LookOn == Back) {
         LookOn = DownBack;
      } else if (LookOn == UpBackLeft) {
         LookOn = BackLeft;
      } else if (LookOn == BackLeft) {
         LookOn = DownBackLeft;
      } else if (LookOn == UpLeft) {
         LookOn = Left;
      } else if (LookOn == Left) {
         LookOn = DownLeft;
      } else if (LookOn == UpForwardLeft) {
         LookOn = ForwardLeft;
      } else if (LookOn == ForwardLeft) {
         LookOn = DownForwardLeft;
      }
   }

   static Vector3 Forward = new Vector3(0f, 0f, -1f);
   static Vector3 ForwardRight = new Vector3(1f, 0f, -1f).Normalized();
   static Vector3 Right = new Vector3(1f, 0f, 0f);
   static Vector3 BackRight = new Vector3(1f, 0f, 1f).Normalized();
   static Vector3 Back = new Vector3(0f, 0f, 1f);
   static Vector3 BackLeft = new Vector3(-1f, 0f, 1f).Normalized();
   static Vector3 Left = new Vector3(-1f, 0f, 0f);
   static Vector3 ForwardLeft = new Vector3(-1f, 0f, -1f).Normalized();

   static Vector3 UpForward = new Vector3(0f, 1f, -1f).Normalized();
   static Vector3 UpForwardRight = new Vector3(1f, 1f, -1f).Normalized();
   static Vector3 UpRight = new Vector3(1f, 1f, 0f).Normalized();
   static Vector3 UpBackRight = new Vector3(1f, 1f, 1f).Normalized();
   static Vector3 UpBack = new Vector3(0f, 1f, 1f).Normalized();
   static Vector3 UpBackLeft = new Vector3(-1f, 1f, 1f).Normalized();
   static Vector3 UpLeft = new Vector3(-1f, 1f, 0f).Normalized();
   static Vector3 UpForwardLeft = new Vector3(-1f, 1f, -1f).Normalized();
   static Vector3 Up = new Vector3(0f, 1f, 0f);

   static Vector3 DownForward = new Vector3(0f, -1f, -1f).Normalized();
   static Vector3 DownForwardRight = new Vector3(1f, -1f, -1f).Normalized();
   static Vector3 DownRight = new Vector3(1f, -1f, 0f).Normalized();
   static Vector3 DownBackRight = new Vector3(1f, -1f, 1f).Normalized();
   static Vector3 DownBack = new Vector3(0f, -1f, 1f).Normalized();
   static Vector3 DownBackLeft = new Vector3(-1f, -1f, 1f).Normalized();
   static Vector3 DownLeft = new Vector3(-1f, -1f, 0f).Normalized();
   static Vector3 DownForwardLeft = new Vector3(-1f, -1f, -1f).Normalized();
   static Vector3 Down = new Vector3(0f, -1f, 0f);

}
