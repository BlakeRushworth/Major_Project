using UnityEngine;

public class map_generation : MonoBehaviour
{
    public GameObject GridBlock;
    //public GameObject testprefab;
    public GameObject Hwall;
    public GameObject Vwall;

    private Vector2 grid_coordinate;

    private Vector3 spawn_coords;
    private int map_size_x;
    private int map_size_y;
    const int tile_size = 16;
    const int wall_percentage = 5;

    public static int[,] Hwall_state;
    public static int[,] Vwall_state;

    void Start()
    {
        Hwall_state = new int[,]
        {
            { 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0}
        };
        Vwall_state = new int[,]
        {
            { 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0}
        };
        Grid_Logic();
    }


    void Update()
    {

    }
    public void Hwall_Logic()
    {
        for (int x = 1; x < map_size_x * tile_size; x = x + tile_size)
        {
            for (int y = tile_size - 1; y < (map_size_y - 1) * tile_size; y = y + tile_size)
            {
                Vector2 wall_coordinate = new Vector2((x + 1) / tile_size, ((y + 1) / tile_size) - 1);
                spawn_coords = new Vector3(x, y, 0);
                int chance = Random.Range(0, wall_percentage);
                if (chance == 0)
                {

                    Hwall_state[((int)wall_coordinate.x), (int)wall_coordinate.y] = 1; 
                    //print("Hwall at: ( " + (x - 1) / tile_size + " , " + (((y + 1) / tile_size) - 0.5) + " )"                                                 );
                    print("Hwall at: " + wall_coordinate);
                    //print("Hwall touching: (" + (x - 1) / tile_size + " , " + (y + 1) / tile_size + " )");
                    //print("and ( " + (x - 1) / tile_size + " , " + ((y + 1) - tile_size) / tile_size + " )");
                    //wall_state[(x + 1), (y + 1) / tile_size] = true;
                    //print("Hwall: " + x + y);
                    Spawn_Hwall();
                }
            }
        }
    }
    public void Vwall_Logic()
    {
        for (int x = tile_size - 1; x < (map_size_x - 1) * tile_size; x = x + tile_size)
        {
            for (int y = 1; y < map_size_y * tile_size; y = y + tile_size)
            {
                Vector2 wall_coordinate = new Vector2(((x - 1) / tile_size), ((y + 1) / tile_size)); 
                spawn_coords = new Vector3(x, y, 0);
                int chance =  Random.Range(0, wall_percentage);
                if (chance == 0)
                {   
                    //int add = (int)wall_coordinate.x + 5;
                    //print(wall_coordinate.x + " " + add);
                    Vwall_state[(int)wall_coordinate.x, (int)wall_coordinate.y] = 1; // the first 5 rows are horisontal since 0 is the lowest you need to add 6 to give enough room.

                    print("Vwall at: " + wall_coordinate);
                    //print("Vwall at: ( " + (x + 1) / tile_size + " , " + (y + 1) / tile_size + " )");
                    //print("Vwall touching: (" + ((x + 1) - tile_size) / tile_size + " , " + (y - 1) / tile_size + " )");
                    //print("and ( " + (x + 1) / tile_size + " , " + (y - 1) / tile_size + " )");
                    Spawn_Vwall();
                }
            }
        }
    }
    /*
    public void Hwall_check()
    {
        int adjacent_count = 0;
    }
    public void Vwall_check()
    {
        int adjacent_count = 0;
    }
    */
    public void Spawn_Vwall()
    {
        //print("Vwall");
        if (Vwall != null)
        {
            // Instantiate the prefab at a specific position and rotation
            Instantiate(Vwall, spawn_coords, Quaternion.identity);
            //Debug.Log("Prefab instantiated successfully!");
        }
        else
        {
            Debug.LogError("Prefab not found at path: " + Vwall);
        }
    }


    public void Spawn_Hwall()
    {
        //print("Hwall");
        if (Hwall != null)
        {
            // Instantiate the prefab at a specific position and rotation
            Instantiate(Hwall, spawn_coords, Quaternion.identity);
            //Debug.Log("Prefab instantiated successfully!");
        }
        else
        {
            Debug.LogError("Prefab not found at path: " + Hwall);
        }
    }



    public void Grid_Logic()
    {
        map_size_x = Random.Range(3, 6);
        map_size_y = Random.Range(3, 6);// picks map size from 3x3 to 5x5
        for (int x = 0; x < map_size_x * tile_size; x = x + tile_size)
        {
            for (int y = 0; y < map_size_y * tile_size; y = y + tile_size)
            {
                grid_coordinate.x = x / tile_size;
                grid_coordinate.y = y / tile_size;
                //print(" grid: " + grid_coordinate);
                spawn_coords = new Vector3(x, y, 0);
                Spawn_Grid();
            }
        }
        
        Vwall_Logic();
        Hwall_Logic();
        
    }
    public void Spawn_Grid()
    {
        if (GridBlock != null)
        {
            // Instantiate the prefab at a specific position and rotation
            Instantiate(GridBlock, spawn_coords, Quaternion.identity);
            //Debug.Log("Prefab instantiated successfully!");
        }
        else
        {
            Debug.LogError("Prefab not found at path: " + GridBlock);
        }
    }
}
