using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBulider : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BowlingPrefab;
  
    void Start()
    {
        for(int i = 0; i<11;i++){
            generatebowling();
        }
    }
    void generatebowling(){
        float x=Random.Range(-5,5);
        float y=0.5f;
        float z=Random.Range(-5,5);
        Vector3 pos = new Vector3 (x,y,z);
        GameObject BowlingObj = Instantiate(BowlingPrefab, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
       

        }
        
    }

