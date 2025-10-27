using Unity.VisualScripting;
using UnityEngine;

public class Obelisk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D player;
    public float charging_dist;
    public float charge_Time = 2f;

    public ParticleSystem ParticleSystem1;
    public ParticleSystem ParticleSystem2;

    private float current_time;
    public bool complete = false;

    private bool particleChange= false;
    private bool changeParticleState;

    [HideInInspector]
    public Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //ParticleSystem1.Play();
        //ParticleSystem2.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        //Debug.Log("obelisk dist to player: " + distance);
        if (!complete)
        {
            if (distance <= charging_dist)
            {
                //Debug.Log("playing");
                if (!changeParticleState)
                {
                    ParticleSystem1.Play();
                    ParticleSystem2.Play();
                }
                anim.SetBool("charging", true);
                current_time -= Time.deltaTime;
                //Debug.Log(current_time);

                if (current_time <= 0f)
                {
                    anim.SetBool("done", true);
                    complete = true;
                    ParticleSystem1.Stop();
                    ParticleSystem2.Stop();
                }
                changeParticleState = true;
            }
            else
            {
                if (changeParticleState)
                {
                    ParticleSystem1.Stop();
                    ParticleSystem2.Stop();
                }
                //Debug.Log("stopping");
                anim.SetBool("charging", false);
                current_time = charge_Time;
                changeParticleState = false;
            }
        }
    }
}
