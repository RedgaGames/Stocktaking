using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour
{
    public static StateHandler Instance;
    ScreenHandler screenHandler;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    private void Start() {
        UpdateGameState(GameState.Intro);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Intro:
                break;
            case GameState.IntroMaskedGuy:
                break;
            case GameState.MainGame:
                break;
            case GameState.Inspect:
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





    public enum GameState
    {
        Intro,
        IntroMaskedGuy,
        MainGame,
        Inspect,
        EndGame,
        Outro
    }

}
