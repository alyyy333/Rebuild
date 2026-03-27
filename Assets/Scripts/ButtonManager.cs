using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void quit()
    {
        Application.Quit();
    }

}
