using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnGravity : MonoBehaviour
{
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HEllo");
        //rigidbody.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {rigidbody.useGravity = true;
        }
    }
    }

