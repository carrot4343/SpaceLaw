using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    public GameObject fireBallPrefab;
    public float interval;

    IEnumerator Start()
    { // yield�� ����ϱ� ���� IEnumerator type���� return
        while (true)
        {
            Instantiate(fireBallPrefab, transform.position, transform.rotation);
            // �÷��� �����͸� �ϳ��� return �� ���� ���� ��ġ ��� (Unity�� coroutine ����)
            yield return new WaitForSeconds(interval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
