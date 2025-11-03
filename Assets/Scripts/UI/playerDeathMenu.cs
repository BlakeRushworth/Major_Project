using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDeathMenu : MonoBehaviour
{
    public GameObject playerDeathUI;
    private bool once = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerStateMachine>().currentState == player.GetComponent<PlayerStateMachine>().statesDict[PlayerStateMachine.states.Death])
        {
            if (!once)
            {
                once = true;
                Debug.Log("Player died in menu script woohoo");
                StartCoroutine(delayDeathScreen());
                
            }
        }
    }

    public void goToMainMenu()
    {
        playerDeathUI.SetActive(false);
        Time.timeScale = 1;
        GetComponent<resetgame>().ResetGame();
        SceneManager.LoadScene("mainMenu");
    }

    public IEnumerator delayDeathScreen()
    {
        Debug.Log(" died started wait 3 seconds");
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0;
        playerDeathUI.SetActive(true);
    }
}
