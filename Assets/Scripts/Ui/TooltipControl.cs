using UnityEngine;
using UnityEngine.UI;

public class TooltipControl : MonoBehaviour
{
    public static TooltipControl Instance;

    [SerializeField] private GameObject tooltipUi;
    [SerializeField] private Text tooltipText;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
        
        HideTooltip();
    }

    public void ShowTooltip(string text)
    {
        tooltipUi.SetActive(true);
        tooltipText.text = text;
    }

    public void HideTooltip()
    {
        tooltipUi.SetActive(false);
    }
}
