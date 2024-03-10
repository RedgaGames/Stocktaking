using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    [SerializeField] private GameObject mainCamera;
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

    public void ActivateMainCamera(){ mainCamera.SetActive(true); inspectCamera.SetActive(false); maskedGuyCamera.SetActive(false); }
    public void ActivateInspectCamera(){ mainCamera.SetActive(false); inspectCamera.SetActive(true); maskedGuyCamera.SetActive(false); }
    public void ActivateMaskedGuyCamera(){ mainCamera.SetActive(false); inspectCamera.SetActive(false); maskedGuyCamera.SetActive(true); }

    // Funktion zum Drehen der Kamera
    public void RotateCamera(float rotationAngle)
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
