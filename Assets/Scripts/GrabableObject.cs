using UnityEngine;

public class GrabableObject : MonoBehaviour
{

    Transform dropSpot;

    void Start()
    {
        GameObject collectionBox = GameObject.Find("PieceCollectionBox");

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("vacuum"))
        {
            Debug.Log("dropped");

            transform.position = dropSpot.position;
        }

    }


    void Update()
    {
        
    }
}
