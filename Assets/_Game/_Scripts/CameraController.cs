using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    [SerializeField] private Camera mainCamera;

    AnimationHandlerPlayer animationHandlerPlayer;

    private float rotationDuration = 1f;

    private bool isRotating = false;

    private void Start() 
    {
        animationHandlerPlayer = FindObjectOfType<AnimationHandlerPlayer>();
    }

    void Update()
    {
        CheckForRotationInput();
    }

    //TODO -> Input Manager
    private void CheckForRotationInput()
    {
        //Rotate Left
        if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
        {
            RotateCamera(-90f);
        }
        //Rotate Right
        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            RotateCamera(90f);
        }

    }

    // Funktion zum Drehen der Kamera
    private void RotateCamera(float rotationAngle)
    {
        if (isRotating) { return; }

        StartCoroutine(RotateCameraCoroutine(rotationAngle, rotationDuration));
    }

    IEnumerator RotateCameraCoroutine(float rotationAngle, float rotationDuration)
    {
        isRotating = true;

        Quaternion currentRotation = mainCamera.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(currentRotation.eulerAngles + new Vector3(0f, rotationAngle, 0f));
        Vector3 eulerRotation = targetRotation.eulerAngles;

        animationHandlerPlayer.PlayAnimationCameraRotation(eulerRotation, rotationDuration);

        yield return new WaitForSeconds(rotationDuration);
        isRotating = false;
    }

}
