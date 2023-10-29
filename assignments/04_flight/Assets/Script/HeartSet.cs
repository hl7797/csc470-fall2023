//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class HeartSet : MonoBehaviour
{
    PlatController pc;

    public float rotationSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gmObj = GameObject.Find("GameSetting");
        pc = gmObj.GetComponent<PlatController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
  
    public void OnTriggerEnter(Collider heart)
    {
        if (heart.CompareTag("people"))
        {
           // Debug.Log(1);
            pc.PH.value = pc. PH.value + 0.005f;
            Destroy(gameObject);

        }
    }
}
