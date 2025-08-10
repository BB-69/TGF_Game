using System.Collections;
using UnityEngine;
using Utils;

public class Projectile : MonoBehaviour, IProjectile
{
    protected Rigidbody2D rb;
    public float lifetime = 1.5f;
    private float currentLifetime = 0.0f;
    protected int damage = 0;
    public string[] excludedTags { get; private set; }

    public void ExcludeTags(string[] tags)
    {
        excludedTags = tags;
    }

    protected virtual void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        currentLifetime = 0.0f;
    }

    void FixedUpdate()
    {
        if (!gameObject.activeInHierarchy) return;

        currentLifetime += Time.deltaTime;
        if (currentLifetime >= lifetime) StartCoroutine(Disappear());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (CustomHelper.CompareTagList(other.gameObject, excludedTags)) return;

        if (other is IDamagable)
        {
            // not necessary but to make sure it's an entity
            MonoBehaviour controllerComponent =
                (MonoBehaviour)other.GetComponent<EnemyController>() ??
                other.GetComponent<PlayerController>();
            controllerComponent.GetComponent<HealthComponent>()?.TakeDamage(damage);
        }
        StartCoroutine(Disappear());
    }

    protected virtual IEnumerator Disappear()
    {
        yield return null;
        PoolManager.Instance.Despawn(gameObject);
    }
}