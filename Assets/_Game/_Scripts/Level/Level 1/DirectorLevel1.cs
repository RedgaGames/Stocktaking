using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Director for Level 1.
/// Director Classes are getting messy.
/// </summary>

public class DirectorLevel1 : MonoBehaviour
{   
    OutroTextHandler outroTextHandler;
    DialogHandler dialogHandler;

    private bool _firstTimeInspect = true;
    private bool _firstTimeMainGame = true;


    private void Awake() {
        outroTextHandler = FindObjectOfType<OutroTextHandler>();
        dialogHandler = FindObjectOfType<DialogHandler>();

        StateHandler.OnGameStateChanged += StateHandlerChanged;
    }

    private void StateHandlerChanged(StateHandler.GameState currentState)
    {
        switch (currentState)
        {
            case StateHandler.GameState.Inspect:
                if (_firstTimeInspect)
                {
                    _firstTimeInspect = false;

                    dialogHandler.AddTextLineToDialog("Well done.", DialogHandler.MaskGuyEmotion.happy);
                    dialogHandler.AddTextLineToDialog("You can rotate objects in inspectmode by using your mousewheel.", DialogHandler.MaskGuyEmotion.happy);
                    dialogHandler.AddTextLineToDialog("Leave the inspectmode by pressing right click again.", DialogHandler.MaskGuyEmotion.happy);
                    dialogHandler.ShowDialog(true);
                }
                break;

            case StateHandler.GameState.MainGame:
                if (_firstTimeMainGame)
                {
                    _firstTimeMainGame = false;

                    dialogHandler.AddTextLineToDialog("Press W to open your Clipboard", DialogHandler.MaskGuyEmotion.happy);
                    dialogHandler.ShowDialog(true);
                }
                break;
        }
    }

    private void Start() {
        SetTextForIntroScene();
        SetTextForFirstDialog();
    }

    private void SetTextForIntroScene()
    {   
        outroTextHandler.AddTextLineToDialog("Hello fresh meat.");
        outroTextHandler.AddTextLineToDialog("Welcome to the X Cooperation.");
        outroTextHandler.AddTextLineToDialog("Your job is to do our inventory.");
        outroTextHandler.AddTextLineToDialog("Make notes of our current stock and then finish your shift.");
        outroTextHandler.AddTextLineToDialog("And try not to do too much wrong otherwise \nMr. Willson will be very unhappy.");
        outroTextHandler.AddTextLineToDialog("And if Mr. Willson is unhappy,\n you are going to be unhappy.");
        outroTextHandler.AddTextLineToDialog("Anyway.\nHave a great first shift!!");

        outroTextHandler.SetMaskEmotionForOutro(OutroTextHandler.MaskGuyEmotionOutro.happy);
    }

    private void SetTextForFirstDialog()
    {
        dialogHandler.AddTextLineToDialog("Welcome to our storage room.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.AddTextLineToDialog("You can interact with objects in the room by clicking the left mouse button.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.AddTextLineToDialog("Inspect objects by clicking the right mouse button.\nGive it a try.", DialogHandler.MaskGuyEmotion.happy);
    }


}
