using NUnit.Framework.Internal;
using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skill_tree : MonoBehaviour
{
    public GameObject[] skill_tree_icons;

    public static float player_speed = 6f;
    public static float player_jump_range = 0f;
    public static float player_roll_speed = 12f;

    public static float maxStamina = 100f;
    public static float maxHealth = 100f;
    public static float StaminaRegeneration = 10f;
    public static float HealthRegeneration = 0f;

    public static bool Obelisk_Speed = false;
    public static bool shop_discount = false;

    public static bool BurningImmunity = false;
    public static bool PoisonedImmunity = false;
    public static bool FreezingImmunity = false;

    public Gradient green;
    public Gradient gray;


    public TextMeshProUGUI skillpoint_text;

    public static int skillpoint = 0;
    public static bool resetLines = true;

    public static bool[] skillTreeOnce = {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false
    };

    public GameObject LoadingScreen;

    AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();

        SetLines();
        skillpoint += 1;
        if (resetLines)
        {
            resetLines = false;
            skill_tree_icons[0].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = gray;
            skill_tree_icons[0].transform.GetChild(2).GetComponentInChildren<LineRenderer>().colorGradient = gray;
            skill_tree_icons[1].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = gray;
            skill_tree_icons[0].transform.GetChild(1).GetComponentInChildren<LineRenderer>().colorGradient = gray;
            skill_tree_icons[2].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = gray;
            skill_tree_icons[3].transform.GetChild(1).GetComponentInChildren<LineRenderer>().colorGradient = gray;
            skill_tree_icons[5].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = gray;
            skill_tree_icons[4].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = gray;
            skill_tree_icons[4].transform.GetChild(1).GetComponentInChildren<LineRenderer>().colorGradient = gray;
            skill_tree_icons[3].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = gray;
            skill_tree_icons[5].transform.GetChild(1).GetComponentInChildren<LineRenderer>().colorGradient = gray;
            skill_tree_icons[8].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = gray;
            skill_tree_icons[9].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = gray;
        }
    }

    // Update is called once per frame
    void Update()
    {
        skillpoint_text.text = skillpoint.ToString();
    }

    public void SetLines()
    {
        skill_tree_icons[0].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(0, skill_tree_icons[0].transform.position);
        skill_tree_icons[0].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(1, skill_tree_icons[1].transform.position);
        skill_tree_icons[0].transform.GetChild(1).GetComponentInChildren<LineRenderer>().SetPosition(0, skill_tree_icons[0].transform.position);
        skill_tree_icons[0].transform.GetChild(1).GetComponentInChildren<LineRenderer>().SetPosition(1, skill_tree_icons[4].transform.position);
        skill_tree_icons[0].transform.GetChild(2).GetComponentInChildren<LineRenderer>().SetPosition(0, skill_tree_icons[0].transform.position);
        skill_tree_icons[0].transform.GetChild(2).GetComponentInChildren<LineRenderer>().SetPosition(1, skill_tree_icons[2].transform.position);

        skill_tree_icons[1].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(0, skill_tree_icons[1].transform.position);
        skill_tree_icons[1].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(1, skill_tree_icons[3].transform.position);

        skill_tree_icons[2].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(0, skill_tree_icons[2].transform.position);
        skill_tree_icons[2].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(1, skill_tree_icons[5].transform.position);

        skill_tree_icons[3].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(0, skill_tree_icons[3].transform.position);
        skill_tree_icons[3].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(1, skill_tree_icons[10].transform.position);
        skill_tree_icons[3].transform.GetChild(1).GetComponentInChildren<LineRenderer>().SetPosition(0, skill_tree_icons[3].transform.position);
        skill_tree_icons[3].transform.GetChild(1).GetComponentInChildren<LineRenderer>().SetPosition(1, skill_tree_icons[6].transform.position);


        skill_tree_icons[4].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(0, skill_tree_icons[4].transform.position);
        skill_tree_icons[4].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(1, skill_tree_icons[8].transform.position);
        skill_tree_icons[4].transform.GetChild(1).GetComponentInChildren<LineRenderer>().SetPosition(0, skill_tree_icons[4].transform.position);
        skill_tree_icons[4].transform.GetChild(1).GetComponentInChildren<LineRenderer>().SetPosition(1, skill_tree_icons[9].transform.position);

        skill_tree_icons[5].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(0, skill_tree_icons[5].transform.position);
        skill_tree_icons[5].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(1, skill_tree_icons[7].transform.position);
        skill_tree_icons[5].transform.GetChild(1).GetComponentInChildren<LineRenderer>().SetPosition(0, skill_tree_icons[5].transform.position);
        skill_tree_icons[5].transform.GetChild(1).GetComponentInChildren<LineRenderer>().SetPosition(1, skill_tree_icons[11].transform.position);

        skill_tree_icons[8].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(0, skill_tree_icons[8].transform.position);
        skill_tree_icons[8].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(1, skill_tree_icons[12].transform.position);

        skill_tree_icons[9].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(0, skill_tree_icons[9].transform.position);
        skill_tree_icons[9].transform.GetChild(0).GetComponentInChildren<LineRenderer>().SetPosition(1, skill_tree_icons[12].transform.position);

        if (skillTreeOnce[0])
        {
            skill_tree_icons[0].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
        if (skillTreeOnce[1])
        {
            skill_tree_icons[0].transform.GetChild(2).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
        if (skillTreeOnce[2])
        {
            skill_tree_icons[1].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
        if (skillTreeOnce[3])
        {
            skill_tree_icons[0].transform.GetChild(1).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
        if (skillTreeOnce[4])
        {
            skill_tree_icons[2].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
        if (skillTreeOnce[5])
        {
            skill_tree_icons[3].transform.GetChild(1).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
        if (skillTreeOnce[6])
        {
            skill_tree_icons[5].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
        if (skillTreeOnce[7])
        {
            skill_tree_icons[4].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
        if (skillTreeOnce[8])
        {
            skill_tree_icons[4].transform.GetChild(1).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
        if (skillTreeOnce[9])
        {
            skill_tree_icons[3].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
        if (skillTreeOnce[10])
        {
            skill_tree_icons[5].transform.GetChild(1).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
        if (skillTreeOnce[11])
        {
            skill_tree_icons[8].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
            skill_tree_icons[9].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
    }

    public void NextLevelButton()
    {
        audioManager.PlaySFX(audioManager.buttonClick, 1f);
        Instantiate(LoadingScreen, transform.position, Quaternion.identity);
        SceneManager.LoadScene(0);
    }

    public void IncreaseMaxHealth()
    {
        if (!skillTreeOnce[0] && skillpoint > 0)
        {
            audioManager.PlaySFX(audioManager.buttonClick, 1f);
            skillpoint -= 1;
            skillTreeOnce[0] = true;
            maxHealth += 50f;
            Debug.Log(maxHealth);

            skill_tree_icons[0].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
    }

    public void HealthRegen()
    {
        if (!skillTreeOnce[2] && skillTreeOnce[0] && skillpoint > 0)
        {
            audioManager.PlaySFX(audioManager.buttonClick, 1f);
            skillpoint -= 1;
            skillTreeOnce[2] = true;
            HealthRegeneration += 1f;
            Debug.Log(HealthRegeneration);

            skill_tree_icons[1].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
    }
    public void Buyshop_discount()
    {
        if (!skillTreeOnce[5] && skillTreeOnce[2] && skillpoint > 0)
        {
            audioManager.PlaySFX(audioManager.buttonClick, 1f);
            skillpoint -= 1;
            skillTreeOnce[5] = true;
            shop_discount = true;
            Debug.Log(shop_discount);

            skill_tree_icons[3].transform.GetChild(1).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
    }

    public void FreezeImmunity(){
        if (!skillTreeOnce[9] && skillTreeOnce[2] && skillpoint > 0)
        {
            audioManager.PlaySFX(audioManager.buttonClick, 1f);
            skillpoint -= 1;
            skillTreeOnce[9] = true;
            FreezingImmunity = true;
            Debug.Log(FreezingImmunity);

            skill_tree_icons[3].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
    }

    public void IncreasePlayerSpeed(){
        if (!skillTreeOnce[3] && skillpoint > 0)
        {
            audioManager.PlaySFX(audioManager.buttonClick, 1f);
            skillpoint -= 1;
            skillTreeOnce[3] = true;
            player_speed += 1f;
            Debug.Log(player_speed);

            skill_tree_icons[0].transform.GetChild(1).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
    }

    public void IncreaseJumpRange(){
        if (!skillTreeOnce[7] && skillTreeOnce[3] && skillpoint > 0)
        {
            audioManager.PlaySFX(audioManager.buttonClick, 1f);
            skillpoint -= 1;
            skillTreeOnce[7] = true;
            player_jump_range += 10f;
            Debug.Log(player_jump_range);

            skill_tree_icons[4].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
    }

    public void IncreaseRollSpeed()
    {
        if (!skillTreeOnce[8] && skillTreeOnce[3] && skillpoint > 0)
        {
            audioManager.PlaySFX(audioManager.buttonClick, 1f);
            skillpoint -= 1;
            skillTreeOnce[8] = true;
            player_roll_speed += 4f;
            Debug.Log(player_roll_speed);

            skill_tree_icons[4].transform.GetChild(1).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
    }

    public void BurnImmunity(){
        if (!skillTreeOnce[11] && skillTreeOnce[7] && skillTreeOnce[8] && skillpoint > 0)
        {
            audioManager.PlaySFX(audioManager.buttonClick, 1f);
            skillpoint -= 1;
            skillTreeOnce[11] = true;
            BurningImmunity = true;
            Debug.Log(BurningImmunity);

            skill_tree_icons[8].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
            skill_tree_icons[9].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
    }

    public void IncreaseMaxStamina(){
        if (!skillTreeOnce[1] && skillpoint > 0)
        {
            audioManager.PlaySFX(audioManager.buttonClick, 1f);
            skillpoint -= 1;
            skillTreeOnce[1] = true;
            maxStamina += 50f;
            Debug.Log(maxStamina);

            skill_tree_icons[0].transform.GetChild(2).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
    }

    public void IncreaseStaminaRegen(){
        if (!skillTreeOnce[4] && skillTreeOnce[1] && skillpoint > 0)
        {
            audioManager.PlaySFX(audioManager.buttonClick, 1f);
            skillpoint -= 1;
            skillTreeOnce[4] = true;
            StaminaRegeneration += 10f;
            Debug.Log(StaminaRegeneration);

            skill_tree_icons[2].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
    }

    public void BuyObelisk_Speed(){
        if (!skillTreeOnce[6] && skillTreeOnce[4] && skillpoint > 0)
        {
            audioManager.PlaySFX(audioManager.buttonClick, 1f);
            skillpoint -= 1;
            skillTreeOnce[6] = true;
            Obelisk_Speed = true;
            Debug.Log(Obelisk_Speed);

            skill_tree_icons[5].transform.GetChild(0).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
    }

    public void PoisonImmunity(){
        if (!skillTreeOnce[10] && skillTreeOnce[4] && skillpoint > 0)
        {
            audioManager.PlaySFX(audioManager.buttonClick, 1f);
            skillpoint -= 1;
            skillTreeOnce[10] = true;
            PoisonedImmunity = true;
            Debug.Log(PoisonedImmunity);

            skill_tree_icons[5].transform.GetChild(1).GetComponentInChildren<LineRenderer>().colorGradient = green;
        }
    }
}
