using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField] bool _canRotate = false;
    [SerializeField] float _rotationSpeed = 5f;

    ScreenHandler screenHandler;
    private float _mouseWheelInput;

    private void Start()
    {
        screenHandler = FindObjectOfType<ScreenHandler>();
    }

    private void Update()
    {
        CheckForInputs();
    }

    private void CheckForInputs()
    {
        // MouseWheel
        _mouseWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (_mouseWheelInput != 0)
        {
            if (_canRotate)
            {
                RotateObject(_mouseWheelInput);
            }

        }

        //RightClick
        if (Input.GetMouseButtonDown(1))
        {
            EndInspection();
        }
    }


    void RotateObject(float direction)
    {
        Vector3 rotationAxis = new Vector3(0, 1, 0);
        float rotationAmount = direction * _rotationSpeed;

        Quaternion rotation = Quaternion.Euler(rotationAxis * rotationAmount);

        transform.Rotate(rotation.eulerAngles);
    }

    private void EndInspection()
    {
        screenHandler.HideInspectScreen();
        gameObject.SetActive(false);
    }
}
