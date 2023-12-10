
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
       
    }

    void InitializeEnemy()
    {
        enemyData.currentHealth = enemyData.maxHealth;
    }

    void Update()
    {
        
           
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
      
       
    }
    
}

