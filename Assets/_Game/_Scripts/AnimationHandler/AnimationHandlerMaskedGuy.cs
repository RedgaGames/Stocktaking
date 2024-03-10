using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationHandlerMaskedGuy : MonoBehaviour
{
    [SerializeField] private GameObject _maskedGuyDialog;
    [SerializeField] private GameObject _maskedGuyOutroHappy, _maskedGuyOutroScared, _maskedGuyOutroEvil;
    private RectTransform _maskedGuyDialogRectTransform;
    private RectTransform _maskedGuyDialogDefaultRectTransform;
    private Transform _maskedGuyOutroHappyTransform;
    private Transform _maskedGuyOutroScaredTransform;
    private Transform _maskedGuyOutroEvilTransform;
    private Transform _maskedGuyOutroDefaultPosition;


    private bool _dialogIsPunching = false;

    private void Awake() {
        _maskedGuyDialogRectTransform = _maskedGuyDialog.GetComponent<RectTransform>();
        _maskedGuyOutroHappyTransform = _maskedGuyOutroHappy.GetComponent<Transform>();
        _maskedGuyOutroScaredTransform = _maskedGuyOutroScared.GetComponent<Transform>();
        _maskedGuyOutroEvilTransform = _maskedGuyOutroEvil.GetComponent<Transform>();

        //For reseting Maskposition during the game
        _maskedGuyOutroDefaultPosition = _maskedGuyOutroEvil.transform;
        _maskedGuyDialogDefaultRectTransform = (RectTransform)_maskedGuyDialog.transform;
    }

    private void Start()
    {
        PlayAnimation_MaskedGuyOutro_Evil();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !_dialogIsPunching)
        {
            PlayAnimation_MaskedGuyDialog_NewLine();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayAnimation_MaskedGuyFlyTowardsPlayer();
        }
        
    }

    public void PlayAnimation_MaskedGuyDialog_NewDialog()
    {
        Vector3 targetPosition = _maskedGuyDialogRectTransform.position + new Vector3(0, 50f, 0);

        _maskedGuyDialogRectTransform.DOLocalMove(targetPosition, 2f)
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
        _maskedGuyOutroHappy.SetActive(true);
        
        _maskedGuyOutroHappyTransform.transform.DOMoveY(transform.position.y + 3f, 2f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);

        _maskedGuyOutroHappyTransform.transform.DORotate(new Vector3(20f, 0f, 0f), 5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);
    }

    public void PlayAnimation_MaskedGuyOutro_Scared()
    {
        _maskedGuyOutroScared.SetActive(true);
        
        _maskedGuyOutroScaredTransform.transform.DOMoveY(transform.position.y + 3f, 2f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);

        _maskedGuyOutroScaredTransform.transform.DORotate(new Vector3(20f, 0f, 0f), 5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);
    }    

    public void PlayAnimation_MaskedGuyOutro_Evil()
    {
        _maskedGuyOutroEvil.SetActive(true);

        _maskedGuyOutroEvilTransform.DOShakePosition(10f, 0.3f, 2, 90f, false, true, ShakeRandomnessMode.Harmonic)
        .SetLoops(-1, LoopType.Yoyo);

        _maskedGuyOutroEvilTransform.transform.DORotate(new Vector3(20f, 0f, 0f), 5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);
    }

    public void PlayAnimation_MaskedGuyFlyTowardsPlayer()
    {
        _maskedGuyOutroEvilTransform.DOLocalMoveZ(-5.5f, 3);
    }

    public void HideAllMaskedGuyOnOutro()
    {
        _maskedGuyOutroHappy.SetActive(false);
        _maskedGuyOutroEvil.SetActive(false);
        _maskedGuyOutroScared.SetActive(false);
    }

}
