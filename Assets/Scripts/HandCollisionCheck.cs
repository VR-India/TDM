using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionCheck : MonoBehaviour
{
    SphereCollider coll;
    private void Start()
    {
        coll = GetComponent<SphereCollider>();
    }
    private void OnTriggerStay(Collider other)
    {
        coll.enabled = false;

    }
}
