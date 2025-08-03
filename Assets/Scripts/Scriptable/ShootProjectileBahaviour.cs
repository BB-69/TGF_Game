using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Behaviors/Shoot Projectile")]
public class ShootProjectileBehavior : ScriptableObject, IWeaponBehavior
{
    public GameObject projectilePrefab;
    public float shootOffset = 1.0f;
    public float shakeMagnitude = 0.0f;

    [Header("Properties")]
    public float speed = 10f;

    public virtual void Use(GameObject owner)
    {
        CameraFollowPlayer.Instance.Shake(shakeMagnitude);
        
        Transform firePoint = owner.transform.Find("FirePoint");
        if (firePoint != null && projectilePrefab != null)
        {
            GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            proj.GetComponent<Rigidbody2D>().linearVelocity = firePoint.right * speed;
        }
    }
}
