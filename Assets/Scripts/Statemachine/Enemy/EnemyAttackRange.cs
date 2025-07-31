using System;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    Enemy enemy;
    void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
            enemy.SetAttackRange(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            enemy.SetAttackRange(false);
    }
}