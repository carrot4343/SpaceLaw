using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stg2_Timer : MonoBehaviour
{
    // Start is called before the first frame update
    private Text timerText;
    private float time;
    private int currentTime;

    void Start()
    {
        timerText = GetComponent<Text>();
        time = 180;
    }
    void Update()
    {
        time -= Time.deltaTime;
        currentTime = (int)time;
        timerText.text = "Time Left : " + currentTime;
        if(time <= 0)
        {
            SceneManager.LoadScene("Fail1");
        }
    }
}
