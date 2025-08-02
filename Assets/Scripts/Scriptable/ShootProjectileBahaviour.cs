using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Behaviors/Shoot Projectile")]
public class ShootProjectileBehavior : ScriptableObject, IWeaponBehavior
{
    public GameObject projectilePrefab;
    public float shootOffset = 1.0f;
    public float speed = 10f;

    public virtual void Use(GameObject owner)
    {
        Transform firePoint = owner.transform.Find("FirePoint");
        if (firePoint != null && projectilePrefab != null)
        {
            GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            proj.GetComponent<Rigidbody2D>().linearVelocity = firePoint.right * speed;
        }
    }
}
