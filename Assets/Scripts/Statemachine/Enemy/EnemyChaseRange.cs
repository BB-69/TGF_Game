using System;
using UnityEngine;

public class EnemyChaseRange : MonoBehaviour
{
    Enemy enemy;
    void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
            enemy.SetChaseRange(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            enemy.SetChaseRange(false);
    }
}