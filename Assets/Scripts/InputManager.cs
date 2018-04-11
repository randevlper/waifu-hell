using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gold
{
    public class InputManager : MonoBehaviour
    {
        public Camera mainCamera;

        public static Vector2 GetMovementAxis()
        {
            return new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
                );
        }

        //TODO add joystick right stick support
        public static Vector2 GetMouseAxis()
        {
            return new Vector2(
                Input.GetAxisRaw("Mouse X"),
                Input.GetAxisRaw("Mouse Y")
            );
        }

        public Vector2 GetMousePositionWorldSpace()
        {
            return mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

}