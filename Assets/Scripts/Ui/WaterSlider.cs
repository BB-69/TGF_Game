using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaterSlider : MonoBehaviour
{
    public Image waterFillImage;
    private Coroutine animCoroutine;

    public void SetWaterPercent(float percent)
    {
        percent = Mathf.Clamp01(percent);

        if (animCoroutine != null)
            StopCoroutine(animCoroutine);

        animCoroutine = StartCoroutine(AnimateFill(waterFillImage.fillAmount, percent));
    }

    private IEnumerator AnimateFill(float from, float to)
    {
        float duration = 0.4f; 
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            waterFillImage.fillAmount = Mathf.Lerp(from, to, t);
            yield return null;
        }

        waterFillImage.fillAmount = to;

    }

}

