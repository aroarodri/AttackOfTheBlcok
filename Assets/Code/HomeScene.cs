using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
