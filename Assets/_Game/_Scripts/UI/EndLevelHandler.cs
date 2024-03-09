using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelHandler : MonoBehaviour
{
    ScreenHandler screenHandler;
    DialogHandler dialogHandler;


    private void Awake() {
        screenHandler = FindObjectOfType<ScreenHandler>();
        dialogHandler = FindObjectOfType<DialogHandler>();
    }


    public void OpenEndLevelScreen()
    {
        StateHandler.Instance.UpdateGameState(StateHandler.GameState.EndGame);
        screenHandler.ShowEndLevelScreen();
        dialogHandler.ClearAndHideDialogScreen();
    }

    public void ReturnToGame()
    {
        StateHandler.Instance.UpdateGameState(StateHandler.GameState.MainGame);
        screenHandler.HideEndLevelScreen();
    }

    public void EndLevel()
    {
        Debug.Log("Lol");
    }
}
