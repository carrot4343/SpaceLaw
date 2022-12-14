using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour
{
    public Camera mainCamera;
    public Camera backViewCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        backViewCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            mainCamera.enabled = false;
            backViewCamera.enabled = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            mainCamera.enabled = true;
            backViewCamera.enabled = false;
        }
    }

    
}
