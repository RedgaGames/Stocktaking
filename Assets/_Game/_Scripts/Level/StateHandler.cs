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
        UpdateGameState(GameState.MainGame);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Intro:
                ShowIntro();
                Debug.Log("GameState Intro");
                break;
            case GameState.IntroMaskedGuy:
                ShowMaskedGuyIntro();
                Debug.Log("GameState IntroMaskedGuy");
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
                break;
            case GameState.Outro:
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
        screenHandler.HideOutroScreenAsIntro();
        //screenHandler.ShowDialogScreen();
        dialogHandler.ShowDialog(false);
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
