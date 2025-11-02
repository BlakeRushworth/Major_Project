using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip background;
    public AudioClip menuBackground;

    public AudioClip playerWalk1;
    public AudioClip playerWalk2;
    public AudioClip playerWalk3;

    public AudioClip playerHit;
    public AudioClip playerJump;
    public AudioClip playerDeath;
    //public AudioClip Portal;
    public AudioClip buttonClick;
    public AudioClip enemyAttack;

    public AudioClip coinSound;
    public AudioClip obeliskCompletion;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            musicSource.clip = background;
        }
        else
        {
            musicSource.clip = menuBackground;
        } 
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip, float Volume)
    {
        sfxSource.PlayOneShot(clip, Volume);
    }
}
