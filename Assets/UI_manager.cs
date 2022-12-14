using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    
    static private int MAX_LIFE = 3;
    static private int MAX_ITEM_SLOT = 3;

    public GameObject pausedText, retryButton, titleButton;
    public GameObject[] lifeObject = new GameObject[MAX_LIFE];
    public GameObject minimapObject;
    public GameObject[] inventorySlot = new GameObject[MAX_ITEM_SLOT + 1];
    public Slider bossHpBar;

    private Vector2 minimapOriginalSize, minimapOriginalPos;

    private Inventory inventory;
    private Boss boss;

    public static UI_manager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        boss = FindObjectOfType<Boss>();
        minimapOriginalSize = minimapObject.GetComponent<RectTransform>().sizeDelta;
        minimapOriginalPos = minimapObject.GetComponent<RectTransform>().anchoredPosition;


        pausedText.SetActive(false);
        retryButton.SetActive(false);
        titleButton.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        enLargeMinimap();
        manageBossHp();
    }

    void enLargeMinimap()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            minimapObject.GetComponent<RectTransform>().sizeDelta = new Vector2(600, 600);
            minimapObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            minimapObject.GetComponent<RectTransform>().sizeDelta = minimapOriginalSize;
            minimapObject.GetComponent<RectTransform>().anchoredPosition = minimapOriginalPos;
        }
    }

    public void manageLives(int playerLives)
    {
        switch(playerLives)
        {
            case 1:
                lifeObject[0].SetActive(true);
                lifeObject[1].SetActive(false);
                lifeObject[2].SetActive(false);
                break;

            case 2:
                lifeObject[0].SetActive(true);
                lifeObject[1].SetActive(true);
                lifeObject[2].SetActive(false);
                break;

            case 3:
                lifeObject[0].SetActive(true);
                lifeObject[1].SetActive(true);
                lifeObject[2].SetActive(true);
                break;
        }
    }

    public void pauseResumeButton()
    {
        if (Time.timeScale == 0)
        {
            pausedText.SetActive(false);
            retryButton.SetActive(false);
            titleButton.SetActive(false);
            Time.timeScale = 1;
        }
        else if (Time.timeScale == 1)
        {
            pausedText.SetActive(true);
            retryButton.SetActive(true);
            titleButton.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void manageBossHp()
    {
        bossHpBar.value = boss.bossHP * 0.001f;
    }
}
