using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorLevel7 : MonoBehaviour
{
    OutroTextHandler outroTextHandler;
    DialogHandler dialogHandler;
    OutroHandler outroHandler;
    LightHandler lightHandler;
    ScreenHandler screenHandler;

    private bool _endLevelActivated = false;

    private StateHandler.GameState _currentGameState;

    private void Awake()
    {
        outroTextHandler = FindObjectOfType<OutroTextHandler>();
        dialogHandler = FindObjectOfType<DialogHandler>();
        outroHandler = FindObjectOfType<OutroHandler>();
        lightHandler = FindObjectOfType<LightHandler>();
        screenHandler = FindObjectOfType<ScreenHandler>();

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
                break;

            case StateHandler.GameState.Outro:
                break;
        }
    }

    private IEnumerator TimerTillMainScene()
    {
        yield return new WaitForSeconds(1f);
        StateHandler.Instance.UpdateGameState(StateHandler.GameState.MainGame);
    }

    private void SetTextForIntroScene()
    {
        outroTextHandler.AddTextLineToDialog("....");
        dialogHandler.AddTextLineToDialog("....", DialogHandler.MaskGuyEmotion.scared);
    }

    public void EndGame()
    {
        if (!_endLevelActivated)
        {
            StartCoroutine(EndGameRoutine());
            _endLevelActivated = true;
        }
    }

    private IEnumerator EndGameRoutine()
    {
        yield return new WaitForSeconds(1f);
        screenHandler.FinishLevelTransitionGood();
    }   

}
