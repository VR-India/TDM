using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject envi;
    public DialogueManager dialogueManager;
 
    public void ChangeScene(int sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

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