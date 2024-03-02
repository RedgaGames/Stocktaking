using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationHandlerPlayer : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private Transform mainCameraTransform;

    private void Start() 
    {
        mainCameraTransform = mainCamera.GetComponent<Transform>();
    }


    // Camera
    public void PlayAnimationCameraRotation(Vector3 targetRotation, float duration)
    {
        mainCameraTransform.DORotate(targetRotation, duration);
    }


}
