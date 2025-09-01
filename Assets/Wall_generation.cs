using Unity.VisualScripting;
using UnityEngine;

public class Wall_generation : MonoBehaviour
{
    public GameObject GridBlock;
    public GameObject Hwall;
    public GameObject Vwall;

    private Vector2 grid_coordinate;
    private Vector3 spawn_coords;

    private int map_size_x;
    private int map_size_y;
    const int tile_size = 16;
    const int wall_percentage = 2;
    private int touching_edgeWall = 0;
    private bool can_spawnWall;

    public static int[,] Hwall_state;
    public static int[,] Vwall_state;

    private Vector2 Hwall_coordinate;
    private Vector2 Vwall_coordinate;
    private Vector2 Update_coordinate;

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
                Hwall_coordinate = new Vector2((x + 1) / tile_size, ((y + 1) / tile_size) - 1);
                spawn_coords = new Vector3(x, y, 0);
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
                Vwall_check();

            }
        }
    }

    public void Hwall_check()
    {
        can_spawnWall = true;
        touching_edgeWall = 0;

        if (Hwall_coordinate.x == 0 || Hwall_coordinate.x == map_size_x - 1)
        {
            touching_edgeWall++;
            print("touching outerwall:" + touching_edgeWall);
        }

        if (Hwall_coordinate.x != 0) // not touching the most left side
        {
            if (Hwall_state[((int)Hwall_coordinate.x - 1), (int)Hwall_coordinate.y] > 0) //direct left check
            {
                if (Hwall_state[((int)Hwall_coordinate.x - 1), (int)Hwall_coordinate.y] == 2) // if touching a side connector
                {
                    touching_edgeWall++;
                    print("touching direct left:" + touching_edgeWall);
                }
            }
            if (Vwall_state[((int)Hwall_coordinate.x - 1), ((int)Hwall_coordinate.y + 1)] > 0) // left up check
            {
                if (Vwall_state[((int)Hwall_coordinate.x - 1), ((int)Hwall_coordinate.y + 1)] == 2) // if touching a side connector
                {
                    touching_edgeWall++;
                    print("touching left up:" + touching_edgeWall);
                }
            }
            if (Vwall_state[((int)Hwall_coordinate.x - 1), (int)Hwall_coordinate.y] > 0) // left down check
            {
                if (Vwall_state[((int)Hwall_coordinate.x - 1), (int)Hwall_coordinate.y] == 2) // if touching a side connector
                {
                    touching_edgeWall++;
                    print("touching left down:" + touching_edgeWall);
                }
            }
        }
        
        if (Hwall_coordinate.x != map_size_x - 1) // not touching the most right side
        {
            if (Hwall_state[((int)Hwall_coordinate.x + 1), (int)Hwall_coordinate.y] > 0) // direct right check
            {
                if (Hwall_state[((int)Hwall_coordinate.x + 1), (int)Hwall_coordinate.y] == 2) // if touching a side connector
                {
                    touching_edgeWall++;
                    print("touching direct right:" + touching_edgeWall);
                }
            }
            if (Vwall_state[(int)Hwall_coordinate.x, ((int)Hwall_coordinate.y + 1)] > 0) // up right check
            {
                if (Vwall_state[(int)Hwall_coordinate.x, ((int)Hwall_coordinate.y + 1)] == 2) // if touching a side connector
                {
                    touching_edgeWall++;
                    print("touching right up:" + touching_edgeWall);
                }
            }
            if (Vwall_state[(int)Hwall_coordinate.x, (int)Hwall_coordinate.y] > 0) // down right check
            {
                if (Vwall_state[(int)Hwall_coordinate.x, (int)Hwall_coordinate.y] == 2) // if touching a side connector
                {
                    touching_edgeWall++;
                    print("touching right down:" + touching_edgeWall);
                }
            }
        
        }
        if (touching_edgeWall > 1) 
        {
            can_spawnWall = false;
        }
        if (touching_edgeWall < 2)
        {
            int chance = Random.Range(0, wall_percentage);
            print("at: " + Hwall_coordinate + " touching: " + touching_edgeWall + " side walls");
            if (chance == 0)
            {
                if (touching_edgeWall == 1)
                {
                    print("YES: H side wall " + Hwall_coordinate);
                    Hwall_state[((int)Hwall_coordinate.x), (int)Hwall_coordinate.y] = 2;
                    Update_coordinate = Hwall_coordinate;
                    Hwall_Update();
                }
                else if (touching_edgeWall == 0)
                {
                    print("YES: H mid wall " + Hwall_coordinate);
                    Hwall_state[((int)Hwall_coordinate.x), (int)Hwall_coordinate.y] = 1;
                }
                else
                {
                    print("ERROR: touching_edgeWall invalid integer: " + touching_edgeWall);
                }
                Spawn_Hwall();
            }
            else
            {
                print("NO: H side wall " + Hwall_coordinate);
            }
        }
        else
        {
            print("H wall:" + Hwall_coordinate + " cant spawn: " + touching_edgeWall);
        }
    }

    public void Vwall_check()
    {
        can_spawnWall = true;
        touching_edgeWall = 0;

        if (Vwall_coordinate.y == 0 || Vwall_coordinate.y == map_size_y - 1)
        {
            touching_edgeWall += 1;
        }

        if (Vwall_coordinate.y != 0) // not touching the most bottom side
        {
            if (Vwall_state[(int)Vwall_coordinate.x, ((int)Vwall_coordinate.y - 1)] > 0) //direct down check
            {
                if (Vwall_state[(int)Vwall_coordinate.x, ((int)Vwall_coordinate.y - 1)] == 2) // if touching a side connector
                {
                    touching_edgeWall++;
                    if (touching_edgeWall > 1) // if touching 2 or more sides
                    {
                        can_spawnWall = false;
                    }
                }
            }
            if (Hwall_state[(int)Vwall_coordinate.x, ((int)Vwall_coordinate.y - 1)] > 0) // down left check
            {
                if (Hwall_state[(int)Vwall_coordinate.x, ((int)Vwall_coordinate.y - 1)] == 2) // if touching a side connector
                {
                    touching_edgeWall++;
                    if (touching_edgeWall > 1) // if touching 2 or more sides
                    {
                        can_spawnWall = false;
                    }
                }
            }
            if (Hwall_state[((int)Vwall_coordinate.x + 1), ((int)Vwall_coordinate.y - 1)] > 0) // down right check
            {
                if (Hwall_state[((int)Vwall_coordinate.x + 1), ((int)Vwall_coordinate.y - 1)] == 2) // if touching a side connector
                {
                    touching_edgeWall++;
                    if (touching_edgeWall > 1) // if touching 2 or more sides
                    {
                        can_spawnWall = false;
                    }
                }
            }
        }
        if (Vwall_coordinate.y != map_size_y - 1) // not touching the most top side
        {
            if (Vwall_state[(int)Vwall_coordinate.x, ((int)Vwall_coordinate.y + 1)] > 0) // direct up check
            {
                if (Vwall_state[(int)Vwall_coordinate.x, ((int)Vwall_coordinate.y + 1)] == 2) // if touching a side connector
                {
                    touching_edgeWall++;
                    if (touching_edgeWall > 1) // if touching 2 or more sides
                    {
                        can_spawnWall = false;
                    }
                }
            }
            if (Hwall_state[(int)Vwall_coordinate.x, (int)Vwall_coordinate.y] > 0) // up left check
            {
                if (Hwall_state[(int)Vwall_coordinate.x, (int)Vwall_coordinate.y] == 2) // if touching a side connector
                {
                    touching_edgeWall++;
                    if (touching_edgeWall > 1) // if touching 2 or more sides
                    {
                        can_spawnWall = false;
                    }
                }
            }
            if (Hwall_state[((int)Vwall_coordinate.x + 1), (int)Vwall_coordinate.y] > 0) // up right check
            {
                if (Hwall_state[((int)Vwall_coordinate.x + 1), (int)Vwall_coordinate.y] == 2) // if touching a side connector
                {
                    touching_edgeWall++;
                    if (touching_edgeWall > 1) // if touching 2 or more sides
                    {
                        can_spawnWall = false;
                    }
                }
            }
        }
        if (can_spawnWall)
        {
            int chance = Random.Range(0, wall_percentage);
            print("at: " + Vwall_coordinate + " touching: " + touching_edgeWall + " side walls");
            if (chance == 0)
            {
                if (touching_edgeWall == 1)
                {
                    print("YES: V side wall " + Vwall_coordinate);
                    Vwall_state[(int)Vwall_coordinate.x, (int)Vwall_coordinate.y] = 2;
                    Update_coordinate = Vwall_coordinate;
                    Vwall_Update();
                }
                else if (touching_edgeWall == 0)
                {
                    print("YES: V mid wall " + Vwall_coordinate);
                    Vwall_state[(int)Vwall_coordinate.x, (int)Vwall_coordinate.y] = 1;
                }
                else
                {
                    print("ERROR: touching_edgeWall invalid integer: " + touching_edgeWall);
                }
                Spawn_Vwall();
            }
            else
            {
                print("NO: V side wall " + Vwall_coordinate);
            }

        }
        else
        {
            print("V wall:" + Vwall_coordinate + " cant spawn: " + touching_edgeWall);
        }
    }

    public void Hwall_Update() //update all walls that are touching to side walls
    {
        if (Update_coordinate.x != 0) // not touching the most left side
        {
            if (Hwall_state[((int)Update_coordinate.x - 1), (int)Update_coordinate.y] > 0) //direct left check
            {
                Hwall_state[((int)Update_coordinate.x - 1), (int)Update_coordinate.y] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x - 1, (int)Update_coordinate.y);
                Hwall_Update();
            }
            if (Vwall_state[((int)Update_coordinate.x - 1), ((int)Update_coordinate.y + 1)] > 0) // left up check
            {
                Vwall_state[((int)Update_coordinate.x - 1), ((int)Update_coordinate.y + 1)] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x - 1, (int)Update_coordinate.y + 1);
                Vwall_Update();
            }
            if (Vwall_state[((int)Update_coordinate.x - 1), (int)Update_coordinate.y] > 0) // left down check
            {
                Vwall_state[((int)Update_coordinate.x - 1), (int)Update_coordinate.y] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x - 1, (int)Update_coordinate.y);
                Vwall_Update();
            }
        }

        if (Update_coordinate.x != map_size_x - 1) // not touching the most right side
        {
            if (Hwall_state[((int)Update_coordinate.x + 1), (int)Update_coordinate.y] == 1) // direct right check
            {
                Hwall_state[((int)Update_coordinate.x + 1), (int)Update_coordinate.y] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x + 1, (int)Update_coordinate.y);
                Hwall_Update();
            }
            if (Vwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y + 1)] == 1) // up right check
            {
                Vwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y + 1)] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x, (int)Update_coordinate.y + 1);
                Vwall_Update();
            }
            if (Vwall_state[(int)Update_coordinate.x, (int)Update_coordinate.y] == 1) // down right check
            {
                Vwall_state[(int)Update_coordinate.x, (int)Update_coordinate.y] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x, (int)Update_coordinate.y);
                Vwall_Update();
            }
        }
    }

    public void Vwall_Update() //update all walls that are touching to side walls
    {
        if (Update_coordinate.y != 0) // not touching the most bottom side
        {
            if (Vwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y - 1)] == 1) //direct down check
            {
                Vwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y - 1)] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x, (int)Update_coordinate.y - 1);
                Vwall_Update();
            }
            if (Hwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y - 1)] == 1) // down left check
            {
                Hwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y - 1)] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x, (int)Update_coordinate.y - 1);
                Hwall_Update();
            }
            if (Hwall_state[((int)Update_coordinate.x + 1), ((int)Update_coordinate.y - 1)] == 1) // down right check
            {
                Hwall_state[((int)Update_coordinate.x + 1), ((int)Update_coordinate.y - 1)] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x + 1, (int)Update_coordinate.y - 1);
                Hwall_Update();
            }
        }
        if (Update_coordinate.y != map_size_y - 1) // not touching the most top side
        {
            if (Vwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y + 1)] > 0) // direct up check
            {
                Vwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y + 1)] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x, (int)Update_coordinate.y + 1);
                Vwall_Update();
            }
            if (Hwall_state[(int)Update_coordinate.x, (int)Update_coordinate.y] > 0) // up left check
            {
                Hwall_state[(int)Update_coordinate.x, (int)Update_coordinate.y] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x, (int)Update_coordinate.y);
                Hwall_Update();
            }
            if (Hwall_state[((int)Update_coordinate.x + 1), (int)Update_coordinate.y] > 0) // up right check
            {
                Hwall_state[((int)Update_coordinate.x + 1), (int)Update_coordinate.y] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x + 1, (int)Update_coordinate.y);
                Hwall_Update();
            }
        }
    }
    
    public void Spawn_Vwall()
    {
        if (Vwall != null)
        {
            Instantiate(Vwall, spawn_coords, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab not found at path: " + Vwall);
        }
    }
    public void Spawn_Hwall()
    {
        if (Hwall != null)
        {
            Instantiate(Hwall, spawn_coords, Quaternion.identity);
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
            Instantiate(GridBlock, spawn_coords, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab not found at path: " + GridBlock);
        }
    }
}