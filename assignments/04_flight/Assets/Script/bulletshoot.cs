using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intialpos : MonoBehaviour
{
    public ParticleSystem bulletColl;
    GameController gc;


    // public GameObject planes;
    // Start is called before the first frame update
    void Start()
    {

        GameObject gmObj = GameObject.Find("Player");
        gc = gmObj.GetComponent<GameController>();

    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider bullet)
    {
        if (gc.runOr == true)
        {
            if (bullet.CompareTag("map"))
            {
              

               


                ParticleSystem explosion = Instantiate(bulletColl, transform.position, Quaternion.identity);
                explosion.Play();
                Destroy(explosion, 2f);
                Destroy(gameObject);


            }
        }
    }

}
