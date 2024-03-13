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

    private bool _isLightOn = true;

    private void Start() {
        animationHandlerLevel = FindObjectOfType<AnimationHandlerLevel>();

        LightFlickering(45f);
    }
  
    public void ActivateLight()
    {
        if (_isLightOn)
        {
            _electricBoxGreenLight.SetActive(false);
            _electricBoxRedLight.SetActive(true);

            _mainLight.SetActive(false);

            animationHandlerLevel.PlayAnimationElectricBoxLeverDown();

            _isLightOn = false;
        }
        else
        {
            _electricBoxGreenLight.SetActive(true);
            _electricBoxRedLight.SetActive(false);

            _mainLight.SetActive(true);

            animationHandlerLevel.PlayAnimationElectricBoxLeverUp();

            _isLightOn = true;
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
        if (_isLightOn)
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
