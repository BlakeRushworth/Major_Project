using UnityEngine;

public class coin : MonoBehaviour
{
    public Sprite smallPile;
    public Sprite mediumPile;
    public Sprite bigPile;

    private int coin_value;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int rand = Random.Range(0, 3);
        if (rand == 0)
        {
            coin_value = 2;
            gameObject.GetComponent<SpriteRenderer>().sprite = smallPile;
        }
        else if (rand == 1)
        {
            coin_value = 5;
            gameObject.GetComponent<SpriteRenderer>().sprite = mediumPile;
        }
        else if (rand == 2)
        {
            coin_value = 10;
            gameObject.GetComponent<SpriteRenderer>().sprite = bigPile;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    coin_ui.coin_count += coin_value;
        //    Destroy(this.gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coin_ui.coin_count += coin_value;
            Destroy(this.gameObject);
        }
    }
}
