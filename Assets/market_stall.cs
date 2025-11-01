using System.Runtime.CompilerServices;
using UnityEngine;

public class market_stall : MonoBehaviour
{

    public GameObject shop_ui;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.Mouse0))
        {
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
        Debug.Log("clicked landmine");
        items_hotbar.landmine_count += 1;
    }

    public void BuyHealthPotion()
    {
        Debug.Log("clicked health");
        items_hotbar.health_potion_count += 1;
    }
    public void BuyStaminaPotion()
    {
        Debug.Log("clicked stamina");
        items_hotbar.stamina_potion_count += 1;
    }
}

