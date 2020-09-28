using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform playerBody;
    float xRotataion = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;

        xRotataion -= mouseY;
        xRotataion = Mathf.Clamp(xRotataion, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotataion, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
