using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Director for Level 1.
/// </summary>

public class DirectorLevel1 : MonoBehaviour
{   
    OutroTextHandler outroTextHandler;
    DialogHandler dialogHandler;


    private void Awake() {
        outroTextHandler = FindObjectOfType<OutroTextHandler>();
        dialogHandler = FindObjectOfType<DialogHandler>();
    }


    private void Start() {
        SetTextForIntroScene();
    }


    private void SetTextForIntroScene()
    {   
        outroTextHandler.AddTextLineToDialog("Test \n TestTestTest");
        outroTextHandler.AddTextLineToDialog("Zweiter Text");
        outroTextHandler.AddTextLineToDialog("Und Go!");

        outroTextHandler.SetMaskEmotionForOutro(OutroTextHandler.MaskGuyEmotionOutro.happy);
    }


}
