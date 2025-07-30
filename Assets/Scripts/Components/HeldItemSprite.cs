using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HeldItemSprite : MonoBehaviour
{
    public SpriteRenderer weaponRenderer;
    public Sprite[] weaponFrames;
    public float frameRate = 0.1f;
    public bool loop = true;

    private int currentFrame;
    private float timer;
    private bool isPlaying;

    void Start()
    {
        if (weaponRenderer == null)
            weaponRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!isPlaying || weaponFrames.Length == 0) return;

        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer -= frameRate;
            currentFrame++;

            if (currentFrame >= weaponFrames.Length)
            {
                if (loop)
                    currentFrame = 0;
                else
                {
                    currentFrame = weaponFrames.Length - 1;
                    isPlaying = false;
                }
            }

            weaponRenderer.sprite = weaponFrames[currentFrame];
        }
    }

    public void SetWeaponFrames(Sprite[] frames, bool autoPlay = true)
    {
        weaponFrames = frames;
        currentFrame = 0;
        timer = 0;
        if (autoPlay) Play(); else Stop();
    }

    public void Play() => isPlaying = true;
    public void Stop() => isPlaying = false;

    public void ClearWeapon()
    {
        weaponRenderer.sprite = null;
        weaponFrames = new Sprite[0];
        Stop();
    }
}
