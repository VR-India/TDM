using System;
using System.Collections;
using UnityEngine;

public class WalkStopperScript : MonoBehaviour
{

    public float disableTimer;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "walking_animations_helpers")
        {
            FadeInFadeOut.instance.FadeIn();
            StartCoroutine(disableGameObject(other));
        }
    }
    IEnumerator disableGameObject(Collider otherColl)
    {
        audioManager.instance.PlayAudio("teleport to train");
        yield return new WaitForSeconds(disableTimer);
        otherColl.gameObject.SetActive(false);

    }
}
