using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    [Tooltip("What is the name of the scene we want to load when clicking the button?")]
    public string sceneName;

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}