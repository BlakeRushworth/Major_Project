using UnityEngine;
using UnityEngine.Tilemaps;


public class button_test : MonoBehaviour
{
    
    public GameObject prefab;

    public int Hx = 0;
    public int Hy = 0;

    public int Vx = 0;
    public int Vy = 0;

    public void Start()
    {
        
    }

    public void test_button()
    {
        //GameObject prefabToLoad = Resources.Load<GameObject>(prefabPathInResources);
        //spawn();
        print("Hwall state at: ( " + Hx + " , " + Hy + " ) is " + map_generation.Hwall_state[Hx, Hy]);
        print("Vwall state at: ( " + Vx + " , " + Vy + " ) is " + map_generation.Vwall_state[Vx, Vy]);
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
