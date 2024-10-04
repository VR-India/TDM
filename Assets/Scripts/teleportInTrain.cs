using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportInTrain : MonoBehaviour
{
    public Vector3 teleportPosition;
    public Vector3 teleportRotation;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = teleportPosition;
            other.transform.eulerAngles = teleportRotation;
            audioManager.instance.PlayAudio("");
        }
    }
}