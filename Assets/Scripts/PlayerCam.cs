using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    [SerializeField] float sensY;

    [SerializeField] Transform orientation;



    float yRotation;

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensY;

        yRotation += mouseX;


        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);


    }

}
