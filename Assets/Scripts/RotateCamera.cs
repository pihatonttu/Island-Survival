using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour
{
    public Texture2D Hiiri;
    public bool locked = false;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        //Hiiren lukitus
        if (Input.GetKey(KeyCode.Q))
            LukitseJaPiilotaHiiri();

            

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }


    //Lukitaan ja piilotetaan hiiri näkyvistä
    void LukitseJaPiilotaHiiri()
    {
        if (!locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            locked = true;
        } else
        {
            Cursor.lockState = CursorLockMode.None;
            locked = false;
        }
    }
}