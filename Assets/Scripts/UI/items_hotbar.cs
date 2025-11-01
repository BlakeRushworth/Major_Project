using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class items_hotbar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image landmine_slot;
    public Image health_potion_slot;
    public Image stamina_potion_slot;

    public Image landmine_num_slot;
    public Image health_potion_num_slot;
    public Image stamina_potion_num_slot;

    public TextMeshProUGUI landmine;
    public TextMeshProUGUI health_potion;
    public TextMeshProUGUI stamina_potion;

    public Image landmine_icon;
    public Image health_potion_icon;
    public Image stamina_potion_icon;

    public int activeItem;

    public Sprite active;
    public Sprite deactive;

    public GameObject bomb;

    private float landmine_CD = 10f;
    private float health_CD = 10f;
    private float stamina_CD = 10f;

    public static int landmine_count = 0;
    public static int health_potion_count = 0;
    public static int stamina_potion_count = 0;

    private float landmine_range = 10f;
    private float potion_health_strength = 33f;
    private float potion_stamina_strength = 50f;


    void Start()
    {
        landmine_slot.GetComponent<Image>().overrideSprite = active;
        health_potion_slot.GetComponent<Image>().overrideSprite = deactive;
        stamina_potion_slot.GetComponent<Image>().overrideSprite = deactive;
        activeItem = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (Input.GetKey(KeyCode.Alpha1))
        {
            landmine_slot.GetComponent<Image>().overrideSprite = active;
            health_potion_slot.GetComponent<Image>().overrideSprite = deactive;
            stamina_potion_slot.GetComponent<Image>().overrideSprite = deactive;
            activeItem = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            landmine_slot.GetComponent<Image>().overrideSprite = deactive;
            health_potion_slot.GetComponent<Image>().overrideSprite = active;
            stamina_potion_slot.GetComponent<Image>().overrideSprite = deactive;
            activeItem = 2;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            landmine_slot.GetComponent<Image>().overrideSprite = deactive;
            health_potion_slot.GetComponent<Image>().overrideSprite = deactive;
            stamina_potion_slot.GetComponent<Image>().overrideSprite = active;
            activeItem = 3;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && !Input.GetKeyDown(KeyCode.Space) && activeItem == 1 && landmine_CD >= 10f && landmine_count > 0)
        {
            landmine_CD = 0f;
            landmine_count -= 1;
            Instantiate(bomb, player.transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !Input.GetKeyDown(KeyCode.Space) && activeItem == 2 && health_CD >= 10f && health_potion_count > 0 && health_bar_test.currentHealth < health_bar_test.maxHealth)
        {
            health_CD = 0f;
            health_potion_count -= 1;
            health_bar_test.currentHealth += potion_health_strength;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !Input.GetKeyDown(KeyCode.Space) && activeItem == 3 && stamina_CD >= 10f && stamina_potion_count > 0 && stamina_bar.currentStanima < stamina_bar.maxStanima)
        {
            stamina_CD = 0f;
            stamina_potion_count -= 1;
            stamina_bar.currentStanima += potion_stamina_strength;
        }

        if (landmine_CD < 10f)
        {
            landmine_CD += Time.deltaTime;
        }
        if (health_CD < 10f)
        {
            health_CD += Time.deltaTime;
        }
        if (stamina_CD < 10f)
        {
            stamina_CD += Time.deltaTime;
        }

        landmine.text = landmine_count.ToString();
        health_potion.text = health_potion_count.ToString();
        stamina_potion.text = stamina_potion_count.ToString();

        landmine_icon.fillAmount = Mathf.Clamp(landmine_CD / 10f, 0, 1);
        health_potion_icon.fillAmount = Mathf.Clamp(health_CD / 10f, 0, 1);
        stamina_potion_icon.fillAmount = Mathf.Clamp(stamina_CD / 10f, 0, 1);
    }
}
