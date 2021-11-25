using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;

    Vector3 forward, right;
    Vector3 moveDirection;

    float xInput, yInput;
    bool interact;

    Interactive currInteract;

    Rigidbody rb;

    [HideInInspector]
    public bool controlsEnabled = true;

    public LayerMask lm;
    public Transform groundPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundPoint.position, 0.25f);
    }

    private void Update()
    {
        if (controlsEnabled)
        {
            xInput = Input.GetAxis("Horizontal");
            yInput = Input.GetAxis("Vertical");
            interact = Input.GetKeyDown(KeyCode.E);

            if (interact && currInteract != null)
            {
                //interact with the current interactive in front of us

                currInteract.Interact();
            }

        }
        else
        {
            xInput = 0.0f;
            yInput = 0.0f;
        }


    }

    private void FixedUpdate()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0.0f;
        right = Camera.main.transform.right;
        Vector3 moveDirection = yInput * forward + xInput * right;
        Vector3 vel = playerSpeed * moveDirection;
        vel.y = rb.velocity.y;

        if (isGrounded())
        {
            vel.y = -2.0f; //stop this from accelerating when grounded
        }

        rb.velocity = vel;
    }

    bool isGrounded()
    {
        if(Physics.Raycast(groundPoint.position, Vector3.down, 0.1f, lm))
        {
            Debug.Log("GROUNDED: TRUE");
            return true;
        }
        Debug.Log("GROUNDED: FALSE");
        return false;
    }

    public void SetInteractive(Interactive interactive)
    {
        currInteract = interactive;
    }

    public Interactive GetInteractive()
    {
        return currInteract;
    }
}
