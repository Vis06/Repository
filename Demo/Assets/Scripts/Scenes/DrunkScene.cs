using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DrunkScene : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject game = Instantiate(Resources.Load<GameObject>(PlayerPrefs.GetString("CurrentRole")));
        game.name = "Player";
    }
    void Start()
    {
        btn.onClick.AddListener(() => {
            switch (PlayerPrefs.GetInt("Level"))
            {
                case 1: SceneManager.LoadScene("LevelOne"); break;
                case 2: SceneManager.LoadScene("LevelTwo"); break;
                case 3: SceneManager.LoadScene("LevelThree"); break;
                case 4:SceneManager.LoadScene("LevelFour");break;
                default:
                    SceneManager.LoadScene("StartScene");
                    break;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
