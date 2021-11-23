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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        rb.velocity = playerSpeed * moveDirection;
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
