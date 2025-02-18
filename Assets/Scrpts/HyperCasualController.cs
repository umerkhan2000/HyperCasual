using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HyperCasualController : MonoBehaviour
{
    public float forwardSpeed = 5f; // Speed of forward movement
    public float sidewaySpeed = 5f; // Speed of sideways movement
    public float maxSideMovement = 3f; // Maximum side movement limit
    public float smoothTime = 0.1f; // Smooth movement time

    private Rigidbody rb;
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private float screenWidth;
    private float targetX;
    private float currentVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        screenWidth = Screen.width;
        targetX = transform.position.x;
    }

    void FixedUpdate()
    {
        MoveForward();
        HandleTouchInput();
        MoveSideways();
    }

    void MoveForward()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, forwardSpeed);
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position; // Store initial touch position
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                float deltaX = (touch.position.x - touchStartPos.x) / screenWidth * 2 * maxSideMovement;
                targetX = Mathf.Clamp(transform.position.x + deltaX, -maxSideMovement, maxSideMovement);
            }
        }
    }



    void MoveSideways()
    {
        float newXPosition = Mathf.SmoothDamp(transform.position.x, targetX, ref currentVelocity, smoothTime);
        rb.MovePosition(new Vector3(newXPosition, transform.position.y, transform.position.z));

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Obstcales"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
          Destroy(other.gameObject);
        }
    }
}