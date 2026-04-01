using UnityEngine;

public class GrabableObject : MonoBehaviour
{
    Transform dropSpotTransform;

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

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("vacuum"))
        {
            Debug.Log("dropped");

            transform.position = dropSpotTransform.position;
        }

    }


    void Update()
    {
        
    }
}
