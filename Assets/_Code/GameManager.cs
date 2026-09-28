using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void EnterScreen(GameObject screen)
    {
        Time.timeScale = 0f;
        screen.SetActive(true);
    }

    public void ExitScreen(GameObject screen)
    {
        Time.timeScale = 1f;
        screen.SetActive(false);
    }
}
