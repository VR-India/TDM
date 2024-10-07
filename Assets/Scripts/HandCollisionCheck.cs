using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;


public class HandCollisionCheck : MonoBehaviour
{
    SphereCollider coll;
    
    private void Start()
    {
        coll = GetComponent<SphereCollider>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            Manager.instance.inspectCount++;
            Haptics.Instance.DoHaptics(ControllerHand.Left, 0.5f,0.2f, 0.2f);
        }
    }
}
