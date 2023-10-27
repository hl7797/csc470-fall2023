using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{


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
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider bullet2)
    {

        if (bullet2.CompareTag("plane"))
        {


            Destroy(gameObject);
            gc.incScore(-500);
        }
    }
}
