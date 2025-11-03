using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class mainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip buttonClickSound;
    public GameObject LoadingScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newGame()
    {
        Instantiate(LoadingScreen, transform.position, Quaternion.identity);
        SceneManager.LoadScene("SampleScene");
    }

    public void settings()
    {
        //AudioSource.PlayClipAtPoint(buttonClickSound, transform.position);
        SceneManager.LoadScene("settingsMenu");
    }

    public void controls()
    {
        SceneManager.LoadScene("controlsMenu");
    }

    public void exitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
