using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    [SerializeField] float sensX;
    [SerializeField] float sensY;

    [SerializeField] Transform orientation;


    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensY;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensX;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);


    }

}
