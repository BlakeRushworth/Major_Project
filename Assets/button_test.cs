using UnityEngine;
using UnityEngine.Tilemaps;


public class button_test : MonoBehaviour
{
    
    public GameObject prefab;

    public int x = 0;
    public int y = 0;

    public void Start()
    {
        
    }

    public void test_button()
    {
        //GameObject prefabToLoad = Resources.Load<GameObject>(prefabPathInResources);
        //spawn();
        print("wall state at: ( " + x + " , " + y + " ) is " + map_generation.wall_state[x, y]);
    }

    public void spawn()
    {
        

        /*
        if (prefab != null)
        {
            // Instantiate the prefab at a specific position and rotation
            Instantiate(prefab, Vector3.zero, Quaternion.identity);
            Debug.Log("Prefab instantiated successfully!");
        }
        else
        {
            Debug.LogError("Prefab not found at path: " + prefab);
        }
        */
    }
}
