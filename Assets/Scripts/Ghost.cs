using BNG;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "survexical collar" && !other.GetComponent<Grabber>().HeldGrabbable)
        {
            other.transform.parent = transform.parent;
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
            Debug.Log("triggered");
        }
    }
}
