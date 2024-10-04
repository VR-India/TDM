using BNG;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject gameobjectToActivate;
    public string ghostObjectTag;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == ghostObjectTag && !other.GetComponent<Grabbable>().BeingHeld)
        {
            other.transform.parent = transform.parent;
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
            other.GetComponent<SphereCollider>().enabled = false;
            gameObject.SetActive(false);
            Debug.Log("collar collider triggered");
            ActivateInjuryCheckGhost();
        }
    }

    void ActivateInjuryCheckGhost()
    {
        if(gameObject.name == "collar ghost" && gameobjectToActivate != null)
        {
            gameobjectToActivate.SetActive(true);
        }
    }
}
