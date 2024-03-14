using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles all lights
/// </summary>

public class LightHandler : MonoBehaviour
{
    [SerializeField] private GameObject _mainLight;
    [SerializeField] private GameObject _electricBoxRedLight;
    [SerializeField] private GameObject _electricBoxGreenLight;

    AnimationHandlerLevel animationHandlerLevel;

    public bool IsLightOn {get; private set;}

    private void Start() {
        animationHandlerLevel = FindObjectOfType<AnimationHandlerLevel>();

        LightFlickering(45f);

        IsLightOn = true;
    }
  
    public void ActivateLight()
    {
        if (IsLightOn)
        {
            _electricBoxGreenLight.SetActive(false);
            _electricBoxRedLight.SetActive(true);

            _mainLight.SetActive(false);

            animationHandlerLevel.PlayAnimationElectricBoxLeverDown();

            IsLightOn = false;
            AudioHandler.instance.PlaySound_FX_Ob_ElectricBox_Off();
        }
        else
        {
            _electricBoxGreenLight.SetActive(true);
            _electricBoxRedLight.SetActive(false);

            _mainLight.SetActive(true);

            animationHandlerLevel.PlayAnimationElectricBoxLeverUp();

            IsLightOn = true;
            AudioHandler.instance.PlaySound_FX_UI_Click8();
        }
    }

    public void LightFlickering(float interval)
    {
        StartCoroutine(LightFlickeringRoutine(interval));
    }

    private IEnumerator LightFlickeringRoutine(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            StartCoroutine(StartLightFlickerSmall());
        }


    }

    private IEnumerator StartLightFlickerSmall()
    {
        if (IsLightOn)
        {
            _mainLight.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            _mainLight.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            _mainLight.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            _mainLight.SetActive(true);
        }
    }

    public IEnumerator StartLightFlickerLarge()
    {
        _mainLight.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        _mainLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _mainLight.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        _mainLight.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        ActivateLight();
    }


}
