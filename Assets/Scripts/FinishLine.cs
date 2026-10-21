using UnityEngine;
using UnityEngine.UI;
public class FinishLine : MonoBehaviour
{
    public GameObject FinishMenu;

    void start()
    {
        FinishMenu.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0f; 
        FinishMenu?.SetActive(true);
    }
}
