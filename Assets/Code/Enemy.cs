using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variables
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip crashSound;

    private float speed = 0.5f;
    private readonly float velocityMultiplier = 0.2f;
    private readonly float speedIncrement = 10f; // Incremento de velocidad
    private Vector2 startVelocity;
    private Vector2 startPosition;

    // Establece la posición inicial y la velocidad inicial del enemigo.
    void Start()
    {
        startPosition = transform.position;
        startVelocity = speed * new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rigidBody2D.velocity = startVelocity;
    }

    // Se actualiza la velocidad del enemigo.
    void FixedUpdate()
    {

        speed += Time.fixedDeltaTime;

        rigidBody2D.velocity = new Vector2(speed, speed) * rigidBody2D.velocity.normalized;

        Debug.Log(speed);
    }

    // Se detecta la colisión del enemigo con un objeto. En caso de colisión, se ajusta la velocidad del enemigo.
    // Si se colisiona con una pared, se reproduce un sonido.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource.clip = crashSound;
            audioSource.Play();
        }
        //VelocityFix();
    }

    // Se ajusta la velocidad del enemigo, en caso de que sea menor a un valor mínimo, para evitar que el enemigo quede detenido.
    private void VelocityFix()
    {
        float velocityDelta = 0.05f;
        float minVelocity = 0.01f;

        if (Mathf.Abs(rigidBody2D.velocity.x) < minVelocity)
        {
            velocityDelta = Random.value < 0.05f ? velocityDelta : -velocityDelta;
            rigidBody2D.velocity = new Vector2(speed, 0f);
        }

        if (Mathf.Abs(rigidBody2D.velocity.y) < minVelocity)
        {
            velocityDelta = Random.value < 0.05f ? velocityDelta : -velocityDelta;
            rigidBody2D.velocity = new Vector2(speed, 0f);
        }
    }
}
