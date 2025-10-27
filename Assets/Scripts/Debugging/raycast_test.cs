using UnityEngine;

public class raycast_test : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public GameObject obj;

    public float detect_dist = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    private void Update()
    {
        Vector2 enemyPos = left.transform.position;
        Vector2 playerPos = right.transform.position;
        Vector2 direction = (playerPos - enemyPos);
        float distance = Vector2.Distance(enemyPos, playerPos);

        if (distance <= detect_dist)
        {
            // Perform a Raycast between the enemy and the player
            Debug.DrawRay(enemyPos, direction, color: Color.white);
            RaycastHit2D hit = Physics2D.Raycast(enemyPos, direction, distance);

            if (hit.collider != null)
            {
                // Check what the ray hit
                if (hit.collider.gameObject == right)
                {
                    Debug.DrawRay(enemyPos, direction, color: Color.green);
                    Debug.Log("Player is visible — no obstacles in between.");
                }
                else
                {
                    Debug.DrawRay(enemyPos, direction, color: Color.red);
                    Debug.Log($"Object '{hit.collider.name}' is blocking the view.");
                }
            }
            else
            {
                Debug.Log(" No hit detected (no collider in between).");
            }
        }
    }
}

