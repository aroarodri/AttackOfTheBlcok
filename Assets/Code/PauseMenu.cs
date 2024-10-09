using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        EnemiesSpawner enemiesSpawner = FindObjectOfType<EnemiesSpawner>();

        if (enemiesSpawner != null)
        {
            enemiesSpawner.RestarGame();
        }

        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.ResetHearts();
        }
    }

    public void Home()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.Home();
        }
    }
}
