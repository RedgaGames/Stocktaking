using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    AnimationHandlerPlayer animationHandlerPlayer;
    CameraController cameraController;

    public bool IsMainControllsActivated { get; set; }

    private void Start() {
        animationHandlerPlayer = FindObjectOfType<AnimationHandlerPlayer>();
        cameraController = FindObjectOfType<CameraController>();
    }


    void Update()
    {
        CheckForRotationInput();
    }

    private void CheckForRotationInput()
    {
        if (!IsMainControllsActivated){return;}
        //Rotate Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioHandler.instance.PlaySound_FX_UI_Click6();
            cameraController.RotateCamera(-90f);
        }
        //Rotate Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            AudioHandler.instance.PlaySound_FX_UI_Click7();
            cameraController.RotateCamera(90f);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            animationHandlerPlayer.PlayAnimationShowClipboard();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animationHandlerPlayer.PlayAnimationHideClipboard();
        }
    }



}
