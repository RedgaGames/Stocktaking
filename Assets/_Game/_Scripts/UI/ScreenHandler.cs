using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handels all screens in the level.
/// </summary>
public class ScreenHandler : MonoBehaviour
{
    private AnimationHandlerUI animationHandlerUI;
    private CameraController cameraController;

    private void Start() 
    {
        animationHandlerUI = FindObjectOfType<AnimationHandlerUI>();
        cameraController = FindObjectOfType<CameraController>();
    }

    //IntroScreen
    public void ShowIntroScreen()
    {
        animationHandlerUI.PlayAnimation_IntroText();
    }


    //EndLevelScreen
    public void ShowEndLevelScreen()
    {
        animationHandlerUI.PlayAnimation_DimedBackground_FadeIn();
        animationHandlerUI.PlayAnimation_EndLevelScreen_FadeIn();
    }

    public void HideEndLevelScreen()
    {
        animationHandlerUI.PlayAnimation_DimedBackground_FadeOut();
        animationHandlerUI.PlayAnimation_EndLevelScreen_FadeOut();
    }
    

    //DialogScreen
    public void ShowDialogScreen()
    {
        animationHandlerUI.PlayAnimation_DialogScreen_FadeIn();
    }

    public void HideDialogScreen()
    {
        animationHandlerUI.PlayAnimation_DialogScreen_FadeOut();
    }


    //Outro
    public void ShowOutroScreen()
    {
        StartCoroutine(ShowOutroScreenRoutine());
    }

    private IEnumerator ShowOutroScreenRoutine()
    {
        animationHandlerUI.PlayAnimation_OutroText_FadeIn();
        yield return new WaitForSeconds(1f);
        cameraController.ActivateMaskedGuyCamera();
        animationHandlerUI.PlayAnimation_BlackBackground_FadeOut(0.5f);
    }

    public void ShowOutroScreenAsIntro()
    {   
        cameraController.ActivateMaskedGuyCamera();
        animationHandlerUI.PlayAnimation_OutroText_FadeIn_AsIntro();
    } 

    public void HideOutroScreenAsIntro()
    {   
        StartCoroutine(HideOutroScreenAsIntroRoutine());
    }

    private IEnumerator HideOutroScreenAsIntroRoutine()
    {
        animationHandlerUI.PlayAnimation_OutroText_FadeOut();
        yield return new WaitForSeconds(1f);
        cameraController.ActivateMainCamera();
        animationHandlerUI.PlayAnimation_BlackBackground_FadeOut(0.5f);
    }


    //  InspectScreen
    public void ShowInspectScreen()
    {
        cameraController.ActivateInspectCamera();
        animationHandlerUI.PlayAnimation_InspectScreen_FadeIn();
    }

    public void HideInspectScreen()
    {
        cameraController.ActivateMainCamera();
        animationHandlerUI.PlayAnimation_InspectScreen_FadeOut();
    }




}
