using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour
{
    public static StateHandler Instance;
    public GameState State;
    private ScreenHandler screenHandler;
    private OutroTextHandler outroTextHandler;
    private DialogHandler dialogHandler;
    private InputHandler inputHandler;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        Instance = this;

        screenHandler = FindObjectOfType<ScreenHandler>();
        outroTextHandler = FindObjectOfType<OutroTextHandler>();
        dialogHandler = FindObjectOfType<DialogHandler>();
        inputHandler = FindObjectOfType<InputHandler>();
    }
    private void Start()
    {
        UpdateGameState(GameState.Intro);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Intro:
                ShowIntro();
                break;
            case GameState.IntroMaskedGuy:
                ShowMaskedGuyIntro();
                break;
            case GameState.Tutorial:
                ShowTutorial();
                break;                
            case GameState.MainGame:
                ShowMainGame();
                break;
            case GameState.Inspect:
                ShowInspectMode();
                break;
            case GameState.EndGame:
                ShowEndGame();
                break;
            case GameState.Outro:
                ShowOutro();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        //OnGameStateChanged(newState);
        //Checks if anyone is subscribed to this event
        OnGameStateChanged?.Invoke(newState);
    }

    private void ShowIntro()
    {
        screenHandler.ShowIntroScreen();
        inputHandler.IsMainControllsActivated = false;
    }

    private void ShowMaskedGuyIntro()
    {
        screenHandler.ShowOutroScreenAsIntro();
        outroTextHandler.StartOutroText();
    }

    private void ShowTutorial()
    {
        StartCoroutine(ShowTutroialRoutine());
    }

    private IEnumerator ShowTutroialRoutine()
    {
        screenHandler.HideOutroScreenAsIntro();
        yield return new WaitForSeconds(1.5f);
        dialogHandler.ShowDialog(true);
    }

    private void ShowInspectMode()
    {
        screenHandler.ShowInspectScreen();
        inputHandler.IsMainControllsActivated = false;
    }

    private void ShowMainGame()
    {
        screenHandler.HideInspectScreen();
        inputHandler.IsMainControllsActivated = true;
    }

    private void ShowEndGame()
    {
        inputHandler.IsMainControllsActivated = false;
    }

    private void ShowOutro()
    {
        StartCoroutine(ShowOutroRoutine());
    }

    private IEnumerator ShowOutroRoutine()
    {
        inputHandler.IsMainControllsActivated = false;
        screenHandler.ShowOutroScreen();
        yield return new WaitForSeconds(1f);
        outroTextHandler.StartOutroText();
    }    

    public enum GameState
    {
        Intro,
        IntroMaskedGuy,
        Tutorial,
        MainGame,
        Inspect,
        EndGame,
        Outro
    }

}
