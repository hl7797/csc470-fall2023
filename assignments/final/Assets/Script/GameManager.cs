//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public int health= 100;
    public float Ehealth = 10;
    public TMP_Text healthVal;
    public GameObject Enemy;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Why is there more than one GameManager!?!?!?!");
            Destroy(gameObject);
        }
        Instance = this;
    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        healthVal.text= health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //enemyI();
        healthVal.text = health.ToString();
        
    }

    private void enemyI()
    {

        float x = Random.Range(-25, 55);
        float z= Random.Range(-25, 55);
        Vector3 pos = new Vector3(x,0,z);
        Instantiate(Enemy, pos, Quaternion.identity);
        
    }

}



