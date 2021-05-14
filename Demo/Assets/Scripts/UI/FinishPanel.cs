using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishPanel : MonoBehaviour
{
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = transform.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {

            switch (PlayerPrefs.GetInt("Level"))
            {
                case 0:SceneManager.LoadScene("DrunkDemo");break;
                case 1: SceneManager.LoadScene("LevelOne");break;
                case 2: SceneManager.LoadScene("LevelTwo");break;
                case 3: SceneManager.LoadScene("LevelThree");break;
                case 4: SceneManager.LoadScene("LevelFour"); break;
                default:
                    SceneManager.LoadScene("StartScene");
                    PlayerPrefs.SetInt("Level", 0);
                    break;
            }
        });
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
