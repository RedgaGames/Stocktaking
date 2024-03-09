using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class InteractObject : MonoBehaviour
{
    [SerializeField] bool _canRotate = false;
    [SerializeField] float _rotationSpeed = 5f;
    [SerializeField] string _itemName;

    [SerializeField] TextMeshProUGUI _itemNameText;

    ScreenHandler screenHandler;
    private float _mouseWheelInput;

    private void Start()
    {
        screenHandler = FindObjectOfType<ScreenHandler>();
    }

    private void OnEnable() {
        _itemNameText.text = _itemName;
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
        gameObject.SetActive(false);

        StateHandler.Instance.UpdateGameState(StateHandler.GameState.MainGame);
    }
}
