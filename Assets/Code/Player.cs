using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    private Camera cam;

    // SE realiza la configuraci�n inicial.
    void Start()
    {
        Cursor.visible = false;
        cam = Camera.main;
    }

    // Se actualiza la posici�n del jugador, mediante el cursor del mouse.
    void Update()
    {
        transform.position = (Vector2) cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Se detecta la colisi�n del jugador con un enemigo. En caso de colisi�n, se pierde el juego.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collision");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().LoseHeart();
        }
    }
}
