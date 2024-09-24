using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variables
    [SerializeField] private Rigidbody2D rigidBody2D;

    private float speed = 200f;
    private float velocityMultiplier = 0.01f;
    private float speedIncrement = 50f; // Incremento de velocidad
    private Vector2 velocity;
    private Vector2 startVelocity;
    private Vector2 startPosition;

    // Establece la posición inicial y la velocidad inicial del enemigo.
    void Start()
    {
        startPosition = transform.position;
        startVelocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speed * velocityMultiplier;
        rigidBody2D.velocity = startVelocity;
    }

    // Se actualiza la velocidad del enemigo.
    void FixedUpdate()
    {
        speed += speedIncrement * Time.fixedDeltaTime;
        rigidBody2D.velocity = rigidBody2D.velocity.normalized * speed * velocityMultiplier;

    }

    // Se detecta la colisión del enemigo con un objeto. En caso de colisión, se ajusta la velocidad del enemigo.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        velocityFix();
    }

    // Se ajusta la velocidad del enemigo, en caso de que sea menor a un valor mínimo, para evitar que el enemigo quede detenido.
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
