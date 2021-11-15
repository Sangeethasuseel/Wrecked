using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierController : MonoBehaviour
{
    public Text scoreText;
    public Text strikeText;
    public int maxStrikes=3;
    private int strikes;
    private List<int> collidedObjects = new List<int>();
    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        scoreText.text = "Score: " + Vector3.Distance(lastPosition, transform.position).ToString("0");
        strikeText.text = "Strikes: " + strikes.ToString() + "/" + maxStrikes.ToString();
        StaticVar.score= (int)Vector3.Distance(lastPosition, transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {

        int currentObject;
        if (collision.collider.tag == "BarrierObject")
        {
            Debug.Log(collision.collider.tag);
            currentObject = collision.collider.GetInstanceID();
            if (!collidedObjects.Contains(currentObject))
            {
                collidedObjects.Add(currentObject);
                strikes += 1;
                if (strikes == maxStrikes)
                {
                    FindObjectOfType<GameManager>().EndGame();
                }
            
            }

        }

    }

}
