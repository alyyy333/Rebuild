using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform cameraPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
