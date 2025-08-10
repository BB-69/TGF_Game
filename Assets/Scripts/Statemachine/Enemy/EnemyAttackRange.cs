using System;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    EnemyController enemy;
    void Awake()
    {
        enemy = GetComponentInParent<EnemyController>();
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            enemy.SetAttackRange(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            enemy.SetAttackRange(false);
    }
}