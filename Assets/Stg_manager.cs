using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stg_manager : MonoBehaviour
{
    

    public AudioSource audioSource;
    public AudioClip backGroundMusic;
    public AudioClip getItemMusic;

    public static Stg_manager instance = null;

    public Vector3 startLocation = new Vector3(42.1f, 10.0f, 47.48f);
    private Player player;
    private int restGoal;
    private int playerLives = 3;

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
        player = FindObjectOfType<Player>();

        audioSource = player.gameObject.AddComponent<AudioSource>();
        audioSource.clip = getItemMusic;
        audioSource.loop = false;
    }


    void Update()
    {
        if(gameOver())
        {
            if(SceneManager.GetActiveScene().name == "Main1")
            {
                LoadFail1();
            }
            if(SceneManager.GetActiveScene().name == "Main2" || SceneManager.GetActiveScene().name == "Boss1")
            {
                LoadFail2();
            }
        }
    }

    public void decreaseLife()
    {
        playerLives -= 1;
        UI_manager.instance.manageLives(playerLives);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = startLocation;
        player.GetComponent<CharacterController>().enabled = true;
    }

    public void increaseLife()
    {
        playerLives += 1;
        UI_manager.instance.manageLives(playerLives);
    }

    public bool gameOver()
    {
        if(playerLives <= 0)
        {
            return true;
        }
        return false;
    }

    public void loadNextScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "tutorial":
                SceneManager.LoadScene("Main1");
                break;
            case "Main1":
                SceneManager.LoadScene("Main2");
                break;
            case "Main2":
                SceneManager.LoadScene("Boss1");
                break;
            case "Boss1":
                SceneManager.LoadScene("Win2");
                break;
        }
    }

    public bool win()
    {
        if (restGoal == 0)
        {
            return true;
        }
        return false;
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("tutorial");
    }
    public void LoadMain1()
    {
        SceneManager.LoadScene("Main1");
    }

    public void LoadMain2()
    {
        SceneManager.LoadScene("Main2");
    }

    public void LoadBoss1()
    {
        SceneManager.LoadScene("Boss1");
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void LoadWin1()
    {
        SceneManager.LoadScene("Win1");
    }
    public void LoadFail1()
    {
        SceneManager.LoadScene("Fail1");
    }
    public void LoadFail2()
    {
        SceneManager.LoadScene("Fail2");
    }

    public void SetStartPoint(Vector3 point)
    {
        startLocation = point;
    }

    public Vector3 GetStartPoint()
    {
        return startLocation;
    }
}
