using System.Collections;
using UnityEngine;

public class poisonparticle : MonoBehaviour
{
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(DelayDeath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerStateMachine>().hitCooldown = true;
            player.GetComponent<PlayerStateMachine>().enemytypehitby = "poison";
        }
    }

    public IEnumerator DelayDeath()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        Object.Destroy(this);
    }
}
