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
            StartCoroutine(disablehelpersWalk(other));
        }

        if(other.name == "helpers_with_patient_01")
        {
            FadeInFadeOut.instance.FadeIn();
            StartCoroutine(disableHelperWithPatient(other));
        }
    }
    IEnumerator disablehelpersWalk(Collider otherColl)
    {
        audioManager.instance.PlayAudio("trainTeleport");
        yield return new WaitForSeconds(disableTimer);
        otherColl.gameObject.SetActive(false);

    }

    IEnumerator disableHelperWithPatient(Collider otherColl)
    {
        yield return new WaitForSeconds(disableTimer);
        otherColl.gameObject.SetActive(false);

    }
}
