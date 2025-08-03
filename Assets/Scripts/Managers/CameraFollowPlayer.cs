using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public static CameraFollowPlayer Instance;
    private Transform player;

    public float zPos = -100f;

    [Header("Camera Movement")]
    private Vector3 movePos;
    public float followSpeed = 2f;
    public float stoppingDistance = 0.01f;

    [Header("Shake Effect")]
    private Vector3 shakePos = Vector3.zero;
    public float shakeInterval = 0.03f;
    private float _shakeTimer = 0f;
    [SerializeField] private float shakeMagnitude = 0.0f;
    private float _shakeDecrease = 0.2f;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        player = GameManager.Instance?.player.transform;
        Vector3 initPos = player?.position ?? Vector2.zero;
        initPos.z = zPos;
        movePos = initPos;
    }

    void FixedUpdate()
    {
        movePos = transform.position - shakePos;
        Move();
        HandleShake();
        transform.position = movePos + shakePos;
    }

    private void Move()
    {
        player = GameManager.Instance?.player.transform;
        Vector3 targetPos = player?.position ?? movePos;
        targetPos.z = zPos;

        Vector3 toTarget = targetPos - movePos;
        float distance = toTarget.magnitude;

        if (distance > stoppingDistance)
            movePos = Vector3.Lerp(movePos, targetPos, followSpeed * Time.deltaTime);
        else movePos = targetPos;
    }

    public void Shake(float magnitude)
    {
        shakeMagnitude = Mathf.Max(magnitude, shakeMagnitude);
    }

    private void HandleShake()
    {
        if (shakeMagnitude > 0)
        {
            _shakeTimer += Time.fixedDeltaTime;
            if (_shakeTimer >= shakeInterval)
            {
                _shakeTimer %= shakeInterval;
                shakeMagnitude -= _shakeDecrease * shakeInterval;

                Vector3 shakeOffset = (shakeMagnitude > 0) ?
                    Random.insideUnitSphere * shakeMagnitude : Vector3.zero;
                shakeOffset.z = 0;
                shakePos = shakeOffset;
            }
        }
        else
        {
            _shakeTimer = 0;
            shakeMagnitude = 0;
        }
    }
}
