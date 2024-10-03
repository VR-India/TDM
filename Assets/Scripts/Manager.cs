using System;
using System.Collections;
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
    
    public int inspectCount;
    bool chestChecked,backChecked;
    public GameObject grabbable, hingeObject, cervicalGhost, backInspectPoints;
    public MeshCollider walkStopperCollider;

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
        if(animatorName == "Neck helper")
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
            //next animation will be played
        }
        #endregion
    }

    void EnableGhost()
    {
        cervicalGhost.SetActive(true);
    }
}
