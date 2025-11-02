using TMPro;
using UnityEngine;

public class loadingScreenTips : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI tipText;

    private string[] tips = {
        "Rolling and Jumping uses Stamina!",
        "Push enemies away to create space.",
        "Remember to use your items!",
        "Check the whole map for extra coins.",
        "The Quicker you go, the less enemies can spawn!"
    };
    void Start()
    {
        int rand = Random.Range(0, tips.Length);
        tipText.text = tips[rand];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
