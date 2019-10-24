using UnityEngine;
using UnityEngine.Audio;   // 引用 音效 API

public class GameManager : MonoBehaviour
{
   public AudioMixer mixer;
    
   public void SetVBGM(float value)
    {
        mixer.SetFloat("VBGM", value);

    }
}
