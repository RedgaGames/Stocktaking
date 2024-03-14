using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Handles all DOTWEEN Animations for Levelelements like eletricbox
/// </summary>

public class AnimationHandlerLevel : MonoBehaviour
{
    [SerializeField] private GameObject _electricBoxLever;

    Transform _electricBoxLeverTransform;

    private void Start() 
    {
        _electricBoxLeverTransform = _electricBoxLever.GetComponent<Transform>();
    }

    // Electricbox
    public void PlayAnimationElectricBoxLeverUp()
    {
        _electricBoxLeverTransform.DOLocalMoveY(1.6f, 0.5f);
    }

    public void PlayAnimationElectricBoxLeverDown()
    {
        _electricBoxLeverTransform.DOLocalMoveY(0.6f, 0.5f);
    }

}
