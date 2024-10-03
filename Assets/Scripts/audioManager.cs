using System;
using UnityEngine;

[Serializable]
public struct Audios
{
    public string audioName;
    public AudioClip clip;
}

public class audioManager : MonoBehaviour
{
    public static audioManager instance;
    public Audios[] clips;
    public AudioSource source;
    private void Awake()
    {
        instance = this;
    }
    public void PlayAudio(string audioClipName)
    {
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].audioName == audioClipName)
            {
                source.clip = clips[i].clip;
                source.Play();
            }
        }


    }
}
