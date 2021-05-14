using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public Button btn;
    public Slider slider;
    public Text text;
    public Text diamondText;
    public GameObject ShopPanel;
    public Button Shop;
    private void Awake()
    {

        //PlayerPrefs.SetInt("nIsSold", 0);
        //PlayerPrefs.SetInt("rIsSold", 0);
        //PlayerPrefs.SetInt("bIsSold", 0);
        PlayerPrefs.SetInt("Diamond", 0);

    }
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("Level").Equals(0)) 
        {

            text.text = "0/5";
        }
        else
        {
            slider.value = (PlayerPrefs.GetInt("Level")) / 5.0f;
            text.text = (PlayerPrefs.GetInt("Level")).ToString() + "/5";
        }
       // diamondText.text = PlayerPrefs.GetInt("Diamond").ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        Shop.onClick.AddListener(() => {
            ShopPanel.SetActive(true);
        });
       
        btn.onClick.AddListener(() => {
            if (PlayerPrefs.GetInt("Level").Equals(0))
            {
                SceneManager.LoadScene("DrunkDemo");
            }
            else
            {
                switch (PlayerPrefs.GetInt("Level"))
                {
                    case 1: SceneManager.LoadScene("LevelOne"); break;
                    case 2: SceneManager.LoadScene("LevelTwo"); break;
                    case 3: SceneManager.LoadScene("LevelThree"); break;
                    case 4: SceneManager.LoadScene("LevelFour"); break;
                    default:SceneManager.LoadScene("DrunkDemo");break;
                }
            }
        });
        PlayerPrefs.SetString("CurrentRole", "Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Level", 0);
    }
}
