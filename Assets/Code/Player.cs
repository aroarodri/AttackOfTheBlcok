using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    private Camera cam;
    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;
    public Vector3 originalScale { get; private set; }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip powerUpSound, dieSound;

    // SE realiza la configuración inicial.
    void Start()
    {
        Cursor.visible = false;
        cam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
    }

    // Se actualiza la posición del jugador, mediante el cursor del mouse.
    void Update()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 clampedPosition = ClampPositionToCameraBounds(mousePosition);
        transform.position = clampedPosition;
    }

    // Se detecta la colisión del jugador con un enemigo. En caso de colisión, se pierde el juego.
    // Si se colisiona con un power up, se activa el power up.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isInvincible)
        {
            audioSource.clip = dieSound;
            audioSource.Play();

            FindObjectOfType<GameManager>().LoseHeart();
            StartCoroutine(BecomeInvincible());
        }

        if (collision.gameObject.CompareTag("PowerUp"))
        {
            audioSource.clip = powerUpSound;
            audioSource.Play();

            FindObjectOfType<GameManager>().ActivatePowerUp();
            Destroy(collision.gameObject);
        }
    }

    // Corrutina para manejar la invencibilidad
    private IEnumerator BecomeInvincible()
    {
        isInvincible = true;

        float invincibilityDuration = 3f;
        float blinkInterval = 0.3f;

        while (invincibilityDuration > 0)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            invincibilityDuration -= blinkInterval;
            blinkInterval = Mathf.Max(0.05f, blinkInterval * 0.9f); // Reducir el intervalo de parpadeo
        }

        spriteRenderer.enabled = true; // Asegurarse de que el sprite esté visible al final
        isInvincible = false;
    }

    // Método para limitar la posición del jugador dentro de los límites de la cámara
    private Vector2 ClampPositionToCameraBounds(Vector2 position)
    {
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        float clampedX = Mathf.Clamp(position.x, bottomLeft.x, topRight.x);
        float clampedY = Mathf.Clamp(position.y, bottomLeft.y, topRight.y);

        return new Vector2(clampedX, clampedY);
    }
}
