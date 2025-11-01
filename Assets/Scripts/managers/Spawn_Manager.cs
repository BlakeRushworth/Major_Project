using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Obelisk;
    public Rigidbody2D player;
    public GameObject stall;
    public GameObject coinprefab;

    public int obelisk_chance = 4;

    private int num_of_spawningobelisks;

    private bool spawnPortalOnce = false;
    private Tilemap myTilemap;


    private Vector2 mapSize;

    private Vector2 bottomleftReference = new Vector2(-26, -49);
    void Start()
    {
        mapSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HuntandKill_Algorithm>().mapSize;
        myTilemap = GameObject.FindGameObjectWithTag("collison_tilemap").GetComponent<Tilemap>();


        spawnPortalOnce = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("player spawnpoint");
        if (playerObjects.Length > 0)
        {
            int randspawn = Random.Range(0, playerObjects.Length);
            Vector2 spawn_pos = playerObjects[randspawn].transform.position;
            player.position = spawn_pos;
        }

        GameObject[] obeliskObjects = GameObject.FindGameObjectsWithTag("obelisk spawnpoint");
        if (obeliskObjects.Length > 0)
        {
            if (DifficultyINcreases.enableEnemyTypes)
            {
                num_of_spawningobelisks = 3;
            }
            else if (DifficultyINcreases.enableBigEnemies)
            {
                num_of_spawningobelisks = 5;
            }
            else
            {
                num_of_spawningobelisks = 3;
            }
                bool[] once = new bool[obeliskObjects.Length];
            for (int i = 0; i < num_of_spawningobelisks - 1; i++)
            {
                int rand = Random.Range(0, obeliskObjects.Length);
                while (once[rand])
                {
                    rand = Random.Range(0, obeliskObjects.Length);
                }
                once[rand] = true;
                Instantiate(Obelisk, obeliskObjects[rand].transform.position, Quaternion.identity);
            }

            for (int i = 0; i < 1; i++)
            {
                int rand = Random.Range(0, obeliskObjects.Length);
                while (once[rand])
                {
                    rand = Random.Range(0, obeliskObjects.Length);
                }
                once[rand] = true;
                Instantiate(stall, obeliskObjects[rand].transform.position, Quaternion.identity);
            }
        }

        for (int c = 0; c < 2 * DifficultyINcreases.wave; c++)
        {
            int rand_x = Random.Range(0, (int)mapSize.x * 32);
            int rand_y = Random.Range(0, (int)mapSize.y * 32);
            Vector2 coordinate = new Vector2(rand_x + bottomleftReference.x, rand_y + bottomleftReference.y);
            Vector3Int cellPosition = myTilemap.WorldToCell(coordinate);
            TileBase tileAtPosition = myTilemap.GetTile(cellPosition);

            while (tileAtPosition != null)
            {
                rand_x = Random.Range(0, (int)mapSize.x * 32);
                rand_y = Random.Range(0, (int)mapSize.y * 32);
                coordinate = new Vector2(rand_x + bottomleftReference.x, rand_y + bottomleftReference.y);
                cellPosition = myTilemap.WorldToCell(coordinate);
                tileAtPosition = myTilemap.GetTile(cellPosition);
            }
            Debug.Log("can spawn coin here");
            Instantiate(coinprefab, coordinate, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        GameObject[] obeliskObjects = GameObject.FindGameObjectsWithTag("Obelisk");
        if (!spawnPortalOnce)
        {
            if (obeliskObjects.Length > 0)
            {
                for (int i = 0; i < obeliskObjects.Length; i++) 
                {
                    bool obeliskDone = obeliskObjects[i].GetComponent<Animator>().GetBool("done");
                    if (obeliskDone == true)
                    {
                        count += 1;
                    }
                }
            }
            if (count == obeliskObjects.Length)
            {
                spawnPortalOnce = true;
                spawn_portal();
            }
        }
    }
    

public void spawn_portal()
    {
        GameObject[] portalObjects = GameObject.FindGameObjectsWithTag("portal spawnpoint");
        if (portalObjects.Length > 0)
        {
            int randspawn = Random.Range(0, portalObjects.Length);
            Instantiate(Portal, portalObjects[randspawn].transform.position, Quaternion.identity);
            
        }
    }
}
