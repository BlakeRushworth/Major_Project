using NUnit.Framework;
using System.ComponentModel.Design;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.VFX;

public class HuntandKill_Algorithm : MonoBehaviour
{
    public GameObject Hwall;
    public GameObject Vwall;
    private Vector2Int mapSize;
    private const int cubeSize = 32;

    private Vector2Int starting_pos;
    private Vector2 Coordinate;
    private Vector2Int currentTile;

    public const int NORTH = 0;
    public const int SOUTH = 1;
    public const int WEST = 2;
    public const int EAST = 3;

    public const int UP = 1;
    public const int RIGHT = 2;
    public const int DOWN = 4;
    public const int LEFT = 8;


    public static int[,] tileIdentifier;

    public int[] DirectionState = new int[4];
    private int directionCount;
    private int randomDirection;
    private int directionChosen;

    public GameObject[] tiles;

    private void Start()
    {
        StartingPoint();
        algorithm();
    }
    public void spawn_walls()
    {
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                string name = (tileIdentifier[x, y]).ToString();
                print("name: " + name);
                Coordinate = new Vector2(x * cubeSize, y * cubeSize);
                for (int i = 0; i < tiles.Length; i++)
                {
                    if (tiles[i].name == name)
                    {
                        Instantiate(tiles[i], Coordinate, Quaternion.identity);
                    }
                }
            }
        }
    }

    public void algorithm()
    {
        checkSurrondingTiles(currentTile);
        nextDirectionLogic();
    }

    public void StartingPoint()
    {
        mapSize.x = Random.Range(3, 6);
        mapSize.y = Random.Range(3, 6);
        tileIdentifier = new int[mapSize.x, mapSize.y];
        print("mapsize: " + mapSize);


        if (Random.Range(0, 2) == 0) //top or bottom
        {
            starting_pos.x = Random.Range(0, mapSize.x - 1);
            if (Random.Range(0, 2) == 0)
            {
                starting_pos.y = 0;
            }
            else
            {
                starting_pos.y = mapSize.y - 1;
            }
        }
        else //left or right
        {
            starting_pos.y = Random.Range(0, mapSize.y - 1);
            if (Random.Range(0, 2) == 0)
            {
                starting_pos.x = 0;
            }
            else
            {
                starting_pos.x = mapSize.x - 1;
            }
        }
        print("starting at: " + starting_pos);
        currentTile = starting_pos;
        //tileIdentifier[currentTile.x, currentTile.y] = 1;
    }

    public void checkSurrondingTiles(Vector2Int tile)
    {
        for (int i = 0; i < 4; i++)
        {
            DirectionState[i] = 0;
        }

        if (tile.y != mapSize.y - 1)
        {
            if (tileIdentifier[tile.x, tile.y + 1] == 0)
            {
                //up can spawn
                //print("up can spawn");
                DirectionState[0] = 1;
            }
        }
        if (tile.y != 0)
        {
            if (tileIdentifier[tile.x, tile.y - 1] == 0)
            {
                //down can spawn
                //print("down can spawn");
                DirectionState[1] = 1;
            }
        }
        if (tile.x != 0)
        {
            if (tileIdentifier[tile.x - 1, tile.y] == 0)
            {
                //left can spawn
                //print("left can spawn");
                DirectionState[2] = 1;
            }
        }
        if (tile.x != mapSize.x - 1)
        {
            if (tileIdentifier[tile.x + 1, tile.y] == 0)
            {
                //right can spawn
                //print("right can spawn");
                DirectionState[3] = 1;
            }
        }
    }

    public void nextDirectionLogic()
    {
        directionCount = 0;
        for (int i = 0; i < 4; i++)
        {
            if (DirectionState[i] == 1)
            {
                directionCount++;
            }
        }
        if (directionCount != 0)
        {
            print("count: " + directionCount);
            randomDirection = Random.Range(0, directionCount);
            print("random value: " + randomDirection);
            var count = 0;
            for (int i = 0; i < 4; i++)
            {
                if (DirectionState[i] == 1)
                {
                    if (randomDirection == count)
                    {
                        directionChosen = i;
                        print("direction Chosen: " + directionChosen);
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }

            }
            changeCurrentCoordinate();
        }
        else
        {
            print("no options :)");
            spawn_walls();
        }
    }

    public void changeCurrentCoordinate()
    {
        print("changing from: " + currentTile);
        if (directionChosen == NORTH)
        {
            tileIdentifier[currentTile.x, currentTile.y] += UP;
            currentTile = new Vector2Int(currentTile.x, currentTile.y + 1);
            tileIdentifier[currentTile.x, currentTile.y] += DOWN;
        }
        else if (directionChosen == SOUTH)
        {
            tileIdentifier[currentTile.x, currentTile.y] += DOWN;
            currentTile = new Vector2Int(currentTile.x, currentTile.y - 1);
            tileIdentifier[currentTile.x, currentTile.y] += UP;
        }
        else if (directionChosen == WEST)
        {
            tileIdentifier[currentTile.x, currentTile.y] += LEFT;
            currentTile = new Vector2Int(currentTile.x - 1, currentTile.y);
            tileIdentifier[currentTile.x, currentTile.y] += RIGHT;
        }
        else if (directionChosen == EAST)
        {
            tileIdentifier[currentTile.x, currentTile.y] += RIGHT;
            currentTile = new Vector2Int(currentTile.x + 1, currentTile.y);
            tileIdentifier[currentTile.x, currentTile.y] += LEFT;
        }
        print("reset, now at: " + currentTile);
        //tileIdentifier[currentTile.x, currentTile.y] += 1;
        algorithm();
    }
}
