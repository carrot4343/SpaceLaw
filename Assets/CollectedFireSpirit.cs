using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedFireSpirit : MonoBehaviour
{
    private Text cm;
    private int restFireSpirit;

    void Start()
    {
        cm = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        restFireSpirit = GameObject.FindGameObjectsWithTag("Goal").Length + GameObject.FindGameObjectsWithTag("SecondGoal").Length;
        cm.text = "Rest of Fire Spirit : " + restFireSpirit;

        if (restFireSpirit == 0)
        {
            cm.text = "Visit the NPC!!";
        }
    }
}
