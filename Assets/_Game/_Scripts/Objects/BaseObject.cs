using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base for objects for click and outline mechanics
/// </summary>
public class BaseObject : MonoBehaviour
{
    [SerializeField] protected float _force;
    [SerializeField] protected float _applyForceRangeMinX = -1f;
    [SerializeField] protected float _applyForceRangeMaxX = 1f;
    [SerializeField] protected float _applyForceRangeMinY = -1f;
    [SerializeField] protected float _applyForceRangeMaxY = 1f;
    [SerializeField] protected Color _OutlineColor;
    [SerializeField] protected bool canGetOutline = false;
    protected bool isFirstClick = true;

    protected Rigidbody _rig;

    protected virtual void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }

    public virtual void ApplyForce()
    {
        float randomX = Random.Range(_applyForceRangeMinX, _applyForceRangeMaxX);
        float randomZ = Random.Range(_applyForceRangeMinY, _applyForceRangeMaxY);
        Vector3 randomDirection = new Vector3(randomX, 0f, randomZ).normalized;

        Vector3 upDirection = Vector3.up;
        Vector3 finalForce = randomDirection + upDirection;

        _rig.AddForce(finalForce.normalized * _force, ForceMode.Impulse);

        if (isFirstClick)
        {
            isFirstClick = false;
            if (canGetOutline)
            {
                AddOutline();
            }
        }
    }

    protected void AddOutline()
    {
        var outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.red;
        outline.OutlineWidth = 7f;
    }
}