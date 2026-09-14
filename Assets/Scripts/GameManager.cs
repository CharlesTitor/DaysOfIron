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
        screen.SetActive(true);
    }

    public void ExitScreen(GameObject screen)
    {
        screen.SetActive(false);
    }
}
