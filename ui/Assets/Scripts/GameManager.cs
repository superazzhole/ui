using UnityEngine;
using UnityEngine.Audio;   // 引用 音效 API
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioMixer mixer;

    public Text loadingText;
    public Slider loading;

    public void SetVBGM(float value)
    {
        mixer.SetFloat("VBGM", value);

    }
    public void SetVSFX(float value)
    { 
    mixer.SetFloat("VSFX",value);
        }
    public void Play()
    {
        SceneManager.LoadScene("場景");
    
    
    }

}
