using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask interactionMask;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit, interactionMask))
            {
                ItemPickup osuma = hit.collider.GetComponent<ItemPickup>();
                if (osuma != null)
                    osuma.Interact();
            }
        }
    }
}
