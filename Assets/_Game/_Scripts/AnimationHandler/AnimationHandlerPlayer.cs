using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Handles all DOTWEEN Animations for Playerelements like camera and checklist
/// </summary>

public class AnimationHandlerPlayer : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject clipboard;

    ConverterHelper converterHelper;

    private Transform mainCameraTransform;
    private Transform clipboardTransform;

    private void Start() 
    {
        mainCameraTransform = mainCamera.GetComponent<Transform>();
        clipboardTransform = clipboard.GetComponent<Transform>();

        converterHelper = FindObjectOfType<ConverterHelper>();
    }


    // Camera
    public void PlayAnimationCameraRotation(Vector3 targetRotation, float duration)
    {
        mainCameraTransform.DORotate(targetRotation, duration);
    }

    // Clipboard
    // TODO: Noone likes magic numbers. But here there are - Enjoy!
    public void PlayAnimationShowClipboard()
    {  
        Quaternion clipboardRotate = clipboardTransform.transform.rotation;
        Vector3 targetRotation = converterHelper.AddAndConvertQuaternionToVector3(clipboardRotate, new Vector3(-100f, 0f, 0f));

        clipboardTransform.DOLocalRotate(targetRotation, 0.5f, RotateMode.FastBeyond360);
    }

    public void PlayAnimationHideClipboard()
    {
        Quaternion clipboardRotate = clipboardTransform.transform.rotation;
        Vector3 targetRotation = converterHelper.AddAndConvertQuaternionToVector3(clipboardRotate, new Vector3(100f, 0f, 0f));

        clipboardTransform.DOLocalRotate(targetRotation, 0.5f, RotateMode.FastBeyond360);

    }


}
