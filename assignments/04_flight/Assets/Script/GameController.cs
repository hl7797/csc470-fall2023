


//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
//using static UnityEditor.PlayerSettings;
using TMPro;



public class GameController : MonoBehaviour
{


  
   private Transform model;
    public Slider gas;
    public Transform fire;
    public GameObject BullObj;
    public GameObject PlaneObj;
    public GameObject bullet;
    public GameObject OthPlanes;
    public GameObject rocket;
   
   
    public int score;
    public int num = 0;

    public TMP_Text numText;
    public TMP_Text scoreText;
    public TMP_Text instructions;

    private Rigidbody rb;
    private float moveSpeed = 0;
    private float getAxisAD;
    private float getAxisWS;
    private float xRotation;
    private int rSpeed = 3;
    private int maxHAngle = 70;
    private int maxVAngle = 30;
   
    private float ro;
   

    public bool runOr;

    public float gentime;
    public float gentimeB;
    public float gentimeC;
  

    private float timeSinceLastSpawn = 0f;
    private float timebull = 0f;
    private float genTime = 0f;
   
    void Start()
    {

        scoreText.text = "Bullet: " +score;
        instructions.text = "Press 'Tab' show instruction";
        numText.text = "Score: " + 0;
        
        if (runOr == true)

        {
            GameObject Planes = Instantiate(PlaneObj, transform.position, Quaternion.identity);
            Planes.transform.parent = transform;

            model = transform.Find("Plane(Clone)");
            rb = this.GetComponent<Rigidbody>();
    }

    

    }
  



    void Update()

    {
      
        if (runOr == true){
            gas.value -= 0.00005f;
            Ctrl();
            if (Input.GetKey(KeyCode.Tab))
            {
                //instructions.enabled = true;
                instructions.text = "Move:'A','W','S','D'\n Press Space add speed \n click shoot bullets \n Pick up items add gas and bullets";          
            }
            else if (Input.GetKeyUp(KeyCode.Tab)) 
            {
               
                instructions.text = "Press 'Tab' show instruction";
            }
           
        }
        else
        {
            if (Input.GetKey(KeyCode.Return))
            {
                runOr = true;
                
                SceneManager.LoadScene("platform");
                GameObject Plane = Instantiate(PlaneObj, transform.position, Quaternion.identity);
                Plane.transform.parent = transform;

            }
        }

    }
    public void incScore(int howMuch)
    {
        score -= howMuch;
        scoreText.text = "Bullet: " + score;

    }
    public void attack(int number)
    {
        num += number;
        numText.text = "Score: " + num;
    }



    private void Ctrl()
    {
        
        genBullet();
        
        Move();
        AddSpeed();
        MoveCtr();
        Turn();
        RiseOrDown();
        xTurn();
        roc();
        GenOthPlane();
       
        bull();
       
    }

    private void Move()
    {
      
        if (gas.value == 0)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 10, Time.deltaTime * 0);
            Vector3 PlaneDrop = transform.forward * moveSpeed;
            
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 80, Time.deltaTime * 2);
            rb.velocity = transform.forward * moveSpeed;
        }
       
    }
    private void AddSpeed()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 120, Time.deltaTime * 2);

            gas.value -= 0.0002f;
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, Time.deltaTime * 2);
        }
    }

    private void MoveCtr()
    {
        getAxisAD = Mathf.Lerp(getAxisAD, Input.GetAxis("Horizontal"), Time.deltaTime * 50);
        getAxisWS = Mathf.Lerp(getAxisWS, Input.GetAxis("Vertical"), Time.deltaTime * 2);
    }

    private void Turn()
    {
        ro += Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.Euler(new Vector3(-xRotation, ro*0.2f, 0));

    }

    private void RiseOrDown()
    {
        xRotation = Mathf.Lerp(xRotation, 30 * Input.GetAxis("Vertical"), Time.deltaTime*rSpeed);
    }
    private void xTurn()
    {
        model.localEulerAngles = new Vector3(-getAxisWS*maxVAngle, model.localEulerAngles.y, -getAxisAD*maxHAngle);
    }



    void roc()
    {
        float x = Random.Range(10, 950);
        float y = Random.Range(15, 50); ;
        float z = Random.Range(10, 950);
        Vector3 pos = new Vector3(x, y, z);
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= gentime)
        {
            GameObject Obj = Instantiate(rocket, pos, transform.rotation);
            Destroy(Obj, 10f);
            timeSinceLastSpawn = 0f;



        }
    }

    void bull()
    {
        float x = Random.Range(10, 950);
        float y = Random.Range(15, 50); ;
        float z = Random.Range(10, 950);
        Vector3 pos = new Vector3(x, y, z);
        timebull += Time.deltaTime;

        if (timebull >= gentimeB)
        {
            GameObject bullObj = Instantiate(BullObj, pos, transform.rotation);
            Destroy(bullObj, 10f);
            timebull = 0f;



        }
    }

    void GenOthPlane()
    {
        float x = Random.Range(10, 950);
        float y = Random.Range(15, 50); ;
        float z = Random.Range(10, 950);
        Vector3 pos = new Vector3(x, y, z);
        genTime += Time.deltaTime;

        if (genTime >= gentimeC)
        {
            GameObject OthPlaneOj = Instantiate(OthPlanes, pos, transform.rotation);
           
            genTime = 0f;



        }
    }


   
    void genBullet()

    {
        if (score > 0)
        {
            if (Input.GetMouseButton(0))
            {

                incScore(1);
                gas.value -= 0.00005f;
                float x = transform.position.x;
                float y = transform.position.y;
                float z = transform.position.z;
                Vector3 pos1 = new Vector3(x, y, z);
                GameObject bulletObj = Instantiate(bullet, pos1 * 1, transform.rotation);

                bulletObj.transform.Rotate(new Vector3(90, 0, 0));
                Rigidbody bo = bulletObj.GetComponent<Rigidbody>();
                bo.velocity = transform.forward * 500;

            }
        }
    }


    
    }









