using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;

public class AnimationHandlerUI : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject _endLevelScreen;
    [SerializeField] private GameObject _dialogTextScreen;
    [SerializeField] private GameObject _outroTextScreen;
    [SerializeField] private GameObject _introTextScreen;
    [SerializeField] private GameObject _inspectScreen;

    [Header("Backgrounds")]
    [SerializeField] private GameObject _dimedBackground;
    [SerializeField] private GameObject _blackBackground;

    private RectTransform _endLevelScreenRectTransform;
    private RectTransform _dialogTextScreenRectTransform;
    private RectTransform _inspectScreenRectTransform;

    private Image _dimedBackgroundImage;
    private Image _blackBackgroundImage;

    private void Awake() {
        _dimedBackgroundImage = _dimedBackground.GetComponent<Image>();
        _blackBackgroundImage = _blackBackground.GetComponent<Image>();

        _endLevelScreenRectTransform = _endLevelScreen.GetComponent<RectTransform>();
        _dialogTextScreenRectTransform = _dialogTextScreen.GetComponent<RectTransform>();
        _inspectScreenRectTransform = _inspectScreen.GetComponent<RectTransform>();        
    }

    //EndScreen
    public void PlayAnimation_EndLevelScreen_FadeIn(){
        _endLevelScreen.SetActive(true);
        _endLevelScreenRectTransform.transform.localPosition = new Vector3(0f, 1000f, 0f); _endLevelScreenRectTransform.DOAnchorPos(new Vector2(0f, 0f), 1f, false).SetEase(Ease.OutElastic);
        }

    public void PlayAnimation_EndLevelScreen_FadeOut(){ _endLevelScreenRectTransform.DOAnchorPos(new Vector2(0f, -1000f), 0.4f, false).OnComplete(() => _endLevelScreen.SetActive(false));}

    //DialogText
    public void PlayAnimation_DialogScreen_FadeIn(){
        _dialogTextScreenRectTransform.DOAnchorPos(new Vector2(-2000f, -340f), 0f, false).OnComplete(() => _dialogTextScreen.SetActive(true));
        _dialogTextScreenRectTransform.DOAnchorPos(new Vector2(0f, -340f), 0.4f, true).SetEase(Ease.OutBack);
        }

    public void PlayAnimation_DialogScreen_FadeOut(){ _dialogTextScreenRectTransform.DOAnchorPos(new Vector2(2000f, -340f), 0.4f, false).OnComplete(() => _dialogTextScreen.SetActive(false));}

    //IntroText

    public void PlayAnimation_IntroText()
    {
        StartCoroutine(PlayAnimation_IntroText_Routine());
    }

    private IEnumerator PlayAnimation_IntroText_Routine()
    {
        PlayAnimation_BlackBackground_FadeOut(3f);
        _introTextScreen.SetActive(true);
        AudioHandler.instance.PlaySound_FX_Intro_Day();
        yield return new  WaitForSeconds(2f);
        PlayAnimation_BlackBackground_FadeIn(1.5f);
        yield return new  WaitForSeconds(1.5f);
        _introTextScreen.SetActive(false);

        StateHandler.Instance.UpdateGameState(StateHandler.GameState.IntroMaskedGuy);
    
    }

    //OUTRO TEXT
    public void PlayAnimation_OutroText_FadeIn()
    {
        StartCoroutine(PlayAnimation_OutroText_FadeIn_Routine());
    }

    private IEnumerator PlayAnimation_OutroText_FadeIn_Routine()
    {   
        PlayAnimation_BlackBackground_FadeIn(1f);
        yield return new  WaitForSeconds(1f);
        _outroTextScreen.SetActive(true);
        PlayAnimation_BlackBackground_FadeOut(1f);
    }

    public void PlayAnimation_OutroText_FadeIn_AsIntro()
    {
        StartCoroutine(PlayAnimation_OutroText_FadeIn_AsIntro_Routine());
    }    

    private IEnumerator PlayAnimation_OutroText_FadeIn_AsIntro_Routine()
    {   
        _outroTextScreen.SetActive(true);
        yield return new  WaitForSeconds(1f);
        PlayAnimation_BlackBackground_FadeOut(1f);
    }    

    public void PlayAnimation_OutroText_FadeOut()
    {
        PlayAnimation_BlackBackground_FadeIn(1f);
        _outroTextScreen.SetActive(false);
    }

    //INSPECT SCREEN
    //TODO Add Animation later
    public void PlayAnimation_InspectScreen_FadeIn()
    {
        _inspectScreen.SetActive(true);
    }

    public void PlayAnimation_InspectScreen_FadeOut()
    {
        _inspectScreen.SetActive(false);
    }


    //DIMED SCREEN
    public void PlayAnimation_DimedBackground_FadeIn()
    {
        _dimedBackgroundImage.DOFade(0f, 0f);
        _dimedBackground.SetActive(true);
        _dimedBackgroundImage.DOFade(0.8f, 0.4f);
    }

    public void PlayAnimation_DimedBackground_FadeOut()
    {
        _dimedBackgroundImage.DOFade(0f, 0.4f).OnComplete(() => _dimedBackground.SetActive(false));
    }

    //BLACK SCREEN 
    public void PlayAnimation_BlackBackground_FadeIn(float newFadeInDuration)
    {
        _blackBackgroundImage.DOFade(0f, 0f);
        _blackBackground.SetActive(true);
        _blackBackgroundImage.DOFade(1f, newFadeInDuration);
    }    

    public void PlayAnimation_BlackBackground_FadeOut(float newFadeOutDuration)
    {
        _blackBackground.SetActive(true);
        _blackBackgroundImage.DOFade(0f, newFadeOutDuration).OnComplete(() => _blackBackground.SetActive(false));
    }  
}
