using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndResultHandler : MonoBehaviour
{
    LevelHandler levelHandler;
    OutroHandler outroHandler;

    private int _itemsOnScene;
    private int _itemsOnChecklist;
    public int FinalScore { get; private set;}

    private void Start() {
        levelHandler = FindObjectOfType<LevelHandler>();
        outroHandler = FindObjectOfType<OutroHandler>();
    } 

    public void CalculateEndScore()
    {
        _itemsOnScene = levelHandler.ResultAllItemsCountOnScene;
        _itemsOnChecklist = levelHandler.ResultAllItemsCountOnChecklist;

        FinalScore = _itemsOnScene - _itemsOnChecklist;

        if (Mathf.Abs(FinalScore) == 0)    //Good
        {
            outroHandler.SetOutroTextForResultPerfect();
            AudioHandler.instance.PlaySound_Music_LevelWin();
        }
        else if (Mathf.Abs(FinalScore) == 1)   //Okay
        {
            outroHandler.SetOutroTextForResultGood();
            AudioHandler.instance.PlaySound_Music_LevelWin();
        }
        else if (Mathf.Abs(FinalScore) >= 2)   //Dead
        {
            outroHandler.SetOutroTextForResultBad();
            AudioHandler.instance.PlaySound_Music_LevelFailed();
        }

        Debug.Log("Final Score = " + FinalScore);
        //StateHandler.Instance.UpdateGameState(StateHandler.GameState.Outro);
    }

}
