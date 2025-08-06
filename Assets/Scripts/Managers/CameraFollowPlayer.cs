using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

public class CameraFollowPlayer : MonoBehaviour
{
    public static CameraFollowPlayer Instance;
    private Camera cam;
    private Transform player;
    private Rigidbody2D playerRb;

    public float zPos = -100f;

    [Header("Camera Movement")]
    private Vector3 movePos;
    public float followSpeed = 3f;
    public float stoppingDistance = 0.01f;

    [Header("Pan Effect")]
    private Vector3 panPos = Vector3.zero;
    public float panSpeed = 1f;
    public float panWeight = 0.2f;
    private bool isPanning => player != null && Input.mousePosition != null;

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

        cam = Camera.main ?? null;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance?.player != null && player == null)
        {
            player = GameManager.Instance?.player.transform;
            playerRb = player.GetComponent<Rigidbody2D>();
            transform.position = player.position;
        }

        movePos = transform.position - (shakePos + panPos);
        Move();
        HandlePan();
        HandleShake();
        transform.position = movePos + (shakePos + panPos);
    }

    private void Move()
    {
        Vector3 targetPos = player?.position ?? movePos;
        targetPos.z = zPos;

        Vector3 toTarget = targetPos - movePos;
        float distance = toTarget.magnitude;

        if (distance > stoppingDistance)
            movePos = Vector3.Lerp(movePos, targetPos, followSpeed * Time.deltaTime);
        else movePos = targetPos;
    }

    //public void SetPan(bool setPan) => isPanning = setPan;
    private void HandlePan()
    {
        Vector3 targetPos = isPanning ?
            cam.ScreenToWorldPoint(Input.mousePosition) - CustomHelper.GetCameraCenter(cam) :
            Vector3.zero;
        targetPos.z = zPos;
        
        Vector3 toTarget = targetPos - panPos;
        float distance = toTarget.magnitude;

        if (distance > stoppingDistance)
            panPos = Vector3.Lerp(
                panPos,
                panWeight * targetPos + 0.4f*(Vector3)(playerRb?.linearVelocity ?? Vector2.zero),
                panSpeed * Time.deltaTime
            );
        else panPos = panWeight * targetPos;
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
