using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    Player player;
    private float bulletDelay = 0.0f;
    private bool bulletReady = true;

    private float mouseY = 0.0f;
    private float mouseX = 0.0f;
    private float mouseSensitivity;
    void Start()
    {
        player = FindObjectOfType<Player>();
        mouseSensitivity = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY += Input.GetAxis("Mouse Y") * mouseSensitivity;
        mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f);
        transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);

        bulletDelay += Time.deltaTime;
        if (bulletDelay > 0.2f)
        {
            bulletReady = true;
        }
        else
        {
            bulletReady = false;
        }


        if(bulletReady && Input.GetMouseButtonDown(0))
        {
            bulletDelay = 0.0f;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
