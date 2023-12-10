using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using UnityEngine.AI;
//using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public int health= 100;
   
    public TMP_Text healthVal;
    public TMP_Text missionGuide;
    public Transform target;
   
    public bool res;

    public GameObject U;
    public Image I;
    public Image progress;
    public GameObject enemyPrefab;
    public int numberOfEnemies = 15;
    public bool finish = false;
    public float moveDistance = 0.2f;
    private float distanceMoved = 0.0f;
    public float speed = 0.5f;

    public bool getKey = false;
    public SFader sceneFader;
    public GameObject keys;
    public bool endGame = false;

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
       
        
        I.enabled = false;
        progress.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        healthVal.text= health.ToString();
        missionGuide.text = "Find Computer\nGet Hard Disk";
        SpawnEnemies();
    

    }

  
    // Update is called once per frame
    void Update()
    {
       
        healthVal.text = health.ToString();
      Done();
       

    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemyObject = Instantiate(enemyPrefab, RandomPosition(), Quaternion.identity);          
            Enemy enemyScript = enemyObject.AddComponent<Enemy>();
           
        }
    }

    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-25f, 55f), 0f, Random.Range(-25f, 55f));
    }
   public void Done()
    {
        if (finish == true)
        {
            keys.SetActive(true);
            U.transform.Translate(Vector3.up * speed * Time.deltaTime);
            distanceMoved += speed * Time.deltaTime;

            
            if (distanceMoved >= moveDistance)
            {
                speed = 0;
                if(Input.GetKey(KeyCode.E))
                {
                    U.SetActive(false);
                }


            }

        }
        
        
    }
    
    
        }



