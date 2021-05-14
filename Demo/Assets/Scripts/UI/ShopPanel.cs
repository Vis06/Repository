using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    Button returnBtn;
    Text text;
    public Button girl;
    public Button boy;
    public Button rapper;
    public Button ninja;
    public GameObject boyImage;
    public GameObject rapperImage;
    public GameObject ninjaImage;
    public List<GameObject> RedPoints;
    public GameObject VideoPanel;
    public Button VideoPanelCloseBtn;
    private void Awake()
    {
        text = transform.Find("diamond").GetComponent<Text>();
        VideoPanelCloseBtn.onClick.AddListener(() => {

            VideoPanel.SetActive(false);
        
        });
    }
    // Start is called before the first frame update
    void Start()
    {
      
        ShowRedPoint(0);
        if (PlayerPrefs.GetInt("bIsSold") > 0)
        {
            boyImage.SetActive(false);
        }
        if (PlayerPrefs.GetInt("rIsSold") > 0)
        {
           
           
            rapperImage.SetActive(false);
        }
        if (PlayerPrefs.GetInt("nIsSold") > 0)
        {
            
            ninjaImage.SetActive(false);
          
        }
        returnBtn = transform.Find("returnBtn").GetComponent<Button>();
        returnBtn.onClick.AddListener(()=>{

            gameObject.SetActive(false);
        });
        girl.onClick.AddListener(() => {

            PlayerPrefs.SetString("CurrentRole", "Player");
            ShowRedPoint(0);


        });
        boy.onClick.AddListener(() => {
            if (PlayerPrefs.GetInt("bIsSold") > 0)
            {
                PlayerPrefs.SetString("CurrentRole", "Boy");
                ShowRedPoint(1);
                boyImage.SetActive(false);
            }
            else
            {
                if (PlayerPrefs.GetInt("Diamond") >= 100)
                {
                    PlayerPrefs.SetInt("Diamond",PlayerPrefs.GetInt("Diamond") - 100);
                    RefreshText();
                    PlayerPrefs.SetInt("bIsSold", 1);
                    boyImage.SetActive(false);
                }
                else
                {
                    VideoPanel.SetActive(true);
                }
               
            }
        });
        rapper.onClick.AddListener(() => {
            if (PlayerPrefs.GetInt("rIsSold") > 0)
            {
                PlayerPrefs.SetString("CurrentRole", "Rapper");
                ShowRedPoint(2);
                rapperImage.SetActive(false);
            }
            else
            {
                if (PlayerPrefs.GetInt("Diamond") >= 200)
                {
                    PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - 200);
                    RefreshText();
                    PlayerPrefs.SetInt("rIsSold", 1);
                    rapperImage.SetActive(false);
                }
                else
                {
                    VideoPanel.SetActive(true);
                }
            }

        });
        ninja.onClick.AddListener(() => {
            if (PlayerPrefs.GetInt("nIsSold") > 0)
            {
                PlayerPrefs.SetString("CurrentRole", "Ninja");
                ninjaImage.SetActive(false);
                ShowRedPoint(3);
            }
            else
            {
                if (PlayerPrefs.GetInt("Diamond") >= 300)
                {
                    PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - 300);
                    RefreshText();
                    PlayerPrefs.SetInt("nIsSold", 1);
                    ninjaImage.SetActive(false);
                }
                else
                {
                    VideoPanel.SetActive(true);
                }
               
            }

        });
    }
    private void ShowRedPoint(int num)
    {
        for (int i = 0; i <RedPoints.Count ; i++)
        {
            if (i != num)
            {
                RedPoints[i].SetActive(false);
            }
          
        }
        RedPoints[num].SetActive(true);
    }
    private void RefreshText()
    {
        text.text = PlayerPrefs.GetInt("Diamond").ToString();
    }
    private void OnEnable()
    {
        RefreshText();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
