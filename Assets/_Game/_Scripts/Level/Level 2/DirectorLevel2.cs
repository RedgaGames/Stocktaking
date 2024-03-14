using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorLevel2 : MonoBehaviour
{
    OutroTextHandler outroTextHandler;
    DialogHandler dialogHandler;
    OutroHandler outroHandler;
    LightHandler lightHandler;

    private StateHandler.GameState _currentGameState;

    [SerializeField] GameObject _objectToActivate1;
    [SerializeField] GameObject _objectToActivate2;
    [SerializeField] GameObject _objectToActivate3;
    [SerializeField] GameObject _objectToDeactivate1;
    [SerializeField] GameObject _objectToDeactivate2;
    [SerializeField] GameObject _objectToDeactivate3;

    private bool _isFirstTimeInspect = true;
    private bool _isFirstTimeMainGame = true;
    private bool _isNotSwapped = true;

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
                    dialogHandler.AddTextLineToDialog("Hmmh fresh meat.", DialogHandler.MaskGuyEmotion.evil);
                    dialogHandler.ShowDialog(true);

                    _isFirstTimeInspect = false;
                }
                break;

            case StateHandler.GameState.MainGame:
                if (_isFirstTimeMainGame)
                {
                    AudioHandler.instance.PlaySound_Music_Level2();
                    StartCoroutine(StartLightsOutTimer());

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
        outroTextHandler.AddTextLineToDialog("Welcome back fresh meat.");
        outroTextHandler.AddTextLineToDialog("You did well yesterday.");
        outroTextHandler.AddTextLineToDialog("I hope the second day is just as good.");

        outroTextHandler.SetMaskEmotionForOutro(OutroTextHandler.MaskGuyEmotionOutro.happy);
    }

    private void SetTextForFirstDialog()
    {
        dialogHandler.AddTextLineToDialog("Hey.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.AddTextLineToDialog("This time we also have meat on the list.", DialogHandler.MaskGuyEmotion.happy);
        dialogHandler.AddTextLineToDialog("Have a nice shift.", DialogHandler.MaskGuyEmotion.happy);
    }

    private void SetTextForFirstLightsOut()
    {
        dialogHandler.AddTextLineToDialog("Looks like the lights have gone out.. .", DialogHandler.MaskGuyEmotion.surprise);
        dialogHandler.ShowDialog(true);
    }

    private IEnumerator StartLightsOutTimer()
    {
        yield return new WaitForSeconds(12f);
        StartCoroutine(lightHandler.StartLightFlickerLarge());
        yield return new WaitForSeconds(2f);
        SetTextForFirstLightsOut();
    }

    private IEnumerator TimerTillMainScene()
    {
        yield return new WaitForSeconds(3f);
        StateHandler.Instance.UpdateGameState(StateHandler.GameState.MainGame);
    }

    public void SwapItems()
    {
        if (_isNotSwapped)
        {
            _objectToActivate1.SetActive(true);
            _objectToActivate2.SetActive(true);
            _objectToActivate3.SetActive(true);
            _objectToDeactivate1.SetActive(false);
            _objectToDeactivate2.SetActive(false);
            _objectToDeactivate3.SetActive(false);

            _isNotSwapped = false;
        }
        else        
        {
            _objectToActivate1.SetActive(false);
            _objectToActivate2.SetActive(false);
            _objectToActivate3.SetActive(false);
            _objectToDeactivate1.SetActive(true);
            _objectToDeactivate2.SetActive(true);
            _objectToDeactivate3.SetActive(true);

            _isNotSwapped = true;
        }
    }

    //TODO
    private void SetTextForOutro()
    {
        if (outroHandler.CurrentEndResult == OutroHandler.EndResult.perfect)
        {
            outroTextHandler.AddTextLineToDialog("Again. A perfect job.");
            outroTextHandler.AddTextLineToDialog("You did really well.");
            outroTextHandler.AddTextLineToDialog("Maybe just a little too well.");
        }

        else if (outroHandler.CurrentEndResult == OutroHandler.EndResult.good)
        {
            outroTextHandler.AddTextLineToDialog("Great job again.");
            outroTextHandler.AddTextLineToDialog("You got most things right.");
            outroTextHandler.AddTextLineToDialog("Don't overwork yourself. We'll continue tomorrow.");
        }

        else if (outroHandler.CurrentEndResult == OutroHandler.EndResult.bad)
        {
            outroTextHandler.AddTextLineToDialog("Unfortunately, \nI have to say that...");
            outroTextHandler.AddTextLineToDialog("...the M.I.M. Cooperation no longer \nany use for you.");
        }
    }

}
