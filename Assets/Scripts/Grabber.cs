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
    float ropeLength;
    SpringJoint joint;
    Transform grabbedObject;

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
            if (grabbedObject != null)
            {
                lr.SetPosition(1, grabbedObject.position);
            }
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
            grabbedObject = hit.transform;
            Attach(hit.rigidbody);
        }
        else
        {
            Invoke(nameof(StopGrab), grabDelay);
            if(joint != null)
            {
                Destroy(joint);
                joint = null;
            }

        }

        lr.enabled = true;
    }

  

    private void StopGrab()
    {
        grabbing = false;

        grabCoolDownTimer = grabCoolDown;

        lr.enabled = false;
    }

    private void Attach(Rigidbody target)
    {
        joint = gameObject.AddComponent<SpringJoint>();
        joint.connectedBody = target;
        ropeLength = Vector3.Distance(transform.position, target.position);
        joint.maxDistance = 1f;
        joint.minDistance = ropeLength;
        joint.spring = 100f; //stiffness
        joint.damper = 5f; //smoothness
    }


}
