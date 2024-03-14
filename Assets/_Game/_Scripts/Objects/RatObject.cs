using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class RatObject : MonoBehaviour
{
    private bool _isAlive = true;
    private Tween _rotationTween;

    private void Start() {


        StartCoroutine(RatAliveMovement());
    }

    public void KillRat()
    {
        if(_isAlive)
        {
            Quaternion targetRotation = transform.rotation * Quaternion.Euler(0f, 0f, 180f);
            transform.DORotateQuaternion(targetRotation, 0.5f);

            _isAlive = false; 
            _rotationTween.Kill();

            AudioHandler.instance.PlaySound_FX_Ob_RatKill();

            Component meatComponent = GetComponent("MeatObject");
            ((Behaviour)meatComponent).enabled = true;
        }
    }

    private IEnumerator RatAliveMovement()
    {
        while (_isAlive)
        {
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = new Vector3(currentPosition.x, currentPosition.y + 0.2f, currentPosition.z);

            // DOTween-Animation für den Sprung
            _rotationTween = 
                transform.DOMove(targetPosition, 0.3f)
                .SetEase(Ease.OutQuad);

            float randomFloat = Random.Range(4f, 8f);
            yield return new WaitForSeconds(randomFloat);
        }
    }


}
