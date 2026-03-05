using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMotor2D : MonoBehaviour
{
    public float maxSpeed = 3.5f;
    public float acceleration = 8f;
    public float stoppingDistance = 0.1f;

    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private bool hasTarget;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Vector2 position)
    {
        targetPosition = position;
        hasTarget = true;
        Debug.Log("Motor target set: " + position);
    }

    void FixedUpdate()
    {
        if (!hasTarget) return;

        Vector2 direction = targetPosition - rb.position;
        float distance = direction.magnitude;

        if (distance <= stoppingDistance)
        {
            rb.linearVelocity = Vector2.zero;
            hasTarget = false;
            return;
        }

        direction.Normalize();
        Vector2 desiredVelocity = direction * maxSpeed;

        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, desiredVelocity, acceleration * Time.fixedDeltaTime);

        // Flip sprite if needed
        if (direction.x != 0)
            transform.localScale = new Vector3(Mathf.Sign(direction.x), 1, 1);
    }
}