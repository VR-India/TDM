using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public GameObject envi;
    public DialogueManager dialogueManager;


    private void Start()
    {
        Invoke("EnableEnvi",5f);
        
    }

    public void EnableEnvi()
    {
        envi.SetActive(true);
        Invoke("StartDialoge", 2f);
    }

    public void StartDialoge()
    {
        dialogueManager.PlayDialogue(0);
    }
}