using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*TLDR
 * Tässä scriptissä hallitaan 
 * kameran seuraamista hiirtä, 
 * pelaajan kääntymistä hiiren mukana
 * interactioiden kosketukset
* */
public class MousoLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;   //Hiiren nopeus
    public Image tahtain;

    public Transform playerBody;

    public LayerMask InteractionMask;   //kaikki mitä pelaaja voi koskettaa

    Camera kamera;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        kamera = GetComponent<Camera>();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;



        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        //Jos hiiren kohdalla on jotain niin värjätään hiiri
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, InteractionMask))
        {
            //Otetaan kohteelta componentti
            Interactable osuma = hit.collider.GetComponent<Interactable>();
            //Jos se on olemassa niin tehdään jotain
            if (osuma != null)
            {
                tahtain.color = Color.green;

                if (Input.GetKey(KeyCode.E))
                {
                    osuma.Interact();
                }
            }
            else
                tahtain.color = Color.white;

                
        }
}

/*
    void TarkistaOsuma()
    {
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, InteractionMask))
        {
            //Otetaan kohteelta componentti
            Interactable osuma = hit.collider.GetComponent<Interactable>();
            //Jos se on olemassa niin tehdään jotain
            if (osuma != null)
                osuma.Interact();
        }

    }
    */
}
