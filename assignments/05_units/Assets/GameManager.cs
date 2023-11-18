//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Gold = 0;
    public Image healthF;
    public Image HealthB;
    public float damage;
    public bool FunState = true;
    public int people = 0;
    public TMP_Text rules;
    public TMP_Text GameOver;
    public bool Gameover = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Why is there more than one GameManager!?!?!?!");
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        rules.text = " Press 'Tab' show rules";
    }

    // Update is called once per frame
    void Update()
    {
        showRules();
        if(Gameover == true && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    

    public void HealthChanging(){
        RectTransform HealthDamage = healthF.GetComponent<RectTransform>();
        HealthDamage.sizeDelta = new Vector2(HealthDamage.sizeDelta.x - damage, HealthDamage.sizeDelta.y);
        if(HealthDamage.sizeDelta.x <= 0)
        {
            Gameover = true;
            GameOver.text = " GameOver \n Press 'R' restart";
        }

    }
    void showRules()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            rules.text = "Right click to move. \nLeft click to attack.\nHold 'Space' and left click to use skill.\n Press 'C' to create object\n" +
                "Press 'V' to delete";
        }
        else if(Input.GetKeyUp(KeyCode.Tab))
        {
            rules.text = " Press 'Tab' show rules";
        }
    }
}
