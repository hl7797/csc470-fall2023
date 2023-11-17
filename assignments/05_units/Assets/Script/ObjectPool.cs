//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Transform GameObject;
    public GameObject points;
    public int MaxCount=5;
    public List<GameObject> list = new List<GameObject>();
    

    public void Push(GameObject obj)
    {
        if(list.Count < MaxCount)
        {
            list.Add(obj);
        }
        else
        {
            Destroy(obj);
        }
    }

    public GameObject Pop()
    {
      Vector3 pos = new Vector3(Random.Range(-5,5),1.6f,Random.Range(-5,5));
        Quaternion targetRotation = GameObject.rotation;
        Vector3 pos2 = GameObject.position;
        if (list.Count > 0)
        {
            GameObject obj = list[0];
            list.RemoveAt(0);
            return obj;
        }
        return Instantiate(points, pos2+targetRotation *new Vector3(0, 0, -2), Quaternion.identity);
       
       
       
    }

    public void Clear(){
        list.Clear();
    }
    
}
