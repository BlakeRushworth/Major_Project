using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class minimap_manager : MonoBehaviour
{
    public GameObject minimapIcon;
    //public Image minimapIcon;
    public Sprite unvisitedSprite;
    public Sprite[] testSprite;

    public GameObject Landmark;
    public Sprite[] landmarkSprites;

    private int xSize = 0;
    private int ySize = 0;
    private bool spawnOnce = false;

    public int spacing = 50;
    public Vector2 placement;

    public Vector2 BottomCornerMazeReference;
    public float mazeTileSize = 32f;

    //private float minDistance;
    private GameObject CorrectTileObject;
    private GameObject CorrectObelisk;

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
        mapIconsReveal();
        //LandmarkIconsUpdate();
        portalUpdate();
    }

    public void spawnMiniMap()
    {
        xSize = (int)mapSize.x;
        ySize = (int)mapSize.y;
        //Debug.Log("mapsize: " + xSize + " " + ySize);


        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                Vector2 spawnpos = new Vector2(x * spacing, y * spacing);
                GameObject test = Instantiate(minimapIcon, transform);
                test.transform.position = placement - spawnpos;
                GameObject landmarks = Instantiate(Landmark, transform);
                landmarks.transform.position = placement - spawnpos - new Vector2(spacing / 2, spacing / 2);
            }
        }
    }
    public void portalUpdate()
    {
        GameObject[] portals = GameObject.FindGameObjectsWithTag("portal");
        GameObject[] landmarkIcons = GameObject.FindGameObjectsWithTag("Landmark icon");
        if (portals.Length > 0)
        {
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    foreach (GameObject portal in portals)
                    {
                        if (portal.transform.position.x > BottomCornerMazeReference.x + x * mazeTileSize && portal.transform.position.y > BottomCornerMazeReference.y + y * mazeTileSize)
                        {
                            if (portal.transform.position.x < BottomCornerMazeReference.x + (x + 1) * mazeTileSize && portal.transform.position.y < BottomCornerMazeReference.y + (y + 1) * mazeTileSize)
                            {
                                //obelisk on tile
                                int ConvertCoordtoNum = (xSize - (x + 1)) * ySize + (ySize - (y + 1));
                                CorrectObelisk = portal;
                                landmarkIcons[ConvertCoordtoNum].GetComponent<Image>().sprite = landmarkSprites[2];
                                landmarkIcons[ConvertCoordtoNum].GetComponent<Image>().color = Color.white;
                            }
                        }
                        
                    }
                }
            }
        }
    }

    /*
    public void LandmarkIconsUpdate()
    {
        GameObject[] landmarkIcons = GameObject.FindGameObjectsWithTag("Landmark icon");
        GameObject[] obelisks = GameObject.FindGameObjectsWithTag("Obelisk");
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                foreach (GameObject obelisk in obelisks)
                {
                    if (obelisk.transform.position.x > BottomCornerMazeReference.x + x * mazeTileSize && obelisk.transform.position.y > BottomCornerMazeReference.y + y * mazeTileSize)
                    {
                        if (obelisk.transform.position.x < BottomCornerMazeReference.x + (x + 1) * mazeTileSize && obelisk.transform.position.y < BottomCornerMazeReference.y + (y + 1) * mazeTileSize)
                        {
                            //obelisk on tile
                            int ConvertCoordtoNum = (xSize - (x + 1)) * ySize + (ySize - (y + 1));
                            CorrectObelisk = obelisk;
                            landmarkIcons[ConvertCoordtoNum].GetComponent<Image>().sprite = landmarkSprites[2];
                            landmarkIcons[ConvertCoordtoNum].GetComponent<Image>().color = Color.white;
                        }
                    }
                }
            }
        }
    }
    */
    public void mapIconsReveal()
    {
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
                        //Debug.Log("at tile: (" + x + ", " + y + ") chose: " + ConvertCoordtoNum);
                        if (mapIcons[ConvertCoordtoNum].GetComponent<Image>().sprite == unvisitedSprite)
                        {
                            //Debug.Log("new tile found at tile: ( " + x + " , " + y + " ) from length: " + mapIcons.Length + " chose: " + ConvertCoordtoNum);
                            GameObject[] tiletypes = GameObject.FindGameObjectsWithTag("tile type");
                            //minDistance = float.PositiveInfinity;
                            foreach (GameObject tile in tiletypes)
                            {
                                //float distancetoplayer = Vector2.Distance(player.transform.position, tile.transform.position);
                                //if (distancetoplayer < minDistance)
                                //{
                                //    minDistance = distancetoplayer;
                                //    CorrectTileObject = tile;
                                //}
                                if (tile.transform.position.x > BottomCornerMazeReference.x + x * mazeTileSize && tile.transform.position.y > BottomCornerMazeReference.y + y * mazeTileSize)
                                {
                                    if (tile.transform.position.x < BottomCornerMazeReference.x + (x + 1) * mazeTileSize && tile.transform.position.y < BottomCornerMazeReference.y + (y + 1) * mazeTileSize)
                                    {
                                        CorrectTileObject = tile;
                                    }
                                }
                            }
                            //Debug.Log("min object is: " + CorrectTileObject.name);
                            mapIcons[ConvertCoordtoNum].GetComponent<Image>().sprite = testSprite[int.Parse(CorrectTileObject.name)];
                        }
                    }
                }
            }
        }
    }
}
