using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler instance;

    [Header("BackgroundMusic")]
    [SerializeField] AudioClip music_BackgroundMainMenu;
    [SerializeField] AudioClip music_Background1;
    [SerializeField] AudioClip music_Background2;
    [SerializeField] AudioClip music_Background3;

    [SerializeField] AudioClip music_IntroBackground;
    [SerializeField] AudioClip music_Level1;
    [SerializeField] AudioClip music_Level2;
    [SerializeField] AudioClip music_Level3;
    [SerializeField] AudioClip music_LevelFailed;
    [SerializeField] AudioClip music_LevelWin;

    [Header("FX")]
    [SerializeField] AudioClip FX_UI_Options_Open;
    [SerializeField] AudioClip FX_UI_Options_Closed;
    [SerializeField] AudioClip Fx_UI_Click1, Fx_UI_Click2, fx_UI_Click3, fx_UI_Click4, fx_UI_Click5, fx_UI_Click6, fx_UI_Click7, fx_UI_Click8;

    [SerializeField] AudioClip fx_Dialog_PopUp;
    [SerializeField] AudioClip fx_Dialog_Next;
    [SerializeField] AudioClip fx_Monolog_Next;

    [SerializeField] AudioClip fx_InspectMode_Enter;
    [SerializeField] AudioClip fx_InspectMode_Close;

    [SerializeField] AudioClip fx_Intro_Day;
    [SerializeField] AudioClip fx_Intro_Tutorial;

    [SerializeField] AudioClip FX_Ob_ElectricBox_Off;

    [SerializeField] AudioClip FX_Clipboard_Open;
    [SerializeField] AudioClip FX_Clipboard_Close;
    [SerializeField] AudioClip FX_Clipboard_Add;
    [SerializeField] AudioClip FX_Clipboard_Reduce;

    public List<AudioClip> interactFx = new List<AudioClip>();
    public List<AudioClip> ratKillFx = new List<AudioClip>();
    public List<AudioClip> destroySpindFx = new List<AudioClip>();

    private List<AudioSource> fxAudioSources = new List<AudioSource>();
    private List<AudioSource> bgmAudioSources = new List<AudioSource>();

    private enum AudioSourceType { Fx, Bgm }

    //Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    //  ------
    //  Play Mechaniken
    //  ------

    private void PlaySound(AudioClip audioClip, AudioSourceType audioSourceType)
    {
        if (audioClip != null)
        {
            switch (audioSourceType)
            {
                case AudioSourceType.Fx:
                    AddAudioToAudioSource(audioClip, AudioSourceType.Fx, fxAudioSources);
                    break;
                case AudioSourceType.Bgm:
                    AddAudioToAudioSource(audioClip, AudioSourceType.Bgm, bgmAudioSources);
                    break;
                default:
                    return;
            }
        }
    }

    private void AddAudioToAudioSource(AudioClip audioClip, AudioSourceType audioSourceType, List<AudioSource> audioSourceList)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSourceList.Add(audioSource);

        if (audioSourceType == AudioSourceType.Fx)
        {

            audioSource.PlayOneShot(audioClip);
            StartCoroutine(DestroyAudioSource(audioSource, audioClip.length, audioSourceList));
        }
        else if (audioSourceType == AudioSourceType.Bgm)
        {
            audioSource.loop = true; // Loop aktivieren
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    //  ------
    //  Destroy Mechaniken
    //  ------

    private IEnumerator DestroyAudioSource(AudioSource audioSource, float delay, List<AudioSource> audioSourceList)
    {
        yield return new WaitForSeconds(delay);
        audioSourceList.Remove(audioSource);
        Destroy(audioSource);
    }

    public void StopSoundsBGM() { StopSoundsInList(bgmAudioSources); }
    public void StopSoundsFX() { StopSoundsInList(fxAudioSources); }

    private void StopSoundsInList(List<AudioSource> audioSourceList)
    {
        foreach (var audioSource in audioSourceList)
        {
            audioSource.Stop();
            Destroy(audioSource);
        }
        audioSourceList.Clear();
    }    

    //  ------
    //  SoundClips
    //  ------

    //--> BGMusic
    public void PlaySound_Music_MainMenu() { PlaySound(music_BackgroundMainMenu, AudioSourceType.Bgm); }
    public void PlaySound_Music_BGM1() { PlaySound(music_Background1, AudioSourceType.Bgm); }
    public void PlaySound_Music_BGM2() { PlaySound(music_Background2, AudioSourceType.Bgm); }
    public void PlaySound_Music_BGM3() { PlaySound(music_Background3, AudioSourceType.Bgm); }

    public void PlaySound_Music_Intro() { PlaySound(music_IntroBackground, AudioSourceType.Bgm); }
    public void PlaySound_Music_Level1() { PlaySound(music_Level1, AudioSourceType.Bgm); }
    public void PlaySound_Music_Level2() { PlaySound(music_Level2, AudioSourceType.Bgm); }
    public void PlaySound_Music_Level3() { PlaySound(music_Level3, AudioSourceType.Bgm); }
    public void PlaySound_Music_LevelFailed() { PlaySound(music_LevelFailed, AudioSourceType.Bgm); }
    public void PlaySound_Music_LevelWin() { PlaySound(music_LevelWin, AudioSourceType.Bgm); }

    //--> FX
    public void PlaySound_FX_UI_Click1() { PlaySound(Fx_UI_Click1, AudioSourceType.Fx); }
    public void PlaySound_FX_UI_Click2() { PlaySound(Fx_UI_Click2, AudioSourceType.Fx); }
    public void PlaySound_FX_UI_Click3() { PlaySound(fx_UI_Click3, AudioSourceType.Fx); }
    public void PlaySound_FX_UI_Click4() { PlaySound(fx_UI_Click4, AudioSourceType.Fx); }
    public void PlaySound_FX_UI_Click5() { PlaySound(fx_UI_Click5, AudioSourceType.Fx); }
    public void PlaySound_FX_UI_Click6() { PlaySound(fx_UI_Click6, AudioSourceType.Fx); }
    public void PlaySound_FX_UI_Click7() { PlaySound(fx_UI_Click7, AudioSourceType.Fx); }
    public void PlaySound_FX_UI_Click8() { PlaySound(fx_UI_Click8, AudioSourceType.Fx); }
    
    public void PlaySound_FX_UI_Options_Open() { PlaySound(FX_UI_Options_Open, AudioSourceType.Fx); }
    public void PlaySound_FX_UI_Options_Close() { PlaySound(FX_UI_Options_Closed, AudioSourceType.Fx); }
    public void PlaySound_FX_Dialog_PopUp() { PlaySound(fx_Dialog_PopUp, AudioSourceType.Fx); }
    public void PlaySound_FX_Dialog_Next() { PlaySound(fx_Dialog_Next, AudioSourceType.Fx); }
    public void PlaySound_FX_Monolog_Next() { PlaySound(fx_Monolog_Next, AudioSourceType.Fx); }

    public void PlaySound_FX_InspectMode_Open() { PlaySound(fx_InspectMode_Enter, AudioSourceType.Fx); }
    public void PlaySound_FX_InspectMode_Close() { PlaySound(fx_InspectMode_Close, AudioSourceType.Fx); }

    public void PlaySound_FX_Intro_Day() { PlaySound(fx_Intro_Day, AudioSourceType.Fx); }
    public void PlaySound_FX_Intro_Tutorial() { PlaySound(fx_Intro_Tutorial, AudioSourceType.Fx); }

    public void PlaySound_FX_Ob_ElectricBox_Off() { PlaySound(FX_Ob_ElectricBox_Off, AudioSourceType.Fx); }
    public void PlaySound_FX_Ob_Interact(){int randomIndex = Random.Range(0, interactFx.Count); PlaySound(interactFx[randomIndex], AudioSourceType.Fx);}
    public void PlaySound_FX_Ob_RatKill(){int randomIndex = Random.Range(0, ratKillFx.Count); PlaySound(ratKillFx[randomIndex], AudioSourceType.Fx);}
    public void PlaySound_FX_Ob_DestroySpind(){int randomIndex = Random.Range(0, destroySpindFx.Count); PlaySound(destroySpindFx[randomIndex], AudioSourceType.Fx);}
    
    public void PlaySound_FX_Clipboard_Open(){ PlaySound(FX_Clipboard_Open, AudioSourceType.Fx); }
    public void PlaySound_FX_Clipboard_Close(){ PlaySound(FX_Clipboard_Close, AudioSourceType.Fx); }
    public void PlaySound_FX_Clipboard_Add(){ PlaySound(FX_Clipboard_Add, AudioSourceType.Fx); }
    public void PlaySound_FX_Clipboard_Reduce(){ PlaySound(FX_Clipboard_Reduce, AudioSourceType.Fx); }

}
