using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroHandler : MonoBehaviour
{
    OutroTextHandler outroTextHandler;

    public EndResult CurrentEndResult {get; private set;}

    private void Start() {
        outroTextHandler = FindObjectOfType<OutroTextHandler>();
    }

    //Bool setzen wegen finished or nawt
    public void SetOutroTextForResultPerfect()
    {

        outroTextHandler.SetMaskEmotionForOutro(OutroTextHandler.MaskGuyEmotionOutro.happy);
        CurrentEndResult = EndResult.perfect;

        outroTextHandler.IsLevelPassed = true;
    }

    public void SetOutroTextForResultGood()
    {
        outroTextHandler.SetMaskEmotionForOutro(OutroTextHandler.MaskGuyEmotionOutro.happy);
        CurrentEndResult = EndResult.good;

        outroTextHandler.IsLevelPassed = true;
    }

    public void SetOutroTextForResultBad()
    {
        outroTextHandler.SetMaskEmotionForOutro(OutroTextHandler.MaskGuyEmotionOutro.evil);
        CurrentEndResult = EndResult.bad;

        outroTextHandler.IsLevelPassed = false;
    }

    public enum EndResult
    {
        perfect,
        good,
        bad
    }
}
