using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private float mouseY = 0.0f;
    private float mouseX = 0.0f;
    private float mouseSensitivity;
    // Start is called before the first frame update
    void Start()
    {
        mouseSensitivity = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY += Input.GetAxis("Mouse Y") * mouseSensitivity;
		mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f);
        transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
    }
}
