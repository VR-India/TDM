using BNG;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "survexical collar" && !other.GetComponent<Grabbable>().BeingHeld)
        {
            other.transform.parent = transform.parent;
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
            other.GetComponent<CapsuleCollider>().enabled = false;
            Debug.Log("triggered");
        }
        else
            Debug.Log("didn't enter if condition");
    }
}
