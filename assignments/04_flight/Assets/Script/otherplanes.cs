
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
//using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GridBrushBase;

public class otherplanes : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 0;

    public ParticleSystem PlaneColl;
    private float lastScoreTime;
    public float scoreInterval = 1.0f;
    public float rotationSpeed = 30.0f;
    public float zrotationSpeed = 30.0f;
    public float xrotationSpeed = 5f;

    public float changeDirectionInterval = 2.0f; 
  
    private float timeChange = 0f;
    private Rigidbody rb;

    GameController gc;
   

    void Start()
    {

       
        rb = this.GetComponent<Rigidbody>();
        GameObject gmObj = GameObject.Find("Player");
        gc = gmObj.GetComponent<GameController>();
       
    }

    void Update()
    {
    timeChange += Time.deltaTime;
        move();
       autoRotate();
       
        
  

    }



    private void move()
    {

        moveSpeed = Mathf.Lerp(moveSpeed, 40, Time.deltaTime * 2);
        rb.velocity = transform.forward * moveSpeed;
    }
    private void autoRotate()
    {
        float rotationAngle = rotationSpeed * Time.deltaTime;
        if (timeChange <= 4f)
        {
            rotationSpeed = Random.Range(80f, 100f);
            zrotationSpeed = 10f;
            timeChange += Time.deltaTime;
            transform.Rotate(0, rotationAngle, 0, Space.Self);


        }
        else if (timeChange > 6f && timeChange < 10f)
        {
            zrotationSpeed = -20;
            rotationSpeed = Random.Range(80f, 100f);
            transform.Rotate(-0, -rotationAngle, -0, Space.Self);
            timeChange += Time.deltaTime;


        }
        else if (timeChange >= 10f)
        {

            timeChange = 0f;
        }
        else
        {
            transform.Rotate(0, 0, 0, Space.Self);

        }

    }
    public void OnTriggerEnter(Collider Othplane)
    {
        if (gc.runOr == true)
        {
            if (Othplane.CompareTag("map") || Othplane.CompareTag("bullet") || Othplane.CompareTag("Othplane"))
            {

                if (Othplane.CompareTag("bullet"))
                {
                    if (Time.time - lastScoreTime >= scoreInterval)
                    {
                       
                        lastScoreTime = Time.time;
                        gc.attack(1);
                    }
                  
                }

               


                    ParticleSystem explosion = Instantiate(PlaneColl, transform.position, Quaternion.identity);
                explosion.Play();
                Destroy(explosion, 2f);
                Destroy(gameObject);


            }
        }
    }

   
}

   

