using UnityEngine;

public class bomb_explosion : MonoBehaviour
{
    private Animator animatior;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        animatior = this.gameObject.GetComponent<Animator>();
        animatior.Play("bomb_exploding");

        audioManager.PlaySFX(audioManager.Explosion, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Finish_animation()
    {
        GetComponentInParent<bomb>().destory();
    }
}
