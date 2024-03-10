using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelHandler : MonoBehaviour
{
    ScreenHandler screenHandler;
    DialogHandler dialogHandler;
    LevelHandler levelHandler;
    EndResultHandler endResultHandler;

    private void Awake() {
        screenHandler = FindObjectOfType<ScreenHandler>();
        dialogHandler = FindObjectOfType<DialogHandler>();
        levelHandler = FindObjectOfType<LevelHandler>();
        endResultHandler = FindObjectOfType<EndResultHandler>();
    }


    public void OpenEndLevelScreen()
    {
        StateHandler.Instance.UpdateGameState(StateHandler.GameState.EndGame);
        screenHandler.ShowEndLevelScreen();
        dialogHandler.ClearAndHideDialogScreen();

        levelHandler.CountAllItems();
    }

    public void ReturnToGame()
    {
        StateHandler.Instance.UpdateGameState(StateHandler.GameState.MainGame);
        screenHandler.HideEndLevelScreen();
    }

    public void EndLevel()
    {
        endResultHandler.CalculateEndScore();
        StateHandler.Instance.UpdateGameState(StateHandler.GameState.Outro);
    }
}
