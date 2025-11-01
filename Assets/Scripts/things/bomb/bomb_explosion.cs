using UnityEngine;

public class bomb_explosion : MonoBehaviour
{
    private Animator animatior;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatior = this.gameObject.GetComponent<Animator>();
        animatior.Play("bomb_exploding");
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
