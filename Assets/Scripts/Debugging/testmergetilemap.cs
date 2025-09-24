using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapMerger : MonoBehaviour
{
    public Tilemap sourceTilemap;
    public Tilemap destinationTilemap;

    void Start()
    {
        if (sourceTilemap == null || destinationTilemap == null)
        {
            Debug.LogError("Source or Destination Tilemap not assigned!");
            return;
        }
        MergeTilemaps();
    }

    void MergeTilemaps()
    {
        // Get the bounds of the source tilemap
        BoundsInt bounds = sourceTilemap.cellBounds;

        // Iterate through each cell within the source tilemap's bounds
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                // Create a Vector3Int for the current cell position
                Vector3Int cellPosition = new Vector3Int(x, y, 0);

                // Get the tile from the source tilemap at the current position
                TileBase tile = sourceTilemap.GetTile(cellPosition);

                // If a tile exists at this position in the source, place it on the destination
                if (tile != null)
                {
                    destinationTilemap.SetTile(cellPosition, tile);
                }
            }
        }

        Debug.Log("Tilemaps merged successfully!");
    }
}

/*
    public void Hwall_Update(string connectTouch) //update all walls that are touching to side walls
    {
        if (Update_coordinate.x != 0 && connectTouch == "left") // not touching the most left side
        {
            if (Hwall_state[((int)Update_coordinate.x - 1), (int)Update_coordinate.y] > 0) //direct left check
            {
                Hwall_state[((int)Update_coordinate.x - 1), (int)Update_coordinate.y] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x - 1, (int)Update_coordinate.y);
                Hwall_Update("left");
            }
            if (Vwall_state[((int)Update_coordinate.x - 1), ((int)Update_coordinate.y + 1)] > 0) // left up check
            {
                Vwall_state[((int)Update_coordinate.x - 1), ((int)Update_coordinate.y + 1)] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x - 1, (int)Update_coordinate.y + 1);
                Vwall_Update("up");
            }
            if (Vwall_state[((int)Update_coordinate.x - 1), (int)Update_coordinate.y] > 0) // left down check
            {
                Vwall_state[((int)Update_coordinate.x - 1), (int)Update_coordinate.y] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x - 1, (int)Update_coordinate.y);
                Vwall_Update("down");
            }
        }

        if (Update_coordinate.x != map_size_x - 1 && connectTouch == "right") // not touching the most right side
        {
            if (Hwall_state[((int)Update_coordinate.x + 1), (int)Update_coordinate.y] == 1) // direct right check
            {
                Hwall_state[((int)Update_coordinate.x + 1), (int)Update_coordinate.y] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x + 1, (int)Update_coordinate.y);
                Hwall_Update("right");
            }
            if (Vwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y + 1)] == 1) // up right check
            {
                Vwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y + 1)] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x, (int)Update_coordinate.y + 1);
                Vwall_Update("up");
            }
            if (Vwall_state[(int)Update_coordinate.x, (int)Update_coordinate.y] == 1) // down right check
            {
                Vwall_state[(int)Update_coordinate.x, (int)Update_coordinate.y] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x, (int)Update_coordinate.y);
                Vwall_Update("down");
            }
        }
    }

    public void Vwall_Update(string connectTouch) //update all walls that are touching to side walls
    {
        if (Update_coordinate.y != 0 && connectTouch == "up") // not touching the most bottom side
        {
            if (Vwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y - 1)] == 1) //direct down check
            {
                Vwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y - 1)] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x, (int)Update_coordinate.y - 1);
                Vwall_Update("down");
            }
            if (Hwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y - 1)] == 1) // down left check
            {
                Hwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y - 1)] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x, (int)Update_coordinate.y - 1);
                Hwall_Update("left");
            }
            if (Hwall_state[((int)Update_coordinate.x + 1), ((int)Update_coordinate.y - 1)] == 1) // down right check
            {
                Hwall_state[((int)Update_coordinate.x + 1), ((int)Update_coordinate.y - 1)] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x + 1, (int)Update_coordinate.y - 1);
                Hwall_Update("right");
            }
        }
        if (Update_coordinate.y != map_size_y - 1 && connectTouch == "down") // not touching the most top side
        {
            if (Vwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y + 1)] > 0) // direct up check
            {
                Vwall_state[(int)Update_coordinate.x, ((int)Update_coordinate.y + 1)] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x, (int)Update_coordinate.y + 1);
                Vwall_Update("up");
            }
            if (Hwall_state[(int)Update_coordinate.x, (int)Update_coordinate.y] > 0) // up left check
            {
                Hwall_state[(int)Update_coordinate.x, (int)Update_coordinate.y] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x, (int)Update_coordinate.y);
                Hwall_Update("left");
            }
            if (Hwall_state[((int)Update_coordinate.x + 1), (int)Update_coordinate.y] > 0) // up right check
            {
                Hwall_state[((int)Update_coordinate.x + 1), (int)Update_coordinate.y] = 2;
                Update_coordinate = new Vector2((int)Update_coordinate.x + 1, (int)Update_coordinate.y);
                Hwall_Update("right");
            }
        }
    }
*/