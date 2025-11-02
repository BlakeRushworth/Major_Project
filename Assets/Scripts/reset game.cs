using UnityEngine;

public class resetgame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        for (int i = 0; i < skill_tree.skillTreeOnce.Length; i++)
        {
            skill_tree.skillTreeOnce[i] = false;
        }
        skill_tree.resetLines = false;

        skill_tree.skillpoint = 0;

        skill_tree.player_speed = 6f;
        skill_tree.player_jump_range = 0f;
        skill_tree.player_roll_speed = 12f;

        skill_tree.maxStamina = 100f;
        skill_tree.maxHealth = 100f;
        skill_tree.StaminaRegeneration = 10f;
        skill_tree.HealthRegeneration = 0f;

        skill_tree.Obelisk_Speed = false;
        skill_tree.shop_discount = false;

        skill_tree.BurningImmunity = false;
        skill_tree.PoisonedImmunity = false;
        skill_tree.FreezingImmunity = false;

        DifficultyINcreases.wave = 1;
        DifficultyINcreases.enableBigEnemies = false;
        DifficultyINcreases.enableEnemyTypes = false;
        DifficultyINcreases.enemyTypesUnlocked = 1;

        coin_ui.coin_count = 0;
        items_hotbar.landmine_count = 0;
        items_hotbar.health_potion_count = 0;
        items_hotbar.stamina_potion_count = 0;
    }
}
