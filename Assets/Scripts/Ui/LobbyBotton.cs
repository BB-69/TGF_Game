using UnityEngine;
using UnityEngine.SceneManagement;
public class LobbyBotton : MonoBehaviour
{
    public GameObject tutorialPanel , settingPanel;
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scenes");

    }
    public void Tutorial() 
    {
        tutorialPanel.SetActive(true);
        Debug.Log("Tutorial");

    }
    public void Setting()
    {
        settingPanel.SetActive(true);
        Debug.Log("Setting");

    }

}
