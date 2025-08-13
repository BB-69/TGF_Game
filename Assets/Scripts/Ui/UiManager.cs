using UnityEngine;

public class UiManager : MonoBehaviour
{
    private static UiManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
