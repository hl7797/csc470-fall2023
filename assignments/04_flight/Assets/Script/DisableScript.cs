//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class DisableScript : MonoBehaviour
{
    //public MonoBehaviour rockets; 
    //public MonoBehaviour otherplanes;
    
   // public MonoBehaviour bulletshoot; 
   // public MonoBehaviour bullet2;
    public MonoBehaviour controller;
    public MonoBehaviour collision;
    // Start is called before the first frame update
    void Start()
    {
         collision =GetComponent<Collision>();
        controller = GetComponent<GameController>();
      //  rockets = GetComponent<rockets>();
       // otherplanes = GetComponent<otherplanes>();
      //  bulletshoot = GetComponent<bulletshoot>();
      //  bullet2 = GetComponent<bullet2>();

        if (controller != null) controller.enabled = false;
       if (collision != null) collision.enabled = false;
      //  if (rockets != null) rockets.enabled = false;
      //  if (otherplanes != null) otherplanes.enabled = false;
       // if (bulletshoot != null) bulletshoot.enabled = false;
      //  if (bullet2 != null) bullet2.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
