using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogues
{
    public string[] dialogueText;
    public AudioClip[] dialogueAudio;
}

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Dialogues dialogue;
    [SerializeField] private TMP_Text displayDialogueText;
    [SerializeField] private Button previousButton, nextButton, startButton;
    [SerializeField] private static float textStartDelay = 0.4f;
    [SerializeField] private static float textCharDelay = 0.04f;
    [SerializeField] private static float longPause = 0.6f;
    [SerializeField] private static float shortPause = 0.1f;

    private int dialogueCount = 0;
    private AudioSource audioSource;
    private Coroutine textCoroutine;
    private Coroutine audioCoroutine;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        previousButton.onClick.AddListener(delegate { PreviousDialogue(); });
        nextButton.onClick.AddListener(delegate { NextDialogue(); });
    }

    public void ResetSystem()
    {
        dialogueCount = 0;
        text = string.Empty;
        if (textCoroutine != null && audioCoroutine != null)
        {
            StopCoroutine(textCoroutine);
            StopCoroutine(audioCoroutine);
        }
        if (audioSource != null)
        {
            audioSource.Stop();
        }
        UpdateButtons();
    }

    public void StartDialogue()
    {
        ResetSystem();
        PlayDialogue(dialogueCount);
    }

    private void PreviousDialogue()
    {
        if (dialogueCount > 0)
        {
            PlayDialogue(--dialogueCount);
        }
    }

    private void NextDialogue()
    {
        if (dialogueCount < dialogue.dialogueText.Length - 1)
        {
            PlayDialogue(++dialogueCount);
        }
    }

    public void PlayDialogue(int index)
    {
        dialogueCount = index;
        UpdateButtons();
        PlayDialogueWithSync(dialogueCount);
    }

    private void UpdateButtons()
    {
        previousButton.gameObject.SetActive(dialogueCount > 0);
        nextButton.gameObject.SetActive(dialogueCount < dialogue.dialogueText.Length - 1);
    }

    private string text = null;
    private void PlayDialogueWithSync(int index)
    {
        text = dialogue.dialogueText[index];
        audioSource.clip = dialogue.dialogueAudio[index];
        displayDialogueText.text = "";

        if (audioSource != null)
            audioSource.Play();

        WaitForDialogue();
    }

    private void WaitForDialogue()
    {
        if (textCoroutine != null && audioCoroutine != null)
        {
            StopCoroutine(textCoroutine);
            StopCoroutine(audioCoroutine);
        }
        textCoroutine = StartCoroutine(WaitForDialogueText());
        audioCoroutine = StartCoroutine(WaitForDialogueAudio());
    }

    private IEnumerator WaitForDialogueText()
    {
        previousButton.interactable = false;
        nextButton.interactable = false;
        yield return new WaitForSeconds(textStartDelay);

        for (int i = 0; i < text.Length; i++)
        {
            displayDialogueText.text += text[i];

            if (text[i] == '!' || text[i] == ',')
                yield return new WaitForSeconds(shortPause);

            else if (text[i] == '.' || text[i] == '?')
                yield return new WaitForSeconds(longPause);

            else if (text[i] == '-')
                yield return new WaitForSeconds(.05f);

            yield return new WaitForSeconds(textCharDelay);
        }
    }

    private IEnumerator WaitForDialogueAudio()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        yield return new WaitForSeconds(0.5f);

        if (dialogueCount < dialogue.dialogueText.Length - 1)
        {
            NextDialogue();
        }
        else
        {
            previousButton.interactable = true;
            nextButton.interactable = true;
        }
    }
}