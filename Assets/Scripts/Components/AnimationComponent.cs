using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationComponent : MonoBehaviour, IAnimatable
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    //public void Play(string animationName) => animator.Play(animationName);
    public void SetDirection(string dir)
    {
        animator.SetBool("isMoving", dir != "None");
        animator.SetBool("UP", dir == "UP");
        animator.SetBool("LEFT", dir == "LEFT");
        animator.SetBool("DOWN", dir == "DOWN");
        animator.SetBool("RIGHT", dir == "RIGHT");
    }
    public void Stop() => animator.enabled = false;
    public void Resume() => animator.enabled = true;
    public void SetSpeed(float speed) => animator.speed = speed;
}
