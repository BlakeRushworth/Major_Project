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