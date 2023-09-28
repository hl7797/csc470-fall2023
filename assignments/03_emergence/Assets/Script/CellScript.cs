using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;



public class CellScript : MonoBehaviour
{
  //public GameObject cellPrefab;

    public int state; //1-life  0-die
    public int count;

   

    private bool isClicked = false;

    GameOfLife gol;
    Renderer rend;

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
            rend.material.color = aliveColor;
        }
        else
        {
            rend.material.color = originalColor;
        }
    }


   private void OnMouseDown()
   {
        isClicked = !isClicked;
   
            
          ChangeState();
           UpdateColor();
          
        }



   
}