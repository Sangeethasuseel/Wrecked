using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrashController : MonoBehaviour
{
    public Text scoreText;
    private List<int> collidedObjects= new List<int>();


    private void Update()
    {
        scoreText.text = "Score: "+StaticVar.score.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {

        int currentObject;
        if (collision.collider.tag == "CrashObject")
        {
            Debug.Log(collision.collider.tag);
            currentObject = collision.collider.GetInstanceID();
            if (!collidedObjects.Contains(currentObject)){ 
                collidedObjects.Add(currentObject);
                StaticVar.score += 10;
         
            }
            
        }
       
    }
    
}
 