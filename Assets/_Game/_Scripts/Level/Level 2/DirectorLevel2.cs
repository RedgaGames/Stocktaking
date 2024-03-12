using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorLevel2 : MonoBehaviour
{
    OutroTextHandler outroTextHandler;
    DialogHandler dialogHandler;
    OutroHandler outroHandler;

    private StateHandler.GameState _currentGameState;


    private void Awake()
    {
        outroTextHandler = FindObjectOfType<OutroTextHandler>();
        dialogHandler = FindObjectOfType<DialogHandler>();
        outroHandler = FindObjectOfType<OutroHandler>();

        StateHandler.OnGameStateChanged += StateHandlerChanged;
    }

    private void StateHandlerChanged(StateHandler.GameState currentState)
    {
        _currentGameState = currentState;

        switch (currentState)
        {
            case StateHandler.GameState.Inspect:

    

                    dialogHandler.AddTextLineToDialog("Well done.", DialogHandler.MaskGuyEmotion.happy);
                    dialogHandler.AddTextLineToDialog("You can rotate objects in inspectmode \nby using your mousewheel.", DialogHandler.MaskGuyEmotion.happy);
                    dialogHandler.AddTextLineToDialog("Leave the inspectmode by pressing \nright click again.", DialogHandler.MaskGuyEmotion.happy);
                    dialogHandler.ShowDialog(true);
                
                break;

            case StateHandler.GameState.MainGame:
  
                    dialogHandler.AddTextLineToDialog("Good.", DialogHandler.MaskGuyEmotion.happy);
                    dialogHandler.AddTextLineToDialog("Now let's move on to the \ninventory.", DialogHandler.MaskGuyEmotion.happy);
                    dialogHandler.AddTextLineToDialog("Press W to bring out your \nclipboard.", DialogHandler.MaskGuyEmotion.happy);



                    dialogHandler.ShowDialog(true);
                
                break;

            case StateHandler.GameState.Outro:
                SetTextForOutro();
                break;

        }
    }

    private void Start()
    {
        SetTextForIntroScene();
        SetTextForFirstDialog();
    }

    private void SetTextForIntroScene()
    {
        outroTextHandler.AddTextLineToDialog("Welcome back fresh meat.");
        outroTextHandler.AddTextLineToDialog("You did well yesterday.");
        outroTextHandler.AddTextLineToDialog("Your job is to do our inventory.");
        outroTextHandler.AddTextLineToDialog("Make notes of our current stock \nand then finish your shift.");
        outroTextHandler.AddTextLineToDialog("And try not to do too much wrong otherwise \nMr. Willson will be very unhappy.");
        outroTextHandler.AddTextLineToDialog("And if Mr. Willson is unhappy, \nyou are going to be unhappy.");
        outroTextHandler.AddTextLineToDialog("No worries. Im just joking...");
        outroTextHandler.AddTextLineToDialog("Anyway.\nHave a great first shift!!!");

        outroTextHandler.SetMaskEmotionForOutro(OutroTextHandler.MaskGuyEmotionOutro.happy);
    }

    private void SetTextForFirstDialog()
    {
        dialogHandler.AddTextLineToDialog("Welcome to our storage room.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.AddTextLineToDialog("You can interact with objects in the room \nby clicking the left mouse button.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.AddTextLineToDialog("Inspect objects by clicking the right mouse button.\nGive it a try.", DialogHandler.MaskGuyEmotion.happy);
    }

    private void SetTextForFirstClipboard()
    {
        dialogHandler.AddTextLineToDialog("To successfully complete an inventory, \nyou must enter the number of items we are looking for.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.AddTextLineToDialog("Mr. Willson will only rate what is on the clipboard.", DialogHandler.MaskGuyEmotion.evil);
        dialogHandler.AddTextLineToDialog("You can hide your clipboard \nby pressing S.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.ShowDialog(true);
    }

    private void SetTextForFirstClipboardClosed()
    {
        dialogHandler.AddTextLineToDialog("Good.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.AddTextLineToDialog("Now use A or D to look around.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.ShowDialog(true);
    }

    private void SetTextForFirstRotation()
    {
        dialogHandler.AddTextLineToDialog("That's all you need to know.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.AddTextLineToDialog("When you are finished, \nyou can end your shift by clicking on the door.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.AddTextLineToDialog("Thats it. \nGood luck with your first shift.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.ShowDialog(true);
    }


    private void SetTextForOutro()
    {
        if (outroHandler.CurrentEndResult == OutroHandler.EndResult.perfect)
        {
            outroTextHandler.AddTextLineToDialog("Perfect job fresh meat.");
            outroTextHandler.AddTextLineToDialog("Mr. Willson is very pleased.");
            outroTextHandler.AddTextLineToDialog("Now get some rest. We'll see you again tomorrow.");
        }

        else if (outroHandler.CurrentEndResult == OutroHandler.EndResult.good)
        {
            outroTextHandler.AddTextLineToDialog("Hello fresh meat. You did well.");
            outroTextHandler.AddTextLineToDialog("Almost everything was correct.");
            outroTextHandler.AddTextLineToDialog("Now get some rest. We'll see you again tomorrow.");
        }

        else if (outroHandler.CurrentEndResult == OutroHandler.EndResult.bad)
        {
            outroTextHandler.AddTextLineToDialog("Oh fresh meat....");
            outroTextHandler.AddTextLineToDialog("Too bad but it seems that \nyou are not the right one for this job.");
            outroTextHandler.AddTextLineToDialog("Looks like we need to \nfind someone new.");
            outroTextHandler.AddTextLineToDialog("Good night.");

        }
    }

}
