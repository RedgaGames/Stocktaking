using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuGame;

    private bool _isInMenu = false;

    void Update()
    {
        CheckForRotationInput();
    }

    private void CheckForRotationInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isInMenu)
            {
                _mainMenuGame.SetActive(true);
                AudioHandler.instance.PlaySound_FX_UI_Options_Open();
            }
            else
            {
                _mainMenuGame.SetActive(false);
                AudioHandler.instance.PlaySound_FX_UI_Options_Close();
            }
        }
    }

    public void ContinueGame()
    {
        _mainMenuGame.SetActive(false);
    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
