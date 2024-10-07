using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkStopperScript : MonoBehaviour
{

    public float disableTimer;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "walking_animations_helpers")
        {
            FadeInFadeOut.instance.FadeIn();
            StartCoroutine(DisablehelpersWalk(other));
        }

        if(other.name == "helpers_with_patient_01 (1)")
        {
            FadeInFadeOut.instance.FadeIn();
            StartCoroutine(DisableHelperWithPatient(other));
            StartCoroutine(ChangeSceneDelay(other));
        }
    }
    IEnumerator DisablehelpersWalk(Collider otherColl)
    {
        audioManager.instance.PlayAudio("trainTeleport");
        yield return new WaitForSeconds(disableTimer);
        otherColl.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    IEnumerator DisableHelperWithPatient(Collider otherColl)
    {
        yield return new WaitForSeconds(disableTimer);
        otherColl.gameObject.SetActive(false);
    }

    IEnumerator ChangeSceneDelay(Collider otherColl)
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("EndScene");
    }
}
