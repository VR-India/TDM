using BNG;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject objectToActivate;
    public string ghostObjectTag;
    public GameObject collarMesh;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == ghostObjectTag && !other.GetComponent<Grabbable>().BeingHeld)
        {
            //other.transform.parent = transform;
            //other.transform.position = transform.position;
            //other.transform.rotation = transform.rotation;
            //other.GetComponent<Collider>().enabled = false;
            //this.GetComponent<Collider>().enabled = false;
            //collarMesh.SetActive(false);
            //Debug.Log("collar collider triggered");
            //ActivateInjuryCheckGhost();
        }
    }

    public void ActivateInjuryCheckGhost()
    {
        if(gameObject.name == "collar ghost" && objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
