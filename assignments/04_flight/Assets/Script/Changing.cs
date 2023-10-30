//using Mono.Reflection;
//using System.Collections;
//using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changing : MonoBehaviour
{
    public bool coll;
    public TMP_Text kill;
    public TMP_Text inst;
    public int killed;
    // Start is called before the first frame update
    void Start()
    {
        inst.text = "Press 'Tab' show instruction";
        kill.text = "Gold: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && coll == true)
        {
            SceneManager.LoadScene("samplescene");
        }
        kill.text = "Gold: " + killed; ;
        if (Input.GetKey(KeyCode.Tab))
        {
            //instructions.enabled = true;
            inst.text = "Move:'A','W','S','D'\n Press Space add speed \n click to attack enmey get golds\n Pick up items add HP \n collect 5 golds and press 'E'to take plane";
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {

            inst.text = "Press 'Tab' show instruction";
        }
    }

    public void OnTriggerEnter(Collider plane)
    {
        if (plane.CompareTag("people") && killed >= 5 )
        {
            coll = true;
        }
     
    }
}
