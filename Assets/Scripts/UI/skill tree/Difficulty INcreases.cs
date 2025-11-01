using UnityEngine;

public class DifficultyINcreases : MonoBehaviour
{
    public static int wave = 10;
    public static bool enableBigEnemies = false;
    public static bool enableEnemyTypes = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wave += 1;
        Debug.Log("wave = " + wave);
        if (wave >= 3)
        {
            enableEnemyTypes = true;
        }
        if (wave >= 5)
        {
            enableBigEnemies = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
