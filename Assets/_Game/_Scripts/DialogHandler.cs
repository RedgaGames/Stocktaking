using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class contains all methods for the dialogsystem. A dialog needs a text and an emotion.
/// </summary>

public class DialogHandler : MonoBehaviour
{
    ScreenHandler screenHandler;
    AnimationHandlerMaskedGuy animationHandlerMaskedGuy;

    [Header("Steuerelemente")]
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private GameObject _clickToContinue;
    [SerializeField] private float _textSpeed;

    [Header("Mask Guy Sprites")]
    [SerializeField] private Image _maskGuyImage;
    [SerializeField] private Sprite _maskGuySpriteHappy;
    [SerializeField] private Sprite _maskGuySpriteSad;
    [SerializeField] private Sprite _maskGuySpriteEvil;
    [SerializeField] private Sprite _maskGuySpriteAngryLow;
    [SerializeField] private Sprite _maskGuySpriteAngryHigh;
    [SerializeField] private Sprite _maskGuySpriteNeutral;
    [SerializeField] private Sprite _maskGuySpriteScared;
    [SerializeField] private Sprite _maskGuySpriteSurprised;

    public List<(string text, MaskGuyEmotion emotion)> dialogLines;
    private int _index;
    private bool canBeSkipped;
    private bool _isCurrentlyOpen = false;

    private void Awake() {
        screenHandler = FindObjectOfType<ScreenHandler>();
        animationHandlerMaskedGuy = FindObjectOfType<AnimationHandlerMaskedGuy>();
        dialogLines = new List<(string, MaskGuyEmotion)>();       
    }

    private void Start() {
        animationHandlerMaskedGuy.PlayAnimation_MaskedGuyDialog_NewDialog();
    }

    public void ContinuePressed()
    {
        if (_dialogText.text == dialogLines[_index].text)
        {
            ShowNextLine();
        }
        else
        {
            if (canBeSkipped)
            {
                StopAllCoroutines();    //Killt alle Coroutinen der aktuellen Klasse.
                _dialogText.text = dialogLines[_index].text;
                _clickToContinue.SetActive(true);
            }
        }
    }

    public void AddTextLineToDialog(string newTextLine, MaskGuyEmotion newMaskedGuyEmotion)
    {
        dialogLines.Add((newTextLine, newMaskedGuyEmotion));
    }

    public void ShowDialog(bool newCanBeSkipped)
    {
        if (dialogLines.Count == 0) { Debug.Log("Keine Dialoge zum zeigen"); }
        if (_isCurrentlyOpen){return;}

        screenHandler.ShowDialogScreen();

        canBeSkipped = newCanBeSkipped;

        _index = 0;
        _dialogText.text = string.Empty;

        StartCoroutine(TypeDialogText());
    }

    private void ShowNextLine()
    {

        if (_index < dialogLines.Count - 1) //Length swapped with count
        {
            _index++;
            _dialogText.text = string.Empty;
            StartCoroutine(TypeDialogText());
        }
        else
        {
            ClearAndHideDialogScreen();
        }

    }

    public void ClearAndHideDialogScreen()
    {
            dialogLines.Clear();
            screenHandler.HideDialogScreen();
            _isCurrentlyOpen = false;
    }

    private IEnumerator TypeDialogText()
    {
        _isCurrentlyOpen = true;

        ChangeEmotion();
        _clickToContinue.SetActive(false);

        animationHandlerMaskedGuy.PlayAnimation_MaskedGuyDialog_NewLine();

        foreach (char c in dialogLines[_index].text.ToCharArray())
        {
            _dialogText.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }

        _clickToContinue.SetActive(true);
    }

    private void ChangeEmotion()
    {
        MaskGuyEmotion newMaskGuyEmotion = dialogLines[_index].emotion;
        switch (newMaskGuyEmotion)
        {
            case MaskGuyEmotion.happy:
                _maskGuyImage.sprite = _maskGuySpriteHappy;
                break;
            case MaskGuyEmotion.sad:
                _maskGuyImage.sprite = _maskGuySpriteSad;
                break;
            case MaskGuyEmotion.evil:
                _maskGuyImage.sprite = _maskGuySpriteEvil;
                break;
            case MaskGuyEmotion.angryLow:
                _maskGuyImage.sprite = _maskGuySpriteAngryLow;
                break;
            case MaskGuyEmotion.angryHigh:
                _maskGuyImage.sprite = _maskGuySpriteAngryHigh;
                break;
            case MaskGuyEmotion.neutral:
                _maskGuyImage.sprite = _maskGuySpriteNeutral;
                break;
            case MaskGuyEmotion.scared:
                _maskGuyImage.sprite = _maskGuySpriteScared;
                break;
            case MaskGuyEmotion.surprise:
                _maskGuyImage.sprite = _maskGuySpriteSurprised;
                break;
        }
    }

    public enum MaskGuyEmotion
    {
        happy,
        sad,
        evil,
        angryLow,
        angryHigh,
        neutral,
        scared,
        surprise
    }
}
