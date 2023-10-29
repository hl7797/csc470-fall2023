
//sing System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 0;
   
    public float scoreInterval = 1.0f;
    public float rotationSpeed = 30.0f;
    
   

  

    private float timeChange = 0f;
    private Rigidbody rb;
    private Animator animator;
    Changing ci;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gmObj = GameObject.Find("Plane");
        ci = gmObj.GetComponent<Changing>();

        animator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timeChange += Time.deltaTime;
        move();
        autoRotate();
    }
    private void move()
    {

        moveSpeed = Mathf.Lerp(moveSpeed, 5, Time.deltaTime * 2);
        rb.velocity = transform.forward * moveSpeed;
    }
    private void autoRotate()
    {
        float rotationAngle = rotationSpeed * Time.deltaTime;
        if (timeChange <= 4f)
        {
            rotationSpeed = Random.Range(80f, 100f);
           
            timeChange += Time.deltaTime;
            transform.Rotate(0, rotationAngle, 0, Space.Self);


        }
        else if (timeChange > 6f && timeChange < 10f)
        {
           
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
    private void OnTriggerEnter(Collider Enemy)
    {

        if (Enemy.CompareTag("weapon") && Input.GetMouseButton(0))
        {

            animator.SetBool("Died", true);
           ci. killed += 1;
            Destroy(gameObject,2f);

        }
        else
        {
            animator.SetBool("Died", false);
        }
    }
}
