//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
  
    public Image Enemyhea;
    private List<GameObject> list = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("GetObj", 0f, 2f)
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)&& GameManager.Instance.people<=3)
        {
            GetObj();
            GameManager.Instance.people ++;
            Debug.Log(GameManager.Instance.people);

       }
        if ((Input.GetKeyDown(KeyCode.V)))
        {
            ReturnObj();
            GameManager.Instance.people --;
            Debug.Log(GameManager.Instance.people);
            if (GameManager.Instance.people <= 0)
            {
                GameManager.Instance.people = 0;
            }
        }


    }
    
    private void GetObj()
    {
        GameObject obj = GetComponent<ObjectPool>().Pop();
        list.Add(obj);
        obj.SetActive(true);
        
    }

    private void ReturnObj()
    {
        if (list.Count > 0) {
            GetComponent<ObjectPool>().Push(list[0]);
        list[0].SetActive(false);
        list.RemoveAt(0);    
         }
     }
}
