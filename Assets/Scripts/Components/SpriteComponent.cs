using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteComponent : MonoBehaviour
{
    public Sprite[] frames;
    public float frameRate = 0.1f;
    public bool loop = true;

    private SpriteRenderer spriteRenderer;
    private int currentFrame;
    private float timer;
    private bool isPlaying = true;

    private const string framePath = "Visual/Sprites/Frames/";

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!isPlaying || frames.Length == 0) return;

        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer -= frameRate;
            currentFrame++;
            if (currentFrame >= frames.Length)
            {
                if (loop)
                    currentFrame = 0;
                else
                {
                    currentFrame = frames.Length - 1;
                    isPlaying = false;
                }
            }
            spriteRenderer.sprite = frames[currentFrame];
        }
    }

    public void Play()
    {
        isPlaying = true;
        currentFrame = 0;
        timer = 0;
    }

    public void Stop()
    {
        isPlaying = false;
    }

    public void SetFrames(Sprite[] newFrames, bool playing = true)
    {
        if (newFrames == null) return;

        frames = newFrames;
        currentFrame = 0;
        timer = 0;
        if (playing) Play(); else Stop();
    }

    public Sprite[] GetFrames(string innerPath)
    {
        Sprite[] newFrames = Resources.LoadAll<Sprite>(framePath + innerPath);
        return newFrames;
    }
}
