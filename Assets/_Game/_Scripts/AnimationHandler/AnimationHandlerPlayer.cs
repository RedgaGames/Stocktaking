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

    private Transform mainCameraTransform;
    private Transform clipboardTransform;

    private void Start() 
    {
        mainCameraTransform = mainCamera.GetComponent<Transform>();
        clipboardTransform = clipboard.GetComponent<Transform>();
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
        clipboardTransform.DOLocalMoveY(-1.3f, 0.8f);
    }

    public void PlayAnimationHideClipboard()
    {
        clipboardTransform.DOLocalMoveY(-3.3f, 0.8f);
    }
}
