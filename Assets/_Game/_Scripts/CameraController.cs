using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject inspectCamera;
    [SerializeField] private GameObject maskedGuyCamera;

    AnimationHandlerPlayer animationHandlerPlayer;
    ConverterHelper converterHelper;

    private float rotationDuration = 1f;

    private bool isRotating = false;

    private void Start() 
    {
        animationHandlerPlayer = FindObjectOfType<AnimationHandlerPlayer>();
        converterHelper = FindObjectOfType<ConverterHelper>();
    }

    void Update()
    {
        CheckForRotationInput();
    }

    public void ActivateMainCamera(){ inspectCamera.SetActive(false); maskedGuyCamera.SetActive(false); }
    public void ActivateInspectCamera(){ inspectCamera.SetActive(true); maskedGuyCamera.SetActive(false); }
    public void ActivateMaskedGuyCamera(){ inspectCamera.SetActive(false); maskedGuyCamera.SetActive(true); }






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

        if (Input.GetKeyDown(KeyCode.W))
        {
            animationHandlerPlayer.PlayAnimationShowClipboard();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animationHandlerPlayer.PlayAnimationHideClipboard();
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
        Vector3 targetRotation = converterHelper.AddAndConvertQuaternionToVector3(currentRotation, new Vector3(0f, rotationAngle, 0f));

        animationHandlerPlayer.PlayAnimationCameraRotation(targetRotation, rotationDuration);

        yield return new WaitForSeconds(rotationDuration);
        isRotating = false;
    }

}
