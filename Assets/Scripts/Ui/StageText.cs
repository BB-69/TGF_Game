using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageText : MonoBehaviour
{
    public Text stageText;
    void Start()
    {
        int stageNumber = SceneManager.GetActiveScene().buildIndex ;
        stageText.text = "Stage " +  stageNumber.ToString();
    }

}
