using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class contains all methods for the dialogsystem. A dialog needs a text and an emotion.
/// </summary>

public class DialogHandler : MonoBehaviour
{
    [SerializeField] private GameObject _dialogScreen;
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private Image _maskGuyImage;
    [Header("Mask Guy Sprites")]
    [SerializeField] private Sprite _maskGuySpriteHappy;
    [SerializeField] private Sprite _maskGuySpriteSad;
    [SerializeField] private Sprite _maskGuySpriteEvil;
    [SerializeField] private Sprite _maskGuySpriteAngryLow;
    [SerializeField] private Sprite _maskGuySpriteAngryHigh;
    [SerializeField] private Sprite _maskGuySpriteNeutral;
    [SerializeField] private Sprite _maskGuySpriteScared;
    [SerializeField] private Sprite _maskGuySpriteSurprised;

    public void ShowDialog(string newDialogText, MaskGuyEmotion newMaskGuyEmotion)
    {
        _dialogText.SetText(newDialogText);

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
