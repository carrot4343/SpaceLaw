using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject cry1, cry2, cry3, cry4;
    void Start()//시작하면 두번째로 나오는 미네랄을 비활성화함
    {
        cry1.gameObject.SetActive(false);
        cry2.gameObject.SetActive(false);
        cry3.gameObject.SetActive(false);
        cry4.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Goal").Length == 0)//처음 나온 미네랄 다 먹으면 두번째 미네랄 활성화
        {
            cry1.gameObject.SetActive(true);
            cry2.gameObject.SetActive(true);
            cry3.gameObject.SetActive(true);
            cry4.gameObject.SetActive(true);
        }
        
    }

    
}
