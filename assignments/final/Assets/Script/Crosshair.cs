
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Transform Cam;
    public Transform fire_pos;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        this.transform.position = fire_pos.position + fire_pos.forward*2 +Vector3.up*0.5f;
        this.transform.rotation = Cam.rotation;
    }
}
