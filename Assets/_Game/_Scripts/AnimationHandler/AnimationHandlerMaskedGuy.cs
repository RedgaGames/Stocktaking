using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationHandlerMaskedGuy : MonoBehaviour
{
    [SerializeField] private GameObject _maskedGuyDialog;
    [SerializeField] private GameObject _maskedGuyOutro;
    private RectTransform _maskedGuyDialogRectTransform;
    private Transform _maskedGuyOutroTransform;

    private bool _dialogIsPunching = false;

    private void Start()
    {
        _maskedGuyDialogRectTransform = _maskedGuyDialog.GetComponent<RectTransform>();
        _maskedGuyOutroTransform = _maskedGuyOutro.GetComponent<Transform>();

        PlayAnimation_MaskedGuyDialog_NewDialog();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !_dialogIsPunching)
        {
            PlayAnimation_MaskedGuyDialog_NewLine();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayAnimation_MaskedGuyOutro_Happy();
        }
        
    }




    public void PlayAnimation_MaskedGuyDialog_NewDialog()
    {
        Vector3 targetPosition = _maskedGuyDialogRectTransform.position + new Vector3(0, 50f, 0);

        _maskedGuyDialogRectTransform.DOMove(targetPosition, 2f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);
    }

    public void PlayAnimation_MaskedGuyDialog_NewLine()
    {
        _dialogIsPunching = true;

        Vector3 punchScale = new Vector3(0.5f, 0.5f, 0.5f);
        _maskedGuyDialogRectTransform.DOPunchScale(punchScale, 0.4f, 8, 0.7f)
            .OnComplete(() => _dialogIsPunching = false);
    }

    public void PlayAnimation_MaskedGuyOutro_Happy()
    {
        //Move
        _maskedGuyOutroTransform.transform.DOMoveY(transform.position.y + 3f, 2f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);

        // Verwende DOTween für die leichte Rotation auf der Y-Achse
        _maskedGuyOutroTransform.transform.DORotate(new Vector3(20f, 0f, 0f), 5f)
            .SetLoops(-1, LoopType.Yoyo) // Endlos wiederholen, um kontinuierliche Rotation zu erhalten
            .SetEase(Ease.InOutQuad);
    }


}
