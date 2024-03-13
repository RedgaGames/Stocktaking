using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatLightController : MonoBehaviour
{
    MeatController meatController;
    LightHandler lightHandler;

    private void Start() {
        meatController = FindObjectOfType<MeatController>();
        lightHandler = FindObjectOfType<LightHandler>();
    }

    public void StartLightsOutEvent()
    {
        if (!lightHandler.IsLightOn)
        {
            meatController.HideNotVisibleObjects();
        }
        else if (lightHandler.IsLightOn)
        {
            meatController.ShowNotVisibleObjects();
        }
    
    }
}
