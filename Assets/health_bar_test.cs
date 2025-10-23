using UnityEngine;
using UnityEngine.UI;

public class health_bar_test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static float maxHealth = 100f;
    public static float currentHealth = 100f;
    public Image healthbar;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1);
    }
}
