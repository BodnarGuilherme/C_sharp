using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCam : MonoBehaviour
{
    public float mouseSensi;
    GameObject playerBody;


    float mouseY, mouseX;

    private void Start()
    {
        playerBody = GameObject.FindGameObjectWithTag("Player");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensi;
        mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensi;

        mouseY = Mathf.Clamp(mouseY, -85, 90);

        playerBody.transform.localRotation = Quaternion.Euler(0f, mouseX, 0f);
        transform.localRotation = Quaternion.Euler(mouseY, 0f, 0f);
    }
}
