using UnityEngine;

public class DifficultyINcreases : MonoBehaviour
{
    public static int wave = 1;
    public static bool enableBigEnemies = false;
    public static bool enableEnemyTypes = false;
    public static int enemyTypesUnlocked = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wave += 1;
        Debug.Log("wave = " + wave);
        if (wave >= 3)
        {
            enableEnemyTypes = true;
            enemyTypesUnlocked = wave - 2;
            if (enemyTypesUnlocked > 5)
            {
                enemyTypesUnlocked = 5;
            }
        }
        if (wave >= 6)
        {
            enableBigEnemies = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
