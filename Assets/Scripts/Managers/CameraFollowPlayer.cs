using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform player;

    public float zPos = -100f;
    public float followSpeed = 1f;
    public float stoppingDistance = 0.1f;

    void Awake()
    {
        player = GameManager.Instance?.player.transform;
        Vector3 initPos = player?.position ?? Vector2.zero;
        initPos.z = zPos;
        transform.position = initPos;
    }

    void FixedUpdate()
    {
        player = GameManager.Instance?.player.transform;
        Vector3 targetPos = player?.position ?? transform.position;
        targetPos.z = zPos;

        Vector3 toTarget = targetPos - transform.position;
        float distance = toTarget.magnitude;

        if (distance > stoppingDistance)
            transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        else transform.position = targetPos;
    }
}
