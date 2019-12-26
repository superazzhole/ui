
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int hp = 100;
    public Slider hpSlider;

    public Text textChicken;
    public int chickenCount;
    public int chickenTotal;

    public Text textTime;
    public float gameTime;

    public GameObject final;
    public Text textBest;
    public Text textCurrent;

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);

        if (other.tag == "陷阱")
        {
            int d = other.GetComponent<Trap>().damage;
            hp -= d;
            hpSlider.value = hp;
        }
        if (other.tag == "雞腿")
        {
            chickenCount++;
            textChicken.text = "Chicken : " + chickenCount + " / " + chickenTotal;
            Destroy(other.gameObject);

        }

        if(other.name == "終點" && chickenCount == chickenTotal)
        {
            GameOver();
        }
 
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "陷阱")
        {
            int d = other.GetComponent<Trap>().damage;
            hp -= d;
            hpSlider.value = hp;
        }

    }
    private void Start()
    {
        if (PlayerPrefs.GetFloat("最佳紀錄") == 0)
        {
            PlayerPrefs.SetFloat("最佳紀錄", 99999);

        }
        chickenTotal = GameObject.FindGameObjectsWithTag("雞腿").Length;
        textChicken.text = "Chicken : 0/" + chickenTotal;

    }

    private void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        gameTime += Time.deltaTime;
        textTime.text = gameTime.ToString("F2");
    }

    private void GameOver()
    {
        final.SetActive(true);
        textCurrent.text = "TIME : " + gameTime.ToString("F2");

        if (gameTime < PlayerPrefs.GetFloat("最佳紀錄"))
        {
            PlayerPrefs.SetFloat("最佳紀錄", gameTime);
        }

        textBest.text = "BEST : " + PlayerPrefs.GetFloat("最佳紀錄").ToString("F2");

        Cursor.lockState = CursorLockMode.None;
    }
}
