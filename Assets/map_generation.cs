using UnityEngine;

public class map_generation : MonoBehaviour
{
    public GameObject prefab;

    private Vector3 spawn_coords;
    private int map_size_x;
    private int map_size_y;
    const int tile_size = 16;
    void Start()
    {
        map_size_x = Random.Range(3, 6);
        map_size_y = Random.Range(3, 6);// picks map size from 3x3 to 5x5
        for ( int x = 0; x < map_size_x * tile_size; x = x+16)
        {
            for (int y = 0; y < map_size_y * tile_size; y = y+16)
            {
                print("( " + x + " , " + y + " )");
                spawn_coords = new Vector3(x, y, 0);
                spawn();
            }
        }
    }

    
    void Update()
    {
       
    }

    public void spawn()
    {
        if (prefab != null)
        {
            // Instantiate the prefab at a specific position and rotation
            Instantiate(prefab, spawn_coords, Quaternion.identity);
            Debug.Log("Prefab instantiated successfully!");
        }
        else
        {
            Debug.LogError("Prefab not found at path: " + prefab);
        }
    }

}
