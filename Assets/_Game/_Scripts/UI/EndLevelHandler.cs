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
        AudioHandler.instance.PlaySound_FX_UI_Click2();
        StateHandler.Instance.UpdateGameState(StateHandler.GameState.EndGame);
        screenHandler.ShowEndLevelScreen();
        dialogHandler.ClearAndHideDialogScreen();

        levelHandler.CountAllItems();
    }

    public void ReturnToGame()
    {
        AudioHandler.instance.PlaySound_FX_UI_Click3();
        StateHandler.Instance.UpdateGameState(StateHandler.GameState.MainGame);
        screenHandler.HideEndLevelScreen();
    }

    public void EndLevel()
    {   
        AudioHandler.instance.PlaySound_FX_UI_Click4();
        AudioHandler.instance.StopSoundsBGM();
        endResultHandler.CalculateEndScore();
        StateHandler.Instance.UpdateGameState(StateHandler.GameState.Outro);
    }
}
