using UnityEngine;

public class Grabber : MonoBehaviour
{
    [Header("Refrences")]
    private PlayerMovement pm;
    public Transform cam;
    public Transform shootPoint;
    public LayerMask whatIsGrab;
    public LineRenderer lr;

    [Header("Variables")]
    public float maxGrabDistance;
    public float grabDelay;

    private Vector3 grabPoint;

    [Header("Cooldown")]
    public float grabCoolDown;
    private float grabCoolDownTimer;

    [Header("Input")]
    public KeyCode grabKey = KeyCode.Mouse0;

    private bool grabbing;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();            

    }
    private void Update()
    {
        if(Input.GetKeyDown(grabKey))
        {
            StartGrab();
        }

        if (grabCoolDown > 0)
        {
            grabCoolDownTimer -= Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if(grabbing)
        {
            lr.SetPosition(0, shootPoint.position); 
        }
    }
    private void StartGrab()
    {
        if (grabCoolDownTimer > 0)
        {
            return;
        }

        grabbing = true;

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, maxGrabDistance, whatIsGrab))
        {
            grabPoint = hit.point;
            Invoke(nameof(ExecuteGrab), grabDelay);
        }
        else
        {
            grabPoint = cam.position + cam.forward * maxGrabDistance;
            Invoke(nameof(StopGrab), grabDelay);

        }

        lr.enabled = true;
        lr.SetPosition(1, grabPoint);
    }

    private void ExecuteGrab()
    {

    }

    private void StopGrab()
    {
        grabbing = false;

        grabCoolDownTimer = grabCoolDown;

        lr.enabled = false;
    }
}
