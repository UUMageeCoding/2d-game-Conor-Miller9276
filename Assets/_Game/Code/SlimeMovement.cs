using System.Collections;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed = 2f;
    public float waitTime = 1f; // How long to wait at each point

    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    private bool isWaiting = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);

            // Set to Dynamic with gravity
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 3f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }      

    private void Update()
    {
        if (isWaiting) return; // Stop moving while waiting

        // Move toward the current target point
        Vector2 target = currentPoint.position;
        Vector2 newPosition = Vector2.MoveTowards(rb.position, target, 2f * Time.deltaTime);
        rb.MovePosition(newPosition);

        // Check if we've reached the target
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            StartCoroutine(WaitAndSwitch());
        }
    }

    private IEnumerator WaitAndSwitch()
    {
        if(currentPoint = pointB.transform)
        rb.linearVelocity = Vector2.zero; // Stop movement
       

        yield return new WaitForSeconds(waitTime); // Pause

        // Switch to the other point
        currentPoint = (currentPoint = pointB.transform) ? pointA.transform : pointB.transform;

        Flip(); // Turn around
        anim.SetBool("isRunning", true);
        isWaiting = false;
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}