using System;
using UnityEngine;

public class EnemyChaseRange : MonoBehaviour
{
    EnemyController enemy;
    void Awake()
    {
        enemy = GetComponentInParent<EnemyController>();
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            enemy.SetChaseRange(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            enemy.SetChaseRange(false);
    }
}