using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects which button on a mouse is clicked. My approach of the eventsystem doesnt support a direct way of indicating that.
/// </summary>

public class MouseClickDetector : MonoBehaviour
{
    public MouseButtonType LastMouseButtonClicked { get; private set; }

    private void Update() {
        CheckLatestMouseClick();
    }

    private void CheckLatestMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) // Left
        {
            LastMouseButtonClicked = MouseButtonType.leftButton;
        }
        else if (Input.GetMouseButtonDown(1)) // Right
        {
            LastMouseButtonClicked = MouseButtonType.rightButton;
        }
    }


}

public enum MouseButtonType
{
    leftButton,
    rightButton
}