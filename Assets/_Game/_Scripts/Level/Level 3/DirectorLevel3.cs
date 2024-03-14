using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DirectorLevel3 : MonoBehaviour
{
    [SerializeField] GameObject _mainCamera;
    public List<GameObject> rats = new List<GameObject>();

    OutroTextHandler outroTextHandler;
    DialogHandler dialogHandler;
    OutroHandler outroHandler;
    LightHandler lightHandler;

    private StateHandler.GameState _currentGameState;

    private bool _isFirstTimeInspect = true;
    private bool _isFirstTimeMainGame = true;
    private bool _isFirstTimeRatSeen = true;
    private bool _isFirstRatKilled = true;
    private bool _isOtherRatsSpawned = false;
    private bool _isFirstTimeInFakeRoom = true;

    private void Awake()
    {
        outroTextHandler = FindObjectOfType<OutroTextHandler>();
        dialogHandler = FindObjectOfType<DialogHandler>();
        outroHandler = FindObjectOfType<OutroHandler>();
        lightHandler = FindObjectOfType<LightHandler>();

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
                StartCoroutine(TimerTillMainScene());
                break;

            case StateHandler.GameState.Inspect:
                if (_isFirstTimeInspect)
                {
                    _isFirstTimeInspect = false;
                }
                break;

            case StateHandler.GameState.MainGame:
                if (_isFirstTimeMainGame)
                {
                    //StartCoroutine(StartLightsOutTimer());
                    AudioHandler.instance.PlaySound_Music_Level3();

                    _isFirstTimeMainGame = false;
                }
                break;

            case StateHandler.GameState.Outro:
                SetTextForOutro();
                StateHandler.OnGameStateChanged -= StateHandlerChanged;
                break;
        }
    }



    private void SetTextForIntroScene()
    {
        outroTextHandler.AddTextLineToDialog("Hello fresh meat.");
        outroTextHandler.AddTextLineToDialog("A new day a new job.");
        outroTextHandler.AddTextLineToDialog("You're doing well, \nbut you can also slow down a bit.");
        outroTextHandler.AddTextLineToDialog("We don't want you to \nwork yourself to death.");

        outroTextHandler.SetMaskEmotionForOutro(OutroTextHandler.MaskGuyEmotionOutro.happy);
    }

    private void SetTextForFirstDialog()
    {
        dialogHandler.AddTextLineToDialog("Hey.", DialogHandler.MaskGuyEmotion.neutral);
        dialogHandler.AddTextLineToDialog("This time we have cheese \non the menu.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.AddTextLineToDialog("Have a nice shift.", DialogHandler.MaskGuyEmotion.happy);
    }

    public void FirstTimeRatsSeen()
    {
        if (_isFirstTimeRatSeen)
        {
            dialogHandler.AddTextLineToDialog("RATS!", DialogHandler.MaskGuyEmotion.surprise);
            dialogHandler.AddTextLineToDialog("Kill them!", DialogHandler.MaskGuyEmotion.evil);
            dialogHandler.ShowDialog(true);

            _isFirstTimeRatSeen = false;

            foreach (GameObject rat in rats)
            {
                rat.SetActive(true);
            }

            _isOtherRatsSpawned = true;
            
        }
    }

    public void FirstTimeRatKilled()
    {
        if (_isFirstRatKilled)
        {
            dialogHandler.AddTextLineToDialog("MEAT IS MEAT.", DialogHandler.MaskGuyEmotion.evil);
            dialogHandler.ShowDialog(true);

            _isFirstRatKilled = false;
        }
    }

    public void FirstTimeOtherRatSeen()
    {
        if (_isOtherRatsSpawned)
        {
            dialogHandler.AddTextLineToDialog("KILL THEM.", DialogHandler.MaskGuyEmotion.evil);
            dialogHandler.AddTextLineToDialog("KILL THEM ALL.", DialogHandler.MaskGuyEmotion.evil);
            dialogHandler.ShowDialog(true);

            _isOtherRatsSpawned = false;
        }
    }

    private IEnumerator TimerTillMainScene()
    {
        yield return new WaitForSeconds(3f);
        StateHandler.Instance.UpdateGameState(StateHandler.GameState.MainGame);
    }

    public void MoveCameraToFakeRoom()
    {
        _mainCamera.transform.DOLocalMoveZ(20.05f, 0.0f);
        
        if (_isFirstTimeInFakeRoom)
        {
            dialogHandler.AddTextLineToDialog("Dont get lost...", DialogHandler.MaskGuyEmotion.evil);
            dialogHandler.ShowDialog(true);
            _isFirstTimeInFakeRoom = false;
        }
    }

    public void MoveCameraToRealRoom()
    {
        _mainCamera.transform.DOLocalMoveZ(0.05f, 0.0f);
    }




    //TODO
    private void SetTextForOutro()
    {
        if (outroHandler.CurrentEndResult == OutroHandler.EndResult.perfect)
        {
            outroTextHandler.AddTextLineToDialog("Fresh meat.");
            outroTextHandler.AddTextLineToDialog("Really well.");
            outroTextHandler.AddTextLineToDialog("Too well...");
        }

        else if (outroHandler.CurrentEndResult == OutroHandler.EndResult.good)
        {
            outroTextHandler.AddTextLineToDialog("Fresh meat.");
            outroTextHandler.AddTextLineToDialog("Good job.");
            outroTextHandler.AddTextLineToDialog("Just turn down a bit.");
        }

        else if (outroHandler.CurrentEndResult == OutroHandler.EndResult.bad)
        {
            outroTextHandler.AddTextLineToDialog("Too bad.");
            outroTextHandler.AddTextLineToDialog("Mr. Willson has...");
            outroTextHandler.AddTextLineToDialog("...another use in mind for you.");
        }
    }

}
