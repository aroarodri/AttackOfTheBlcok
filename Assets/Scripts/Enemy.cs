using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;

    [SerializeField] private float speed;
    [SerializeField] private float velocityMultiplier;


    private float speedIncrement = 50f; // Incremento de velocidad
    private Vector2 velocity;
    private Vector2 startVelocity;
    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
        startVelocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speed * velocityMultiplier;
        rigidBody2D.velocity = startVelocity;
    }

    void FixedUpdate()
    {
        speed += speedIncrement * Time.fixedDeltaTime;
        rigidBody2D.velocity = rigidBody2D.velocity.normalized * speed * velocityMultiplier;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        velocityFix();
    }

    private void velocityFix()
    {
        float velocityDelta = 0.05f;
        float minVelocity = 0.01f;

        if (Mathf.Abs(rigidBody2D.velocity.x) < minVelocity)
        {
            velocityDelta = Random.value < 0.05f ? velocityDelta : -velocityDelta;
            rigidBody2D.velocity += new Vector2(velocityDelta, 0f);
        }

        if (Mathf.Abs(rigidBody2D.velocity.y) < minVelocity)
        {
            velocityDelta = Random.value < 0.05f ? velocityDelta : -velocityDelta;
            rigidBody2D.velocity += new Vector2(velocityDelta, 0f);
        }
    }
}
