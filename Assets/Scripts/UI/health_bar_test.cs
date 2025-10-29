using UnityEngine;
using UnityEngine.UI;

public class health_bar_test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static float maxHealth;
    public static float currentHealth;
    public static float healthRegen;

    public Image healthbar;
    void Start()
    {
        maxHealth = skill_tree.maxHealth;
        healthRegen = skill_tree.HealthRegeneration;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healthRegen * Time.deltaTime;
        }
        //Debug.Log("current health = " + currentHealth + " max health = " + maxHealth + " healthRegen = " + healthRegen);
        healthbar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1);
    }
}
