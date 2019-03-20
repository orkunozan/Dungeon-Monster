using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float mouseSensitivity;
    float xAxislimit;
    public Transform playerBody;
    float mouseY = 0f;
    float mouseX = 0f;


    private void Awake()
    {
        LockCursor();

        xAxislimit = 0.0f;



    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        CameraRotation();
    }


    private void CameraRotation()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, -90, 55);
        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);  //Only player move
    }









}