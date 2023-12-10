﻿
using UnityEngine;


public class MouseComponent : MonoBehaviour
{
    public SFader sceneFader;
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

   
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

   
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if(Input.GetKey(KeyCode.E))
        {
            sceneFader.FadeOut("SampleScene");
            
        }
    }

   
}
