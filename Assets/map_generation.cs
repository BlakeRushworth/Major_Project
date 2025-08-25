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
    const int wall_percentage = 2;

    public static int[,] Hwall_state;
    public static int[,] Vwall_state;
    public static int[,] Hwall_adjasent_count;

    private Vector2 Hwall_coordinate;
    private Vector2 Vwall_coordinate;

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
        Hwall_adjasent_count = new int[,]
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
                Hwall_coordinate = new Vector2((x + 1) / tile_size, ((y + 1) / tile_size) - 1);
                spawn_coords = new Vector3(x, y, 0);
                

                    
                    //print("Hwall at: ( " + (x - 1) / tile_size + " , " + (((y + 1) / tile_size) - 0.5) + " )"                                                 );
                print("Hwall at: " + Hwall_coordinate);
                    //print("Hwall touching: (" + (x - 1) / tile_size + " , " + (y + 1) / tile_size + " )");
                    //print("and ( " + (x - 1) / tile_size + " , " + ((y + 1) - tile_size) / tile_size + " )");
                    //wall_state[(x + 1), (y + 1) / tile_size] = true;
                    //print("Hwall: " + x + y);
                Hwall_check();
                
            }
        }
    }
    public void Vwall_Logic()
    {
        for (int x = tile_size - 1; x < (map_size_x - 1) * tile_size; x = x + tile_size)
        {
            for (int y = 1; y < map_size_y * tile_size; y = y + tile_size)
            {
                Vwall_coordinate = new Vector2(((x - 1) / tile_size), ((y + 1) / tile_size)); 
                spawn_coords = new Vector3(x, y, 0);
                    //int add = (int)wall_coordinate.x + 5;
                    //print(wall_coordinate.x + " " + add);
               

                print("Vwall at: " + Vwall_coordinate);
                //print("Vwall at: ( " + (x + 1) / tile_size + " , " + (y + 1) / tile_size + " )");
                //print("Vwall touching: (" + ((x + 1) - tile_size) / tile_size + " , " + (y - 1) / tile_size + " )");
                //print("and ( " + (x + 1) / tile_size + " , " + (y - 1) / tile_size + " )");
                Vwall_check();
                
            }
        }
    }
    
    public void Hwall_check()
    {
        int adjacent_count = 0;
        if (Hwall_coordinate.x != 0) // not touching the most left side
        {
            //print( Hwall_coordinate + " is not touching left wall");

            if (Hwall_state[((int)Hwall_coordinate.x - 1), (int)Hwall_coordinate.y] == 1)
            {
                print(((int)Hwall_coordinate.x - 1) + " , " + Hwall_coordinate.y + " Hwall is true");
                adjacent_count = adjacent_count + Hwall_adjasent_count[((int)Hwall_coordinate.x - 1), (int)Hwall_coordinate.y];
            }
            if (Vwall_state[((int)Hwall_coordinate.x - 1), ((int)Hwall_coordinate.y + 1)] == 1)
            {
                print(((int)Hwall_coordinate.x - 1) + " , " + ((int)Hwall_coordinate.y + 1) + " Vwall is true");
                adjacent_count = adjacent_count + Hwall_adjasent_count[((int)Hwall_coordinate.x - 1), ((int)Hwall_coordinate.y + 1)];
            }
            if (Vwall_state[((int)Hwall_coordinate.x - 1), (int)Hwall_coordinate.y] == 1)
            {
                print(((int)Hwall_coordinate.x - 1) + " , " + (int)Hwall_coordinate.y + " Vwall is true");
                adjacent_count = adjacent_count + Hwall_adjasent_count[((int)Hwall_coordinate.x - 1), (int)Hwall_coordinate.y];
            }
        }

        if (Hwall_coordinate.x != map_size_x - 1) // not touching the most right side
        {
            //print(Hwall_coordinate + " is not touching right wall");
            if (Hwall_state[((int)Hwall_coordinate.x + 1), (int)Hwall_coordinate.y] == 1)
            {
                print(((int)Hwall_coordinate.x + 1) + " , " + Hwall_coordinate.y + " Hwall is true");
                adjacent_count = adjacent_count+ Hwall_adjasent_count[((int)Hwall_coordinate.x + 1), (int)Hwall_coordinate.y];
            }
            if (Vwall_state[(int)Hwall_coordinate.x, ((int)Hwall_coordinate.y + 1)] == 1)
            {
                print((int)Hwall_coordinate.x + " , " + ((int)Hwall_coordinate.y + 1) + " Vwall is true");
                adjacent_count = adjacent_count + Hwall_adjasent_count[(int)Hwall_coordinate.x, ((int)Hwall_coordinate.y + 1)];
            }
            if (Vwall_state[(int)Hwall_coordinate.x, (int)Hwall_coordinate.y] == 1)
            {
                print((int)Hwall_coordinate.x + " , " + (int)Hwall_coordinate.y + " Vwall is true");
                adjacent_count = adjacent_count + Hwall_adjasent_count[(int)Hwall_coordinate.x, (int)Hwall_coordinate.y];
            }
        }
        if (adjacent_count < 2)
        {
            //print("placeable");
            Hwall_adjasent_count[(int)Hwall_coordinate.x, (int)Hwall_coordinate.y] = adjacent_count + 1;
            int chance = Random.Range(0, wall_percentage);
            if (chance == 0)
            {
                print("spawned: " + Hwall_adjasent_count[(int)Hwall_coordinate.x, (int)Hwall_coordinate.y]);
                Hwall_state[((int)Hwall_coordinate.x), (int)Hwall_coordinate.y] = 1;
                Spawn_Hwall();
            }
            else
            {
                print("didnt spawn by chance " + Hwall_adjasent_count[(int)Hwall_coordinate.x, (int)Hwall_coordinate.y]);
            }
        }
        else
        {
            Hwall_adjasent_count[(int)Hwall_coordinate.x, (int)Hwall_coordinate.y] = adjacent_count;
            print("Not placeable at " + Hwall_coordinate + " as touching " + adjacent_count + " walls.");
        }
    }
    public void Vwall_check()
    {
        int adjacent_count = 0;
        if (Vwall_coordinate.y == 0)
        {
            //bottom 3 dont check
            print( Hwall_coordinate + " is not touching left wall");
            /*
            if (Hwall_state[((int)Hwall_coordinate.x - 1), (int)Hwall_coordinate.y] == 1)
            {
                print(((int)Hwall_coordinate.x - 1) + " , " + Hwall_coordinate.y + " Hwall is true");
                adjacent_count = adjacent_count + Hwall_adjasent_count[((int)Hwall_coordinate.x - 1), (int)Hwall_coordinate.y];
            }
            if (Vwall_state[((int)Hwall_coordinate.x - 1), ((int)Hwall_coordinate.y + 1)] == 1)
            {
                print(((int)Hwall_coordinate.x - 1) + " , " + ((int)Hwall_coordinate.y + 1) + " Vwall is true");
                adjacent_count = adjacent_count + Hwall_adjasent_count[((int)Hwall_coordinate.x - 1), ((int)Hwall_coordinate.y + 1)];
            }
            if (Vwall_state[((int)Hwall_coordinate.x - 1), (int)Hwall_coordinate.y] == 1)
            {
                print(((int)Hwall_coordinate.x - 1) + " , " + (int)Hwall_coordinate.y + " Vwall is true");
                adjacent_count = adjacent_count + Hwall_adjasent_count[((int)Hwall_coordinate.x - 1), (int)Hwall_coordinate.y];
            }
            */
        }
        if (Hwall_coordinate.y == map_size_y)
        {
            //top 3 dont check
            print(Hwall_coordinate + " is not touching right wall");
            /*
            if (Hwall_state[((int)Hwall_coordinate.x + 1), (int)Hwall_coordinate.y] == 1)
            {
                print(((int)Hwall_coordinate.x + 1) + " , " + Hwall_coordinate.y + " Hwall is true");
                adjacent_count = adjacent_count + Hwall_adjasent_count[((int)Hwall_coordinate.x + 1), (int)Hwall_coordinate.y];
            }
            if (Vwall_state[(int)Hwall_coordinate.x, ((int)Hwall_coordinate.y + 1)] == 1)
            {
                print((int)Hwall_coordinate.x + " , " + ((int)Hwall_coordinate.y + 1) + " Vwall is true");
                adjacent_count = adjacent_count + Hwall_adjasent_count[(int)Hwall_coordinate.x, ((int)Hwall_coordinate.y + 1)];
            }
            if (Vwall_state[(int)Hwall_coordinate.x, (int)Hwall_coordinate.y] == 1)
            {
                print((int)Hwall_coordinate.x + " , " + (int)Hwall_coordinate.y + " Vwall is true");
                adjacent_count = adjacent_count + Hwall_adjasent_count[(int)Hwall_coordinate.x, (int)Hwall_coordinate.y];
            }
            */
        }

        if (adjacent_count < 2)
        {
            //print("placeable");
            Vwall_state[(int)Vwall_coordinate.x, (int)Vwall_coordinate.y] = adjacent_count + 1;
            int chance = Random.Range(0, wall_percentage);
            if (chance == 0)
            {
                print("spawned: " + Hwall_adjasent_count[(int)Hwall_coordinate.x, (int)Hwall_coordinate.y]);
                Vwall_state[(int)Vwall_coordinate.x, (int)Vwall_coordinate.y] = 1;
                Spawn_Vwall();
            }
            else
            {
                print("didnt spawn by chance " + Hwall_adjasent_count[(int)Hwall_coordinate.x, (int)Hwall_coordinate.y]);
            }
        }
        else
        {
            Vwall_state[(int)Vwall_coordinate.x, (int)Vwall_coordinate.y] = adjacent_count;
            print("Not placeable at " + Hwall_coordinate + " as touching " + adjacent_count + " walls.");
        }


    }
    
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
        //Hwall_Logic();
        
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
