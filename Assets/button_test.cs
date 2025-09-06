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
        print("wall at: ( " + x + " , " + y + " ) is " + HuntandKill_Algorithm.tileIdentifier[x, y]);
        //print("Vwall touch count at: ( " + Vx + " , " + Vy + " ) is " + Wall_generation.Vwall_state[Vx, Vy]);
        //print("Hwall state at: ( " + Hx + " , " + Hy + " ) is " + map_generation.Hwall_state[Hx, Hy]);
        //print("Vwall state at: ( " + Vx + " , " + Vy + " ) is " + map_generation.Vwall_state[Vx, Vy]);
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
