using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
//using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;



public class CellScript : MonoBehaviour
{
  //public GameObject cellPrefab;

    public float y = 1.5f;
   
    public int state; //1-life  0-die
    public int count;



    private bool isClicked = false;

    GameOfLife gol;
    Renderer rend;
    public Vector3 high;

    public Color aliveColor;
    public Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        GameObject golObj = GameObject.Find("GameOfLifeObj");
        gol = golObj.GetComponent<GameOfLife>();
        rend =gameObject.GetComponentInChildren<Renderer>();
        originalColor = rend.material.color;
        UpdateColor();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateColor();
        //Changehigh();
       
    }

    public void ChangeState()
    {
        if (state == 0)
        {
            state = 1;
        }
        else
        {
            state = 0;
        }
    }
    public void UpdateColor()
    {
        if (state==1)
        {
            rend.material.color = new Color(Random.value,Random.value,Random.value);
        }
        else
        {
            rend.material.color = originalColor;
        }
    }
//public void  Changehigh(){
   // if (state ==1){
    //    transform.localScale = new Vector3(1,y,1);
   // }
//}

   private void OnMouseDown()
   {
        isClicked = !isClicked;

          ChangeState();
           UpdateColor();

        }




}