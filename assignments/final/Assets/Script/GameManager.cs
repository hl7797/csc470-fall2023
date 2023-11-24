//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public int health= 100;
    public TMP_Text healthVal;
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
        healthVal.text = health.ToString();
    }

    void playerDead()
    {
        //dead
        if (health <= 0)
        {

        }
    }
}
