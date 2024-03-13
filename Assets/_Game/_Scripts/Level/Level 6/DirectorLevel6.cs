using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorLevel6 : MonoBehaviour
{
    OutroTextHandler outroTextHandler;
    DialogHandler dialogHandler;
    OutroHandler outroHandler;
    LightHandler lightHandler;
    ScreenHandler screenHandler;
    MeatLightController meatLightController;

    private bool _firstTimeLightsOut = true;

    private StateHandler.GameState _currentGameState;
    private bool _isLevelEnded = false;



    private void Awake()
    {
        outroTextHandler = FindObjectOfType<OutroTextHandler>();
        dialogHandler = FindObjectOfType<DialogHandler>();
        outroHandler = FindObjectOfType<OutroHandler>();
        lightHandler = FindObjectOfType<LightHandler>();
        screenHandler = FindObjectOfType<ScreenHandler>();
        meatLightController = FindObjectOfType<MeatLightController>();
        

        StateHandler.OnGameStateChanged += StateHandlerChanged;
    }

    private void Start()
    {
        SetTextForIntroScene();
  
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
                break;

            case StateHandler.GameState.MainGame:
                StartCoroutine(StartLightsOutTimer());
                break;

            case StateHandler.GameState.Outro:
            SetTextForOutro();
            _isLevelEnded = true;
                break;
        }
    }

    private IEnumerator StartLightsOutTimer()
    {
        while (true && !_isLevelEnded)
        {
            yield return new WaitForSeconds(10f);
            if (lightHandler.IsLightOn)
            {
                StartCoroutine(lightHandler.StartLightFlickerLarge());
                yield return new WaitForSeconds(2f);
                meatLightController.StartLightsOutEvent();

                SetTextForFirstLightsOut();
            }
        }
    }

    private void SetTextForFirstLightsOut()
    {
        if (_firstTimeLightsOut)
        {
        dialogHandler.AddTextLineToDialog("You are here forever..", DialogHandler.MaskGuyEmotion.evil);
        dialogHandler.AddTextLineToDialog("Alone.", DialogHandler.MaskGuyEmotion.evil);
        dialogHandler.AddTextLineToDialog("In the dark.", DialogHandler.MaskGuyEmotion.evil);
        dialogHandler.ShowDialog(true);

        _firstTimeLightsOut = false;
        }
    }

    private IEnumerator TimerTillMainScene()
    {
        yield return new WaitForSeconds(1f);
        StateHandler.Instance.UpdateGameState(StateHandler.GameState.MainGame);
    }

    private void SetTextForIntroScene()
    {
        outroTextHandler.AddTextLineToDialog("MEAT IS MEAT!");
        outroTextHandler.AddTextLineToDialog("MEAT IS MEAT!");
        outroTextHandler.AddTextLineToDialog("MEAT IS MEAT!");
        outroTextHandler.AddTextLineToDialog("MEAT IS MEAT!");
        outroTextHandler.SetMaskEmotionForOutro(OutroTextHandler.MaskGuyEmotionOutro.evil);
        dialogHandler.AddTextLineToDialog("Fresh meat...", DialogHandler.MaskGuyEmotion.evil);
        dialogHandler.AddTextLineToDialog("You think you could take over my job isnt it?", DialogHandler.MaskGuyEmotion.evil);
        dialogHandler.AddTextLineToDialog("You will end up like everyone else.", DialogHandler.MaskGuyEmotion.evil);
    }

        private void SetTextForOutro()
    {
        if (outroHandler.CurrentEndResult == OutroHandler.EndResult.perfect)
        {
            outroTextHandler.AddTextLineToDialog("This cant be...");
            outroTextHandler.AddTextLineToDialog("Listen.");
            outroTextHandler.AddTextLineToDialog("You don't know what a job means here.");
            outroTextHandler.AddTextLineToDialog("We are in the same boat. \nWe can help each other.");
            outroTextHandler.AddTextLineToDialog("Please don't tell Mr. Willsion.");
            outroTextHandler.AddTextLineToDialog("...");
        }

        else if (outroHandler.CurrentEndResult == OutroHandler.EndResult.good)
        {
            outroTextHandler.AddTextLineToDialog("This cant be...");
            outroTextHandler.AddTextLineToDialog("Listen.");
            outroTextHandler.AddTextLineToDialog("You don't know what a job means here.");
            outroTextHandler.AddTextLineToDialog("We are in the same boat. \nWe can help each other.");
            outroTextHandler.AddTextLineToDialog("Please don't tell Mr. Willsion.");
            outroTextHandler.AddTextLineToDialog("...");
        }

        else if (outroHandler.CurrentEndResult == OutroHandler.EndResult.bad)
        {
            outroTextHandler.AddTextLineToDialog("I told you fresh meat...");
            outroTextHandler.AddTextLineToDialog("THERE IS NO WAY OUT!");
        }
    }

}
