using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] protected bool canInspected = false;
    [SerializeField] protected GameObject _inspectObject;

    protected bool isFirstClick = true;

    MouseClickDetector mouseClickDetector;
    ScreenHandler screenHandler;

    protected Rigidbody _rig;

    protected virtual void Start()
    {
        _rig = GetComponent<Rigidbody>();

        mouseClickDetector = FindObjectOfType<MouseClickDetector>();
        screenHandler = FindObjectOfType<ScreenHandler>();
    }

    public virtual void InteractWithItem()
    {
        if (mouseClickDetector.LastMouseButtonClicked == MouseButtonType.leftButton)
        {
            ApplyForce();
        }
        if (mouseClickDetector.LastMouseButtonClicked == MouseButtonType.rightButton)
        {
            if (canInspected)
            {
                InspectItem();
            }
        }
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
        outline.OutlineColor = _OutlineColor;
        outline.OutlineWidth = 7f;
    }

    protected void InspectItem()
    {
        if (!_inspectObject){ Debug.Log("Kein Item zum Inspecten hinterlegt"); return; }
        _inspectObject.SetActive(true);
        screenHandler.ShowInspectScreen();
    }

}
