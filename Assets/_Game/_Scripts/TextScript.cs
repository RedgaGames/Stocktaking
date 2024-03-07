using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextScript : MonoBehaviour
{
    ScreenHandler screenhandler;
    DialogHandler dialogHandler;

    private void Start() {
        screenhandler = FindObjectOfType<ScreenHandler>();
        dialogHandler = FindObjectOfType<DialogHandler>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)){ screenhandler.ShowIntroScreen(); }       //Yes
        if (Input.GetKeyDown(KeyCode.Alpha2)){ screenhandler.ShowOutroScreenAsIntro(); }       
        if (Input.GetKeyDown(KeyCode.Alpha3)){ screenhandler.HideOutroScreenAsIntro(); }
        if (Input.GetKeyDown(KeyCode.Alpha4)){ screenhandler.ShowDialogScreen(); }      //Yes
        if (Input.GetKeyDown(KeyCode.Alpha5)){ screenhandler.HideDialogScreen(); }      //Yes
        if (Input.GetKeyDown(KeyCode.Alpha6)){ screenhandler.ShowEndLevelScreen(); }    //Yes
        if (Input.GetKeyDown(KeyCode.Alpha7)){ screenhandler.HideEndLevelScreen(); }    //Yes
        if (Input.GetKeyDown(KeyCode.Alpha8)){ screenhandler.ShowOutroScreen(); }    //Yes

        if (Input.GetKeyDown(KeyCode.Alpha9)){ dialogHandler.AddTextLineToDialog("TestTestTest", DialogHandler.MaskGuyEmotion.sad); }    //Yes
        if (Input.GetKeyDown(KeyCode.Alpha0)){ dialogHandler.ShowDialog(true);}    //Yes

    }



    public void OnPointerClick()
    {
        if (Input.GetMouseButtonDown(0)) // Linksklick
        {
            Debug.Log("Linksklick erkannt");
        }
        else if (Input.GetMouseButtonDown(1)) // Rechtsklick
        {
            Debug.Log("Rechtsklick erkannt");
        }
    }



}
