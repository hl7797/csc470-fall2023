using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CamMove : MonoBehaviour
{
   
   
    public GameObject cameraObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CamCtr();
      
    }
    void CamCtr()
    {
        Vector3 newCamPos = transform.position + -transform.forward * 10 + Vector3.up * 5;
        cameraObject.transform.position = newCamPos;
        cameraObject.transform.LookAt(transform);
    }
}
    
    // 使摄像机看向目标
    //transform.LookAt(target);
    

