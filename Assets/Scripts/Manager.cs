using System;
using UnityEngine;

[Serializable]
public struct Animators
{
    public string animatorName;
    public Animator animator;
}

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public Animators[] anims;

    [HideInInspector]
    public int inspectCount;
    bool chestChecked,backChecked;
    public GameObject grabbable, hingeObject, cervicalGhost, cervicalCollar, backInspectPoints, stretcherGhost, stretcher;
    public MeshCollider walkStopperCollider;

    public RectTransform doneCanvas;

    public GameObject interactionsGameObject, patientTakenOut;
    private void Start()
    {
        instance = this;
        inspectCount = 0;
        chestChecked = backChecked = false;
    }
    #region Animation Player
    public void PlayAnimation(string animatorName)
    {
        for(int i = 0; i < anims.Length; i++)
        {
            if (anims[i].animatorName == animatorName)
            {
                anims[i].animator.enabled = true;
            }
        }
        if(animatorName == "Neck helper" && !cervicalGhost.activeSelf)
        {
            Invoke("EnableGhost", 2f);
        }
    }
    #endregion

    private void Update()
    {
        #region Injury Check
        if(inspectCount == 5 && !chestChecked)
        {
            Debug.Log("inspectCount reached 5");
            chestChecked = true;
            grabbable.SetActive(true);
            backInspectPoints.SetActive(true);
            hingeObject.GetComponent<BoxCollider>().enabled = true;
            inspectCount = 0;
        }
        else if(inspectCount == 5 && chestChecked)
        {
            backChecked = true;
        }
        
        if(chestChecked && backChecked)
        {
            stretcherGhost.SetActive(true);
            stretcher.SetActive(true);
            doneCanvas.gameObject.SetActive(true);
        }
        #endregion
    }

    void EnableGhost()
    {
        Invoke(nameof(DelayedEnable), 3f);
    }

    void DelayedEnable()
    {
        cervicalGhost.SetActive(true);
        cervicalCollar.SetActive(true);
    }

    public void DisableGameObject()
    {
        Invoke(nameof(DisableDelay), 2f);
    }

    void DisableDelay()
    {
        interactionsGameObject.SetActive(false);
        patientTakenOut.SetActive(true);
    }
}
