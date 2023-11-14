//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDetect : MonoBehaviour
{
    public Image EnemyHealth;
    private bool detect = false;
    public float Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider soilder)
    {

        if (soilder.CompareTag("skill"))
        {
            Debug.Log("check");
            detect = true;
        }

    }
    public void OnTriggerStay(Collider soilder)
    {

        if (soilder.CompareTag("skill") && detect)
        {
            Debug.Log("keeping");
            EnemyHealth.rectTransform.sizeDelta = new Vector2(EnemyHealth.rectTransform.sizeDelta.x - Damage * Time.deltaTime, EnemyHealth.rectTransform.sizeDelta.y);
        }

    }
    public void OnTriggerExit(Collider soilder)
    {
        if (soilder.CompareTag("skill"))

        {
            detect = false;
            Debug.Log("stop");
        }
    }

}
