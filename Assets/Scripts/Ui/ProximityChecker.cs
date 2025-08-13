using UnityEngine;

public class ProximityChecker : MonoBehaviour
{
    public Transform target;
    public float Distance = 3f;
    

    private void Update()
    {
        if(target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= Distance)
        {
            TooltipControl.Instance.ShowTooltip("press c to fill water");
        }
        else
        {
            TooltipControl.Instance.HideTooltip();
        }
    }
}
