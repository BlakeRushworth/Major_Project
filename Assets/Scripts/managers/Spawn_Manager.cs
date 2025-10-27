using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Obelisk;
    public Rigidbody2D player;

    public int obelisk_chance = 4;

    private bool spawnPortalOnce = false;
    void Start()
    {
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
            Debug.Log("obelisk: " + obeliskObjects.Length);
            int test_count = 0;
            foreach (GameObject obelisk in obeliskObjects)
            {
                int rand = Random.Range(0, obelisk_chance);
                Debug.Log(rand);
                if (rand == 0)
                {
                    // Do something with each portal object
                    Debug.Log("Found obrlisk spawn: " + obelisk.name);
                    Instantiate(Obelisk, obelisk.transform.position, Quaternion.identity);
                    test_count += 1;
                }
            }
            Debug.Log("spawned obelisk count: " + test_count);
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
