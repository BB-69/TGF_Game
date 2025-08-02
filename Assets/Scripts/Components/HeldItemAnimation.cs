using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeldItemAnimation : MonoBehaviour, IAnimatable
{
    public AnimatorControllerDataBank controllerBank;
    private Animator animator;
    private SpriteRenderer spr;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        RotateSprite();
    }

    private void RotateSprite()
    {
        transform.rotation = transform.parent.Find("FirePoint").rotation;
        float zRot = transform.eulerAngles.z;
        spr.flipY = zRot > 90f && zRot < 270f;
    }

    public void SetSpriteAnimation(string sprAniName) => animator.runtimeAnimatorController = controllerBank.GetController(sprAniName);
    public void Stop() => animator.enabled = false;
    public void Resume() => animator.enabled = true;
    public void SetSpeed(float speed) => animator.speed = speed;
}
