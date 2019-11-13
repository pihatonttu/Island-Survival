using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ColorOnHover))]
public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    // This method is meant to be overwritten
    public virtual void Interact()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
