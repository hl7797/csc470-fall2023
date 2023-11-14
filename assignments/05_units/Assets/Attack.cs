//using System;
//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    
    public float hirt;
    public Image EnemyHealth;
    public Image Enemyhealth;
    public float maxDistance;
    private Animator animator;
    public Animator EnemyAttack;
    public GameObject Enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        Enemyhealth.enabled = true;
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        EnemyHealth.rectTransform.sizeDelta = new Vector2(EnemyHealth.rectTransform.sizeDelta.x , EnemyHealth.rectTransform.sizeDelta.y);
        if (EnemyHealth.rectTransform.sizeDelta.x<=0){
            EnemyAttack.SetBool("Die", true);
            Enemyhealth.enabled = false;
            Invoke("Remove", 2f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("object"))
                {
                    if (Vector3.Distance(transform.position, hit.point) <= maxDistance)
                    {
                        ChangeHealth();
                        animator.SetBool("Hit", true);
                        EnemyAttack.SetBool("BeHit", true);
                        RotateTowardsTarget(hit.point);
                        // Debug.Log("hit");
                    }
                }
            }
        }
        else
        {
            animator.SetBool("Hit", false);
            EnemyAttack.SetBool("BeHit", false);
        }
    }

    void RotateTowardsTarget(Vector3 targetPosition)
    {
        Vector3 direction = new Vector3(targetPosition.x - transform.position.x, 0f, targetPosition.z - transform.position.z);
        transform.rotation = Quaternion.LookRotation(direction);
    }
    private void ChangeHealth()
    {
        //RectTransform rectTransform = EnemyHealth.GetComponent<RectTransform>();
        EnemyHealth.rectTransform.sizeDelta = new Vector2(EnemyHealth.rectTransform.sizeDelta.x - hirt, EnemyHealth.rectTransform.sizeDelta.y);

        if ( EnemyHealth.rectTransform.sizeDelta.x <= 0)
        {
           
            //Debug.Log("die");
            EnemyAttack.SetBool("Die", true);
            Enemyhealth.enabled = false;
            Invoke("Remove", 2f);

        }
    }
    private void Remove()
    {
        Enemy.SetActive(false);
    }

   



}

