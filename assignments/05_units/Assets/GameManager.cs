//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Gold = 0;
    public Image healthF;
    public Image HealthB;
    public float damage;
    public bool FunState = true;
    public int people = 0;

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


    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealthChanging(){
        RectTransform HealthDamage = healthF.GetComponent<RectTransform>();
        HealthDamage.sizeDelta = new Vector2(HealthDamage.sizeDelta.x - damage, HealthDamage.sizeDelta.y);

    }
}
