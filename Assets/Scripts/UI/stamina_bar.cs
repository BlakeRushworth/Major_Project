using UnityEngine;
using UnityEngine.UI;

public class stamina_bar : MonoBehaviour
{
    public static float maxStanima;
    public static float currentStanima;
    public static float staminaRegen;
    public static float Roll_stanima_cost = 33f;
    public static float Jump_stanima_cost = 100f;
    public Image Stanimabar;

    void Start()
    {
        staminaRegen = skill_tree.StaminaRegeneration;
        maxStanima = skill_tree.maxStamina;
        currentStanima = maxStanima;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStanima < maxStanima)
        {
            currentStanima += staminaRegen * Time.deltaTime;
        }

        Stanimabar.fillAmount = Mathf.Clamp(currentStanima / maxStanima, 0, 1);
    }
}
