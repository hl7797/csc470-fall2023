using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ballPrefab;
    public Rigidbody rigi;
public Camera cam;



    private Vector3 offset;
    void Start()
    {
   rigi = GetComponent<Rigidbody>();
   offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float m_speed =0.5f;
        
       if (Input.GetKey(KeyCode.W)|Input.GetKey(KeyCode.UpArrow))
        {
            
            Vector3 movement = new Vector3(0, 0, 5); 
        rigi.AddForce(movement * m_speed);

        }
        if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
        {
           
            Vector3 movement = new Vector3(0, 0, 5); 
        rigi.AddForce(movement * -m_speed);
        }
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
        {
            
            Vector3 movement = new Vector3(5, 0, 0); 
        rigi.AddForce(movement * -m_speed);
        }
        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
        {
          
            Vector3 movement = new Vector3(5, 0, 0);
        rigi.AddForce(movement * m_speed);
        }
         if (Input.GetKey(KeyCode.Space))
        {
          
            Vector3 movement = new Vector3(0, 5, 0);
        rigi.AddForce(movement * m_speed);
        }
        cam.transform.position +=transform.position-offset;
        offset=transform.position;

        

    }
}
