using UnityEngine;
using UnityEngine.Audio;   // 引用 音效 API
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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
        mixer.SetFloat("VSFX", value);
    }
    public void Play()
    {
        //SceneManager.LoadScene("場景");

        StartCoroutine(Loading());


    }
    private IEnumerator Loading()
    {
        print("測試1");
        yield return new WaitForSeconds(1);
        print("測試2");

        AsyncOperation ao = SceneManager.LoadSceneAsync("遊戲場景");        // 取得場景資訊
        ao.allowSceneActivation = false;                                // 取消載入場景
                                                                        // 當 (場景載入 == 未完成)
        while (ao.isDone == false)
        {
            // 更新介面並等待
            loadingText.text = ((ao.progress / 0.9f) * 100).ToString();     // 載入文字.文字 = (0.9 / 0.9) * 100
            loading.value = ao.progress / 0.9f;                             // 載入滑桿.數值 = 0.9 / 0.9
            yield return new WaitForSeconds(0.0001f);                       // 等待秒數

            // 如果 載入進度 == 0.9 並且 按下任意鍵
            if (ao.progress == 0.9f && Input.anyKey)
            {
                ao.allowSceneActivation = true;
            }
        }
    }   

    public void Replay ()
    {
        SceneManager.LoadScene("選單");
    }

    public void Quit()
    {
        Application.Quit();
    }
}