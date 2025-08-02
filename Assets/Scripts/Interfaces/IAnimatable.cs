using UnityEngine;

public interface IAnimatable
{
    public void Stop();
    public void Resume();
    public void SetSpeed(float speed);
}