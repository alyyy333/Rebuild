using UnityEngine;

public class CamerController : MonoBehaviour
{
    [SerializeField] float sensX;
    float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensX;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, 0, 0);

    }
}
