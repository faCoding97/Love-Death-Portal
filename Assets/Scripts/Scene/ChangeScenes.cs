using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void Play() => SceneManager.LoadScene("Scene Main");
    public void AboutUs() => SceneManager.LoadScene("About us");
    public void MenuScene() => SceneManager.LoadScene("UI");
    public void LinkLinkedin() => Application.OpenURL("https://www.linkedin.com/in/farazaghababayi");
    public void Exit() => Application.Quit();
}