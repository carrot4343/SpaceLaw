using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject cry1, cry2, cry3, cry4;
    void Start()//�����ϸ� �ι�°�� ������ �̳׶��� ��Ȱ��ȭ��
    {
        cry1.gameObject.SetActive(false);
        cry2.gameObject.SetActive(false);
        cry3.gameObject.SetActive(false);
        cry4.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Goal").Length == 0)//ó�� ���� �̳׶� �� ������ �ι�° �̳׶� Ȱ��ȭ
        {
            cry1.gameObject.SetActive(true);
            cry2.gameObject.SetActive(true);
            cry3.gameObject.SetActive(true);
            cry4.gameObject.SetActive(true);
        }
        
    }

    
}
