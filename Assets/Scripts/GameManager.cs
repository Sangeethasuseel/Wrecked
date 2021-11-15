using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
   public void EndGame()
    {
        SceneManager.LoadScene("ScoreScene");
    }

    public void Start()
    {
        StaticVar.score = 0;
        FindObjectOfType<TimerController>().beginTimer();
    }
}
