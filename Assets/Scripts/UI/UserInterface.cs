using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    public void NewGameButton()
    {
        SceneManager.LoadScene("MVP");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
