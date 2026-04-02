using UnityEngine;

public class GrabableObject : MonoBehaviour
{
    Transform dropSpotTransform;
    ScoreCounter scoreCounter;

    void Start()
    {
        GameObject dropSpot = GameObject.Find("DropSpot");
        if (dropSpot == null)
        {
            Debug.Log("can't find DropSpot");
        }
        else
        {
            Debug.Log("gameObject: " + dropSpot.name);
        }

        dropSpotTransform = dropSpot.transform;

        scoreCounter = FindFirstObjectByType<ScoreCounter>();
        if (scoreCounter == null)
        {
            Debug.Log("can't find scoreCounter (script)");
        }
        else
        {
            Debug.Log("scoreCounter: " + scoreCounter.name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("vacuum"))
        {
            Debug.Log("dropped");

            transform.position = dropSpotTransform.position;

            scoreCounter.AddScore();
        }

    }


    void Update()
    {
        
    }
}
