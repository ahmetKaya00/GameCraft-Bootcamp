using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensivity = 100f;
    [SerializeField] Transform playerBody;
    [SerializeField] Joystick joystick;
    float xRotation = 0f;

    private void Update()
    {
        float mouseX = joystick.Horizontal * mouseSensivity * Time.deltaTime;
        float mouseY = joystick.Vertical * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
