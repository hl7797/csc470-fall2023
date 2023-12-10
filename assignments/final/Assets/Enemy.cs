//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [System.Serializable]
    public class EnemyData
    {
        public float maxHealth = 10;
        [HideInInspector]
        public float currentHealth;
    }

    public EnemyData enemyData;
    private Animator animator;
    
    
    
    void Start()
    {
        enemyData = new EnemyData();
        InitializeEnemy();
        animator = GetComponent<Animator>();
       // GameManager.Instance.NumOfEnemy.text = GameManager.Instance.CountEnemy.ToString();
    }

    void InitializeEnemy()
    {
        enemyData.currentHealth = enemyData.maxHealth;
    }

    void Update()
    {
        
            // GameManager.Instance.NumOfEnemy.text = GameManager.Instance.CountEnemy.ToString();
        }
    public void TakeDamage(float damage)
    {
        enemyData.currentHealth -= damage;       
        if (enemyData.currentHealth <= 0)
        {
            
            EnemyCtr enemies = GetComponent<EnemyCtr>();
            enemies.die = true;
           
            animator.SetBool("die", true);
            Invoke("Die", 2f);           
        }
       
        }


    void Die()
    {       
        gameObject.SetActive(false);
      
        
        //GameManager.Instance.isDead = true;       
        //Destroy(this.gameObject);
    }
    
}

