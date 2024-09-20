using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2) cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collision");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().Lose();
        }
    }
}
