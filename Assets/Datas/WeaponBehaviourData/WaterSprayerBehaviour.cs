using UnityEngine;
using Utils;

[CreateAssetMenu(menuName = "Weapon Behaviors/Spray Water")]
public class WaterSprayerBehavior : ShootProjectileBehavior
{
    [Header("Water Sprayer Settings")]
    public float velRandMulRange = 0.2f;
    public float rotationRandRange = 45.0f;
    public float sprayRate = 0.05f;
    private float sprayTimer;

    public override void Use(GameObject owner)
    {
        CameraFollowPlayer.Instance.Shake(shakeMagnitude);

        sprayTimer -= Time.deltaTime;
        if (sprayTimer > 0) return;

        sprayTimer = sprayRate;

        Transform firePoint = owner.transform.Find("FirePoint");
        if (firePoint != null && projectilePrefab != null && PoolManager.Instance != null)
        {
            GameObject blob = PoolManager.Instance.Spawn(projectilePrefab);
            blob.transform.position = firePoint.position + firePoint.right * shootOffset;

            float randDegree = Random.Range(-rotationRandRange, rotationRandRange);

            Rigidbody2D rb = blob.GetComponent<Rigidbody2D>();
            rb.linearVelocity = CustomHelper.RotateVector2ByDegree((
                firePoint.right * speed * UnityEngine.Random.Range( // default + random velocity
                Mathf.Max(1.0f - velRandMulRange, 0.0f),
                Mathf.Max(1.0f + velRandMulRange, 0.0f)
            )),
                randDegree // random rotation
            )
                + (owner.GetComponent<Rigidbody2D>()?.linearVelocity ?? Vector2.zero); // increment with character velocity

            blob.GetComponent<Projectile>().ExcludeTags(new string[] { "Projectile", owner.tag });
        }
    }
}
