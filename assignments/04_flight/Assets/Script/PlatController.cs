
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlatController : MonoBehaviour
{
    public Slider PH;
    private float heartTime = 0f;
    private float genTime = 0f;
    public float gentimeD;
    public float gentimeC;
    public GameObject Heart;
    public GameObject Enemy;
    public int EnemyCount;
    public TMP_Text EnemyUnm;
    public TMP_Text gameOver;

    // Start is called before the first frame update
    void Start()
    {
        EnemyUnm.text = "Enemy Numer: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyUnm.text = "Enemy Numer: " + EnemyCount;
        GenHeart();
        GenEnemy();
        GameOver();
        if (EnemyCount > 200)
        {
            PH.value -= 0.0001f;
        }

    }
    void GenHeart()
    {
        float x = Random.Range(10, 950);
        float y = 6f;
        float z = Random.Range(8, 950);
        Vector3 pos = new Vector3(x, y, z);
        heartTime += Time.deltaTime;

        if (heartTime >= gentimeD)
        {
            GameObject HeartObj = Instantiate(Heart, pos, transform.rotation);
            Destroy(HeartObj, 10f);
            heartTime = 0f;

        }
    }
    void GenEnemy()
    {

        float x = Random.Range(10, 950);
        float y = 5f;
        float z = Random.Range(10, 950);
        Vector3 pos = new Vector3(x, y, z);
        genTime += Time.deltaTime;

        if (genTime >= gentimeC)
        {
            GameObject OthPlaneOj = Instantiate(Enemy, pos, transform.rotation);
            EnemyCount += 1;

            genTime = 0f;



        }

    }

    void GameOver()
    {
        if(PH.value == 0)
        {
            gameOver.text = "      GameOver ! \n Press 'Return' to restart.";
            if(Input.GetKeyDown(KeyCode.Return)) {
                SceneManager.LoadScene("platform");
            }
        }
    }

 
}