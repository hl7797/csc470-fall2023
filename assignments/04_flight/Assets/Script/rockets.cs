using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class rockets : MonoBehaviour
{
   // public GameObject rocketprefab ;

    public float rotationSpeed = 50f;



     GameController gc;
    // Start is called before the first frame update
    void Start()
    {

        GameObject gmObj = GameObject.Find("Player");
        gc = gmObj.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));



      
    }


    private void OnTriggerEnter(Collider rocket)
    {

        if (rocket.CompareTag("plane"))
        {
           

            Destroy(gameObject);
            gc.gas.value = gc.gas.value + 0.5f;
        }
    }





}
