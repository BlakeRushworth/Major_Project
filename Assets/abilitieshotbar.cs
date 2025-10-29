using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class abilitieshotbar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image groundpound;
    public Image invisability;

    public Image groundpoundIcon;
    public Image invisabilityIcon;

    public int activeAbility;

    public Sprite active;
    public Sprite deactive;

    public float groundpoundabilityCooldown;
    public float invisabilityabilityCooldown;
    void Start()
    {

        if (skill_tree.GroundPound)
        {
            groundpound.gameObject.SetActive(true);
            groundpound.GetComponent<Image>().overrideSprite = active;
            invisability.GetComponent<Image>().overrideSprite = deactive;
            activeAbility = 1;
            groundpoundabilityCooldown = 10f;
           
        }
        if (skill_tree.Invisability)
        {
            invisability.gameObject.SetActive(true);
            invisability.GetComponent<Image>().overrideSprite = active;
            groundpound.GetComponent<Image>().overrideSprite = deactive;
            activeAbility = 2;
            invisabilityabilityCooldown = 10f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (Input.GetKey(KeyCode.Alpha1) && skill_tree.GroundPound)
        {
            groundpound.GetComponent<Image>().overrideSprite = active;
            invisability.GetComponent<Image>().overrideSprite = deactive;
            activeAbility = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2) && skill_tree.Invisability)
        {
            invisability.GetComponent<Image>().overrideSprite = active;
            groundpound.GetComponent<Image>().overrideSprite = deactive;
            activeAbility = 2;
        }

        //Debug.Log("groundpound unlocked = " + skill_tree.GroundPound + " active ability = " + activeAbility + " groundpoundcooldown = " + groundpoundabilityCooldown);
        if (Input.GetKeyDown(KeyCode.Mouse1) && skill_tree.GroundPound &&  activeAbility == 1 && groundpoundabilityCooldown >= 10f)
        {
            groundpoundabilityCooldown = 0f;
            foreach (GameObject enemy in enemies)
            {
                Debug.Log("enemy = " + enemy.name);
                enemy.GetComponent<EnemyStateMachine>().groundpoundstun();
            }
            //player.GetComponent<PlayerStateMachine>().Invisability();
            
        }
        //Debug.Log("invisability unlocked = " + skill_tree.Invisability + " active ability = " + activeAbility + " invisabilitycooldown = " + invisabilityabilityCooldown);
        if (Input.GetKeyDown(KeyCode.Mouse1) && skill_tree.Invisability && activeAbility == 2 && invisabilityabilityCooldown >= 10f)
        {
            invisabilityabilityCooldown = 0f;
            player.GetComponent<PlayerStateMachine>().turnInvis = true;
        }

        if (groundpoundabilityCooldown < 10f)
        {
            groundpoundabilityCooldown += Time.deltaTime;
        }
        if (invisabilityabilityCooldown < 10f)
        {
            invisabilityabilityCooldown += Time.deltaTime;
        }
        groundpoundIcon.fillAmount = Mathf.Clamp(groundpoundabilityCooldown / 10f, 0, 1);
        invisabilityIcon.fillAmount = Mathf.Clamp(invisabilityabilityCooldown / 10f, 0, 1);
    }
}
