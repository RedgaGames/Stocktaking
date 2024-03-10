using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class OutroTextHandler : MonoBehaviour
{
    ScreenHandler screenHandler;

    [Header("Steuerelemente")]
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private GameObject _clickToContinueText;
    [SerializeField] private float _textSpeed;

    public List<string> dialogLines;
    private int _index;
    private bool _isIntro = true;

    public bool IsLevelPassed { get; set; }


    private void Awake()
    {
        screenHandler = FindObjectOfType<ScreenHandler>();
        dialogLines = new List<string>();
    }

    public void ContinuePressed()
    {
        if (_dialogText.text == dialogLines[_index])
        {
            ShowNextLine();
        }
    }

    public void AddTextLineToDialog(string newTextLine)
    {
        dialogLines.Add(newTextLine);
        Debug.Log("Text Added: " + newTextLine);
    }

    public void StartOutroText()
    {
        if (dialogLines.Count == 0) { Debug.Log("Keine Dialoge zum zeigen"); return;}

        _index = 0;
        _dialogText.text = string.Empty;

        StartCoroutine(TypeOutroText());
    }

    private IEnumerator TypeOutroText()
    {
        foreach (char c in dialogLines[_index].ToCharArray())
        {
            _dialogText.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
        _clickToContinueText.SetActive(true);
    }

    private void ShowNextLine()
    {
        _clickToContinueText.SetActive(false);
        if (_index < dialogLines.Count - 1) //Length swapped with count
        {
            _index++;
            _dialogText.text = string.Empty;
            StartCoroutine(TypeOutroText());
        }
        else
        {
            if (_isIntro)
            {
                StateHandler.Instance.UpdateGameState(StateHandler.GameState.Tutorial);
                _isIntro = false;

                dialogLines.Clear();
                _dialogText.text = string.Empty;
            }
            else
            {
                if (IsLevelPassed)
                {
                    Debug.Log("Level passed");
                    screenHandler.FinishLevelTransitionGood();
                }
                else
                {
                    Debug.Log("Level failed");
                    screenHandler.FinishLevelTransitionBad();
                }
            }
        }
    }

    public void SetMaskEmotionForOutro(MaskGuyEmotionOutro maskGuyEmotion)
    {
        switch (maskGuyEmotion)
        {
            case MaskGuyEmotionOutro.happy:
                screenHandler.ShowMaskedGuyHappyInOutro();
                break;
            case MaskGuyEmotionOutro.scared:
                screenHandler.ShowMaskedGuyScaredInOutro();
                break;
            case MaskGuyEmotionOutro.evil:
                screenHandler.ShowMaskedGuyEvilInOutro();
                break;
        }

    }

    public enum MaskGuyEmotionOutro
    {
        happy,
        scared,
        evil,
    }


}
