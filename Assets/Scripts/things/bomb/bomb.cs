using UnityEngine;

public class bomb : MonoBehaviour
{
    private Animator animatior;
    public GameObject explosion;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatior = this.gameObject.GetComponent<Animator>();
        animatior.Play("bomb_rolling");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void finsished_anim()
    {
        animatior.enabled = false;
        GameObject spawnexplosion = Instantiate(explosion, transform);
        //Instantiate(explosion, transform.position, Quaternion.identity);
    }

    public void destory()
    {
        GameObject.Destroy(this.gameObject);
    }
}
