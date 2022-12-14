using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CollectedMineral : MonoBehaviour
{
    private Text cm;
    private int restmineral;

    void Start()
    {
        cm = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Main1")
        {
            restmineral = GameObject.FindGameObjectsWithTag("Goal").Length + GameObject.FindGameObjectsWithTag("SecondGoal").Length;
            cm.text = "Rest mission object : " + restmineral;

            if (restmineral == 0)
            {
                cm.text = "Return to spaceship!!";
            }
        }
        else if(SceneManager.GetActiveScene().name == "Main2")
        {
            restmineral = GameObject.FindGameObjectsWithTag("Goal").Length + GameObject.FindGameObjectsWithTag("SecondGoal").Length;
            cm.text = "Rest mission object : " + restmineral;

            if (restmineral == 0)
            {
                cm.text = "Get it to Dragon!!";
            }
        }
        else if(SceneManager.GetActiveScene().name == "Boss1")
        {
            cm.text = "Defeat the Dragon!";
        }
        
    }
}
