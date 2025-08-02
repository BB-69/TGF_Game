using System;
using System.Collections;
using UnityEngine;

public class WaterBlobProjectile : Projectile
{
    [Header("Water Blob Settings")]
    public float fadeOutDuration = 0.4f;

    protected override void OnEnable()
    {
        base.OnEnable();

        Color col = GetComponent<SpriteRenderer>().color;
        col.a = 1;
        GetComponent<SpriteRenderer>().color = col;
    }

    protected override IEnumerator Disappear()
    {
        float fadeOutTimer = 0.0f;
        Color col = GetComponent<SpriteRenderer>().color;

        while (fadeOutTimer < fadeOutDuration)
        {
            col.a = Mathf.Lerp(1.0f, 0.0f, fadeOutTimer / fadeOutDuration);
            GetComponent<SpriteRenderer>().color = col;
            fadeOutTimer += Time.deltaTime;
            yield return null;
        }

        col.a = 0;
        GetComponent<SpriteRenderer>().color = col;

        PoolManager.Instance.Despawn(gameObject);
    }
}
