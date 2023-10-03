using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;



    private float clock;
    public float frequency;
    private bool runOr;

    public int amountX;
    public int amountY;
    // Create a 2D array of CellScripts
    [HideInInspector]
    //public CellScript[,] cells;
    public GameObject[,] cells;
float y=1.5f;



    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);

        cells = new GameObject[amountX,amountY];



        for (int x = 0; x < amountX; x++)
        {
            for (int y = 0; y < amountY; y++)
            {

                cells[x, y] = Instantiate(Resources.Load("Cell")) as GameObject;
                cells[x,y].name = "Cell"+x.ToString() + y.ToString();

                // Create a position based on x, y
                Vector3 pos = transform.position;
                float cellWidth = 1f;
                float spacing = 0.1f;
                pos.x = pos.x + x * (cellWidth + spacing);
                pos.z = pos.z + y * (cellWidth + spacing);
                cells[x,y] = Instantiate(cellPrefab, pos, transform.rotation);
                // (x,y) is the index in the 2D array. Store a reference to the
                // CellScript of the instantiated object because that is the
                // object that contains the information we will be intereated in
                // (the 'alive' variable.
                //cells[x, y] = cellObj.GetComponent<CellScript>();


            }
        }
    }
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Return)){
           runOr = true;
           
        }
    
        
        

        if (Input.GetKeyDown(KeyCode.Space)){
        runOr = false;
        }

 if (Input.GetKeyDown(KeyCode.C)){
        runOr = false;
        for(int i = 0;i< amountX; i++)
        {
            for(int j = 0;j < amountY; j++)
            {
                cells[i, j].GetComponent<CellScript>().state = 0;
                 cells[i, j].GetComponent<CellScript>().transform.localScale = new Vector3 (1,1,1);
            }
        }
         }
       if (runOr)
        {
            if (clock < frequency)
            {
                clock += Time.deltaTime;
            }
            else
            {
                clock = 0;
                RunGame();
            }
        }
    }

   




    private void RunGame()
    {
        for (int i = 0; i < amountX; i++)
        {
            for (int j = 0; j < amountY; j++)
            {
                cells[i, j].GetComponent<CellScript>().count = CountNeighbors(i, j);
            }
        }

        for (int i = 0; i < amountX; i++)
        {
            for (int j = 0; j < amountY; j++)
            {
                if (cells[i, j].GetComponent<CellScript>().count == 3)
                {
                    if (cells[i, j].GetComponent<CellScript>().state == 0)
                    {
                        cells[i, j].GetComponent<CellScript>().state = 1;
                    }
                }

                else if (cells[i, j].GetComponent<CellScript>().count == 2)
                {

                }
                else
                {
                    if (cells[i, j].GetComponent<CellScript>().state >0)
                    {
                        cells[i, j].GetComponent<CellScript>().state = 0;
                    }
                }
            }
        }
    }



    private int CountNeighbors(int x, int y) // Check the number of neighbors
    {
        int count = 0;

        if (x > 0)
        {
            if (y > 0)
            {
                if (cells[x - 1, y - 1].GetComponent<CellScript>().state > 0)
                {
                    count++;
                }
            }
            if(cells[x - 1, y ].GetComponent<CellScript>().state > 0)
            {
                count++;
            }
            if (y < amountY - 1)
            {
                   if (cells[x - 1, y +1].GetComponent<CellScript>().state > 0)
                {
                    count++;
                }
            }
        }
        if (x < amountX - 1)
        {
            if (y > 0)
            {
                if (cells[x + 1, y - 1].GetComponent<CellScript>().state > 0)
                {
                    count++;
                }
            }
            if (cells[x + 1, y ].GetComponent<CellScript>().state > 0)
            {
                count++;
            }
            if (y < amountY - 1)
            {
                if (cells[x + 1, y + 1].GetComponent<CellScript>().state > 0)
                {
                    count++;
                }
            }

         }
        if (y > 0)
        {
            if (cells[x , y -1].GetComponent<CellScript>().state > 0)
            {
                count++;
            }

        }
        if (y < amountY - 1)
        {
            if(cells[x , y + 1].GetComponent<CellScript>().state > 0){
                count++;
            }
        }


        return count;
         //Debug.Log(count);
    }












}