using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{

    private void Start() {
        AudioHandler.instance.PlaySound_Music_MainMenu();
    }

    public void StartGame()
    {
        AudioHandler.instance.PlaySound_FX_UI_Click1();
        AudioHandler.instance.StopSoundsBGM();
        SceneManager.LoadScene(1);
    }


}
