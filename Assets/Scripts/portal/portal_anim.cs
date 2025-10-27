using UnityEngine;
using UnityEngine.SceneManagement;

public class portal_anim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("touch skill tree");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("go to skill tree");
            SceneManager.LoadScene(1);
        }
    }
}
