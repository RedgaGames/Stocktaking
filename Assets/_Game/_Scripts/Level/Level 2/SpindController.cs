using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpindController : MonoBehaviour
{
    DialogHandler dialogHandler;

    private int _spindClicked = 0;

    private void Start() {
        dialogHandler = FindObjectOfType<DialogHandler>();
    }

    public void StartSpindDialog()
    {
        _spindClicked++;

        if (_spindClicked == 3)
        {
            dialogHandler.AddTextLineToDialog("HEY STOP THAT!", DialogHandler.MaskGuyEmotion.angryLow);
            dialogHandler.ShowDialog(true);
        }

        if (_spindClicked == 15)
        {
            dialogHandler.AddTextLineToDialog("We will deduct this from your salary.", DialogHandler.MaskGuyEmotion.angryHigh);
            dialogHandler.ShowDialog(true);
        }        

    }
}
