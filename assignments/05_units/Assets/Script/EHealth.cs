//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class EHealth : MonoBehaviour
{

    public Transform HealthPos;
    public Transform Cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showHealth();
    }
    private void showHealth()
    {
        this.transform.position = HealthPos.position + Vector3.up * 3.5f;
        this.transform.rotation = Cam.rotation;
    }
}
