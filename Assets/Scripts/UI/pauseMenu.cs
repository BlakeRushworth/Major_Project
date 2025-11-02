using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private AudioClip buttonClickedSound;
    public GameObject PauseMenu;

    AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioManager.PlaySFX(audioManager.buttonClick, 1f);
            Debug.Log("pause game");
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumePressed()
    {
        audioManager.PlaySFX(audioManager.buttonClick, 1f);
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitPressed()
    {
        audioManager.PlaySFX(audioManager.buttonClick, 1f);
        Time.timeScale = 1;
        GetComponent<resetgame>().ResetGame();
        SceneManager.LoadScene(2);
    }
}
