using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIEvents : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1.0f;
    }
    
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
