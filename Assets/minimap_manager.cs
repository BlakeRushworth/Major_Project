using UnityEngine;
using UnityEngine.UI;

public class minimap_manager : MonoBehaviour
{
    public GameObject minimapIcon;
    //public Image minimapIcon;
    public Sprite unvisitedSprite;
    public Sprite[] testSprite;

    private int xSize = 0;
    private int ySize = 0;
    private bool spawnOnce = false;

    public int spacing = 50;
    public Vector2 placement;

    public Vector2 BottomCornerMazeReference;
    public float mazeTileSize = 32f;

    //private float minDistance;
    private GameObject CorrectGameObject;

    Rigidbody2D player;
    Vector2 mapSize;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        mapSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HuntandKill_Algorithm>().mapSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(mapSize != Vector2.zero && !spawnOnce)
        {
            spawnOnce = true;
            spawnMiniMap();
        }

        GameObject[] mapIcons = GameObject.FindGameObjectsWithTag("icon");
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                if (player.transform.position.x > BottomCornerMazeReference.x + x * mazeTileSize && player.transform.position.y > BottomCornerMazeReference.y + y * mazeTileSize)
                {
                    if (player.transform.position.x < BottomCornerMazeReference.x + (x + 1) * mazeTileSize && player.transform.position.y < BottomCornerMazeReference.y + (y + 1) * mazeTileSize)
                    {
                        //int ConvertCoordtoNum = x * ySize + y;
                        int ConvertCoordtoNum = (xSize - (x + 1)) * ySize + (ySize - (y + 1));
                        Debug.Log("at tile: (" + x + ", " + y + ") chose: " + ConvertCoordtoNum);
                        if (mapIcons[ConvertCoordtoNum].GetComponent<Image>().sprite == unvisitedSprite)
                        {
                            Debug.Log("new tile found at tile: ( " + x + " , " + y + " ) from length: " + mapIcons.Length + " chose: " + ConvertCoordtoNum);
                            GameObject[] tiletypes = GameObject.FindGameObjectsWithTag("tile type");
                            //minDistance = float.PositiveInfinity;
                            foreach (GameObject tile in tiletypes)
                            {
                                //float distancetoplayer = Vector2.Distance(player.transform.position, tile.transform.position);
                                //if (distancetoplayer < minDistance)
                                //{
                                //    minDistance = distancetoplayer;
                                //    CorrectGameObject = tile;
                                //}
                                if (tile.transform.position.x > BottomCornerMazeReference.x + x * mazeTileSize && tile.transform.position.y > BottomCornerMazeReference.y + y * mazeTileSize)
                                {
                                    if (tile.transform.position.x < BottomCornerMazeReference.x + (x + 1) * mazeTileSize && tile.transform.position.y < BottomCornerMazeReference.y + (y + 1) * mazeTileSize)
                                    {
                                        CorrectGameObject = tile;
                                    }
                                }
                            }
                            Debug.Log("min object is: " + CorrectGameObject.name);
                            mapIcons[ConvertCoordtoNum].GetComponent<Image>().sprite = testSprite[int.Parse(CorrectGameObject.name)];
                        }
                    }
                }
            }
        }
    }

    public void spawnMiniMap()
    {
        xSize = (int)mapSize.x;
        ySize = (int)mapSize.y;
        Debug.Log("mapsize: " + xSize + " " + ySize);


        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                Vector2 spawnpos = new Vector2(x * spacing, y * spacing);
                GameObject test = Instantiate(minimapIcon, transform);
                test.transform.position = placement - spawnpos;
            }
        }
    }
}
