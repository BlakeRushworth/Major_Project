using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class market_stall : MonoBehaviour
{

    public GameObject shop_ui;
    public float landmine_cost = 10;
    public float health_potion_cost = 15;
    public float stamina_potion_cost = 5;

    public TextMeshProUGUI landmine_text;
    public TextMeshProUGUI health_potion_text;
    public TextMeshProUGUI stamina_potion_text;
    void Start()
    {
        if (skill_tree.shop_discount)
        {
            landmine_cost *= (float)0.75;
            health_potion_cost *= (float)0.75;
            stamina_potion_cost *= (float)0.75;

            landmine_cost = Mathf.RoundToInt(landmine_cost);
            health_potion_cost = Mathf.RoundToInt(health_potion_cost);
            stamina_potion_cost = Mathf.RoundToInt(stamina_potion_cost);
        }
    }

    // Update is called once per frame
    void Update()
    {
        landmine_text.text = ("bomb - $" + landmine_cost);
        health_potion_text.text = ("health pot - $" + health_potion_cost);
        stamina_potion_text.text = ("stamina pot - $" + stamina_potion_cost);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.Mouse0))
        //{
        //    Debug.Log("worked in collision");
        //    Time.timeScale = 0;
        //    shop_ui.SetActive(true);
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("worked in trigger");
            Time.timeScale = 0;
            shop_ui.SetActive(true);
        }
    }

    public void backButton()
    {
        Time.timeScale = 1;
        shop_ui.SetActive(false);
    }

    public void BuyLandmine()
    {
        if (coin_ui.coin_count >= landmine_cost)
        {
            Debug.Log("clicked landmine");
            items_hotbar.landmine_count += 1;
            coin_ui.coin_count -= (int)landmine_cost;
        }
    }

    public void BuyHealthPotion()
    {
        if (coin_ui.coin_count >= health_potion_cost)
        {
            Debug.Log("clicked health");
            items_hotbar.health_potion_count += 1;
            coin_ui.coin_count -= (int)health_potion_cost;
        }  
    }
    public void BuyStaminaPotion()
    {
        if (coin_ui.coin_count >= stamina_potion_cost)
        {
            Debug.Log("clicked stamina");
            items_hotbar.stamina_potion_count += 1;
            coin_ui.coin_count -= (int)stamina_potion_cost;
        }
    }
}

