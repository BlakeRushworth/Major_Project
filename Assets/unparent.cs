using UnityEngine;

public class unparent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("hello");
        //transform.parent = null;
    }

    private void Awake()
    {
        //Debug.Log("hello awake");
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
