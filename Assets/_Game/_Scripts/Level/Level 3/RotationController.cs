using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] GameObject _mainCamera;
    [SerializeField] GameObject _ItemContainer;

    DirectorLevel3 directorLevel3;

    private float _currentYRotation;

    private int _currentWall = 1;
    private int _latestWall = 1;

    private bool _isInFakeRoom = false;
    private bool _isRatsTriggerd = false;

    private void Start() {
        directorLevel3 = FindObjectOfType<DirectorLevel3>();
    }
    
    private void Update() 
    {
        CheckCurrentRotation();
    }


    private void CheckCurrentRotation()
    {
        _currentYRotation = _mainCamera.transform.eulerAngles.y;

        if (_currentYRotation == 0)
        {
            _currentWall = 1;
            
            if (_isRatsTriggerd)
            {
                directorLevel3.FirstTimeOtherRatSeen();
            }
            _latestWall = 1;
        }

        if (_currentYRotation == 90)
        {
            _currentWall = 2;

            if (_latestWall == 1)
            {
                if (!_isInFakeRoom)
                {
                    directorLevel3.MoveCameraToFakeRoom();
                    _ItemContainer.SetActive(false);
                    _isInFakeRoom = true;
                }
            }

            else if (_latestWall == 3)
            {
                if (_isInFakeRoom)
                {
                    directorLevel3.MoveCameraToRealRoom();
                    _ItemContainer.SetActive(true);
                    _isInFakeRoom = false;
                }
            }
            _latestWall = 2;
        }        

        if (_currentYRotation == 180)
        {
            _currentWall = 3;
            _latestWall = 3;

            if (!_isInFakeRoom)
            {
                directorLevel3.FirstTimeRatsSeen();
                _isRatsTriggerd = true;
            }
        }

        if (_currentYRotation == 270)
        {
            _currentWall = 4;
            _latestWall = 4;
        }

        if (_currentYRotation == 360)
        {
            if (_isRatsTriggerd)
            {
                directorLevel3.FirstTimeOtherRatSeen();
            }
        }
    }


}
