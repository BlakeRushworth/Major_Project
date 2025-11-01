using TMPro;
using UnityEngine;

public class coin_ui : MonoBehaviour
{
    public static int coin_count = 0;
    public TextMeshProUGUI coin_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coin_text.text = coin_count.ToString();
    }
}
