using UnityEngine;
using UnityEngine.UI;

public class stanima_bar : MonoBehaviour
{
    public static float maxStanima = 100f;
    public static float currentStanima = 100f;
    public static float staminaRegen = 10;
    public static float stanima_cost = 33f;
    public Image Stanimabar;

    void Start()
    {
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
