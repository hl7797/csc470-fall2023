using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public TMP_Text gameoverText;
    public ParticleSystem Coll;
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
       

     
    }

    public void OnTriggerEnter(Collider plane)
    {
        if (gc.runOr == true)
        {
            if (plane.CompareTag("map") || plane.CompareTag("Othplane"))
            {
                gc.runOr = false;
                gameoverText.text = "      GameOver ! \n Press 'R' to restart.";
               
             
                Transform child = gc.transform.Find("Plane(Clone)");
                float x1 = transform.position.x;
                float y1 = transform.position.y+4;
                float z1 = transform.position.z+4;
                Vector3 pos2 = new Vector3(x1, y1, z1);

               
                ParticleSystem explosion = Instantiate(Coll,pos2, Quaternion.identity);
                explosion.Play();
                Destroy(explosion, 2f);
                Destroy(child.gameObject);
               
               
            }
        }
    }

    

}
