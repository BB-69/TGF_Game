using UnityEngine;
using UnityEngine.UI;
public class Hpenemy : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public Image Hpfill;
    public Gradient Gradient;

    private void Start()
    {
        
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }
    public void UpdateHealthBar()
    {
        float fillAmount = currentHealth / maxHealth;
        Hpfill.fillAmount = fillAmount;

        Hpfill.color = Gradient.Evaluate(fillAmount);
    }
}
