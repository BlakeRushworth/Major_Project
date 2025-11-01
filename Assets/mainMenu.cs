using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newGame()
    {
        SceneManager.LoadScene(0);
    }

    public void settings()
    {
        SceneManager.LoadScene(3);
    }

    public void controls()
    {
        SceneManager.LoadScene(4);
    }

    public void exitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
