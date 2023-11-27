using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public int health= 100;
   
    public TMP_Text healthVal;
    
    public Transform target;
   
    public bool res;

   
    public GameObject enemyPrefab;
    public int numberOfEnemies = 15;
    public TMP_Text NumOfEnemy;
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
       
        SpawnEnemies();
     

    }

  
    // Update is called once per frame
    void Update()
    {
       
        healthVal.text = health.ToString();
       

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
  
    }



