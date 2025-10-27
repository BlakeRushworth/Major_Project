using UnityEngine;
using UnityEngine.SceneManagement;

public class skill_tree : MonoBehaviour
{
    public GameObject[] skill_tree_icons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetLines();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLines()
    {
        skill_tree_icons[0].GetComponent<LineRenderer>().SetPosition(0, skill_tree_icons[1].transform.position);
        skill_tree_icons[0].GetComponent<LineRenderer>().SetPosition(1, skill_tree_icons[0].transform.position);
        skill_tree_icons[0].GetComponent<LineRenderer>().SetPosition(2, skill_tree_icons[4].transform.position);
        skill_tree_icons[0].GetComponent<LineRenderer>().SetPosition(3, skill_tree_icons[0].transform.position);
        skill_tree_icons[0].GetComponent<LineRenderer>().SetPosition(4, skill_tree_icons[2].transform.position);

        skill_tree_icons[1].GetComponent<LineRenderer>().SetPosition(0, skill_tree_icons[1].transform.position);
        skill_tree_icons[1].GetComponent<LineRenderer>().SetPosition(1, skill_tree_icons[3].transform.position);

        skill_tree_icons[2].GetComponent<LineRenderer>().SetPosition(0, skill_tree_icons[2].transform.position);
        skill_tree_icons[2].GetComponent<LineRenderer>().SetPosition(1, skill_tree_icons[5].transform.position);

        skill_tree_icons[3].GetComponent<LineRenderer>().SetPosition(0, skill_tree_icons[10].transform.position);
        skill_tree_icons[3].GetComponent<LineRenderer>().SetPosition(1, skill_tree_icons[3].transform.position);
        skill_tree_icons[3].GetComponent<LineRenderer>().SetPosition(2, skill_tree_icons[6].transform.position);

        skill_tree_icons[4].GetComponent<LineRenderer>().SetPosition(0, skill_tree_icons[8].transform.position);
        skill_tree_icons[4].GetComponent<LineRenderer>().SetPosition(1, skill_tree_icons[4].transform.position);
        skill_tree_icons[4].GetComponent<LineRenderer>().SetPosition(2, skill_tree_icons[9].transform.position);

        skill_tree_icons[5].GetComponent<LineRenderer>().SetPosition(0, skill_tree_icons[11].transform.position);
        skill_tree_icons[5].GetComponent<LineRenderer>().SetPosition(1, skill_tree_icons[5].transform.position);
        skill_tree_icons[5].GetComponent<LineRenderer>().SetPosition(2, skill_tree_icons[7].transform.position);

        skill_tree_icons[8].GetComponent<LineRenderer>().SetPosition(0, skill_tree_icons[8].transform.position);
        skill_tree_icons[8].GetComponent<LineRenderer>().SetPosition(1, skill_tree_icons[12].transform.position);

        skill_tree_icons[9].GetComponent<LineRenderer>().SetPosition(0, skill_tree_icons[9].transform.position);
        skill_tree_icons[9].GetComponent<LineRenderer>().SetPosition(1, skill_tree_icons[12].transform.position);
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(0);
    }
}
