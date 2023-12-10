
using UnityEngine;


public class ShowRules : MonoBehaviour
{

    public GameObject Rules;
    // Start is called before the first frame update
    void Start()
    {
        Rules.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Rules.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            Rules.SetActive(false);
        }
    }
}
