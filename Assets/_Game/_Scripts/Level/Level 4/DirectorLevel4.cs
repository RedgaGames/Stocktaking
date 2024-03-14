using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DirectorLevel4 : MonoBehaviour
{
    [SerializeField] GameObject _mainCamera;
    public List<GameObject> rats = new List<GameObject>();

    OutroTextHandler outroTextHandler;
    DialogHandler dialogHandler;
    OutroHandler outroHandler;
    LightHandler lightHandler;
    InputHandler inputHandler;
    AlternativeControlls alternativeControlls;

    private StateHandler.GameState _currentGameState;

    private bool _isFirstTimeInspect = true;
    private bool _isFirstTimeMainGame = true;
    //private bool _isFirstTimeInFakeRoom = true;
    private bool _isLevelEnded = false;

    private void Awake()
    {
        outroTextHandler = FindObjectOfType<OutroTextHandler>();
        dialogHandler = FindObjectOfType<DialogHandler>();
        outroHandler = FindObjectOfType<OutroHandler>();
        lightHandler = FindObjectOfType<LightHandler>();
        inputHandler = FindObjectOfType<InputHandler>();  
        alternativeControlls = FindObjectOfType<AlternativeControlls>();  

        StateHandler.OnGameStateChanged += StateHandlerChanged;
    }

    private void Start()
    {
        SetTextForIntroScene();
        SetTextForFirstDialog();
    }

    private void StateHandlerChanged(StateHandler.GameState currentState)
    {
        _currentGameState = currentState;

        switch (currentState)
        {
            case StateHandler.GameState.Tutorial:
                inputHandler.IsMainControllsActivated = false;
                alternativeControlls.IsMainControllsActivated = true;
                AudioHandler.instance.PlaySound_Music_BGM1();
                StartCoroutine(TimerTillMainScene());
                break;

            case StateHandler.GameState.Inspect:
                inputHandler.IsMainControllsActivated = false;
                alternativeControlls.IsMainControllsActivated = false;
                if (_isFirstTimeInspect)
                {
                    _isFirstTimeInspect = false;
                }
                break;

            case StateHandler.GameState.MainGame:
                inputHandler.IsMainControllsActivated = false;
                alternativeControlls.IsMainControllsActivated = true;
                if (_isFirstTimeMainGame)
                {
                    
                    StartCoroutine(SetDialogForPlayer());

                    _isFirstTimeMainGame = false;
                }
                break;

            case StateHandler.GameState.Outro:
                SetTextForOutro();
                _isLevelEnded = true;
                StateHandler.OnGameStateChanged -= StateHandlerChanged;
                break;
        }
    }



    private IEnumerator SetDialogForPlayer()
    {

        yield return new WaitForSeconds(15f);
        if(!_isLevelEnded)
        {
            dialogHandler.AddTextLineToDialog("Just leave.", DialogHandler.MaskGuyEmotion.sad);
            dialogHandler.AddTextLineToDialog("He will not harm you, i promise.", DialogHandler.MaskGuyEmotion.sad);
            dialogHandler.ShowDialog(true);
        }
        yield return new WaitForSeconds(15f);
        if(!_isLevelEnded)
        {
            dialogHandler.AddTextLineToDialog("Listen. You don't have to stay.", DialogHandler.MaskGuyEmotion.neutral);
            dialogHandler.ShowDialog(true);
        }
        yield return new WaitForSeconds(15f);
        if(!_isLevelEnded)
        {
            dialogHandler.AddTextLineToDialog("Why are you still here.", DialogHandler.MaskGuyEmotion.neutral);
            dialogHandler.AddTextLineToDialog("Is it my job? Is it that?", DialogHandler.MaskGuyEmotion.neutral);
            dialogHandler.ShowDialog(true);
        }
        yield return new WaitForSeconds(15f);
        if(!_isLevelEnded)
        {
            dialogHandler.AddTextLineToDialog("It doesn't have to end like this.", DialogHandler.MaskGuyEmotion.angryLow);
            dialogHandler.AddTextLineToDialog("Please..", DialogHandler.MaskGuyEmotion.sad);
            dialogHandler.ShowDialog(true);
        }
        yield return new WaitForSeconds(20f);
        if(!_isLevelEnded)
        {
            dialogHandler.AddTextLineToDialog("He will not harm you.", DialogHandler.MaskGuyEmotion.sad);
            dialogHandler.ShowDialog(true);
        }
        yield return new WaitForSeconds(25f);
        if(!_isLevelEnded)
        {
            dialogHandler.AddTextLineToDialog("Okay. What is your plan?", DialogHandler.MaskGuyEmotion.angryLow);
            dialogHandler.AddTextLineToDialog("You want to stay?", DialogHandler.MaskGuyEmotion.sad);
            dialogHandler.ShowDialog(true);
        }

    }


    private void SetTextForIntroScene()
    {
        outroTextHandler.AddTextLineToDialog("We need to talk.");
        outroTextHandler.AddTextLineToDialog("You did a great job.");
        outroTextHandler.AddTextLineToDialog("I value you very much \nas a colleague.");
        outroTextHandler.AddTextLineToDialog("But you have to stop now.");
        outroTextHandler.AddTextLineToDialog("Otherwise my job is in danger.");
        outroTextHandler.AddTextLineToDialog("If you keep working like this, \nMr. Willsion might see no need to keep me.");
        outroTextHandler.AddTextLineToDialog("Just stop working.");
        outroTextHandler.AddTextLineToDialog("Can you do that for me?");

        outroTextHandler.SetMaskEmotionForOutro(OutroTextHandler.MaskGuyEmotionOutro.happy);
    }

    private void SetTextForFirstDialog()
    {
        dialogHandler.AddTextLineToDialog("Hey.", DialogHandler.MaskGuyEmotion.sad);
        dialogHandler.AddTextLineToDialog("I hope you understand my \nsituation.", DialogHandler.MaskGuyEmotion.sad);
        dialogHandler.AddTextLineToDialog("I hope you are doing the right thing.", DialogHandler.MaskGuyEmotion.happy);
    }

    private IEnumerator TimerTillMainScene()
    {
        yield return new WaitForSeconds(3f);
        StateHandler.Instance.UpdateGameState(StateHandler.GameState.MainGame);
    }



    //TODO
    private void SetTextForOutro()
    {
        if (outroHandler.CurrentEndResult == OutroHandler.EndResult.perfect)
        {
            outroTextHandler.AddTextLineToDialog("You did a good job...");
            outroTextHandler.AddTextLineToDialog("...again.");
            outroTextHandler.AddTextLineToDialog("Did you not understand \nme earlier?");
            outroTextHandler.AddTextLineToDialog("This needs to stop.");
        }

        else if (outroHandler.CurrentEndResult == OutroHandler.EndResult.good)
        {
            outroTextHandler.AddTextLineToDialog("You did a good job...");
            outroTextHandler.AddTextLineToDialog("...again.");
            outroTextHandler.AddTextLineToDialog("Did you not understand \nme earlier?");
            outroTextHandler.AddTextLineToDialog("This needs to stop.");
        }

        else if (outroHandler.CurrentEndResult == OutroHandler.EndResult.bad)
        {
            outroTextHandler.AddTextLineToDialog("Thank you...");
            outroTextHandler.AddTextLineToDialog("... fresh meat.");
        }
    }
}
