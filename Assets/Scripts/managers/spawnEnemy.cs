using UnityEngine;
using UnityEngine.Tilemaps;

public class spawnEnemy : MonoBehaviour
{
    public float radius = 10f;
    //public Vector2 center = Vector2.zero; // Default to (0,0)

    GameObject player;
    public GameObject enemy;
    public Tilemap targetTilemap;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("SpawnEnemy", 2, 2);
    }

    private void Update()
    {
        
    }

    public Vector2 GetRandomPointInsideCircle(Vector2 circleCenter, float circleRadius)
    {
        // Get a random point within a unit circle (radius 1, centered at 0,0)
        Vector2 randomUnitPoint = Random.insideUnitCircle;

        // Scale the point by the desired radius
        Vector2 scaledPoint = randomUnitPoint * circleRadius;

        // Offset the point by the desired center position
        Vector2 finalPoint = circleCenter + scaledPoint;

        return finalPoint;

        
    }

    public void SpawnEnemy()
    {
        Vector2 randomPointInsideCircle = GetRandomPointInsideCircle(player.transform.position, radius);
        //Debug.Log("Random point inside circle: " + randomPointInsideCircle);
        Vector3Int cellPosition = targetTilemap.WorldToCell(randomPointInsideCircle);
        //Debug.Log("cell pos: " + cellPosition);

        TileBase tileAtPosition = targetTilemap.GetTile(cellPosition);

        if (tileAtPosition == null)
        {
            //Debug.Log("can spawn");
            Instantiate(enemy, randomPointInsideCircle, Quaternion.identity);
        }
        else
        {
            //Debug.Log("can't spawn");
            SpawnEnemy();
        }
    }
}
