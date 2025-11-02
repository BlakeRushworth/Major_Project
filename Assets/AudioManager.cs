using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public AudioClip Explosion;

    public static bool SFX_enabled = true;
    public static bool Music_enabled = true;

    public TextMeshProUGUI Music_Text;
    public TextMeshProUGUI SFX_Text;

    private void Start()
    {
        if (Music_Text != null && SFX_Text != null)
        {
            if (SFX_enabled)
            {
                SFX_Text.text = "SFX - ON";
            }
            else
            {
                SFX_Text.text = "SFX - OFF";
            }

            if (Music_enabled)
            {
                Music_Text.text = "Music - ON";
            }
            else
            {
                Music_Text.text = "Music - OFF";
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            musicSource.clip = background;
        }
        else
        {
            musicSource.clip = menuBackground;
        } 
        if (Music_enabled)
        {
            musicSource.Play();
        }
        
    }

    public void PlaySFX(AudioClip clip, float Volume)
    {
        if (SFX_enabled)
        {
            sfxSource.PlayOneShot(clip, Volume);
        }
    }

    public void SFXToggle()
    {
        
        SFX_enabled = !SFX_enabled;
        if (SFX_enabled)
        {
            SFX_Text.text = "SFX - ON";
        }
        else
        {
            SFX_Text.text = "SFX - OFF";
        }
            Debug.Log(SFX_enabled);
    }

    public void MusicToggle()
    {
        Music_enabled = !Music_enabled;
        if (Music_enabled)
        {
            Music_Text.text = "Music - ON";
            musicSource.Play();
        }
        else
        {
            Music_Text.text = "Music - OFF";
            musicSource.Stop();
        }
        
        Debug.Log(Music_enabled);
    }
}
