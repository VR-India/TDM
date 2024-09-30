using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Animators
{
    public string animatorName;
    public Animator animator;
}

public class Manager : MonoBehaviour
{
    public Animators[] anims;

    public void PlayAnimation(string animatorName)
    {
        for(int i = 0; i < anims.Length; i++)
        {
            if (anims[i].animatorName == animatorName)
            {
                anims[i].animator.enabled = true;
            }
        }
    }
}
