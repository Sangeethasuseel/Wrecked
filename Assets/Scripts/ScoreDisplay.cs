
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text ="Your Score: "+ StaticVar.score.ToString();
    }


}