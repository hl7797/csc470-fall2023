using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    
    public int CountEnemy = 15;
    
    void Start()
    {
        enemyData = new EnemyData();
        InitializeEnemy();
        animator = GetComponent<Animator>();
        GameManager.Instance.NumOfEnemy.text = CountEnemy.ToString();
    }

    void InitializeEnemy()
    {
        enemyData.currentHealth = enemyData.maxHealth;
    }

    void Update()
    {
       GameManager.Instance. NumOfEnemy.text = CountEnemy.ToString();
    }
    public void TakeDamage(float damage)
    {
        enemyData.currentHealth -= damage;       
        if (enemyData.currentHealth <= 0)
        {
            
            EnemyCtr enemies = GetComponent<EnemyCtr>();
            enemies.die = true;
            CountEnemy -= 1;
            animator.SetBool("die", true);
            Invoke("Die", 2f);           
        }
    }


    void Die()
    {       
        gameObject.SetActive(false);
        // GameManager.Instance.Checkdie();
        //GameManager.Instance.isDead = true;       
        //Destroy(this.gameObject);
    }
   
}

