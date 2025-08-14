using UnityEngine;
using UnityEngine.UI;
public class Minimap : MonoBehaviour
{
    public RectTransform mapImage;    
    public Transform player;          
    public Vector2 worldSize;         

    void Update()
    {

        Vector2 normalizedPos = new Vector2(player.position.x / worldSize.x, player.position.y / worldSize.y);

        float mapX = -(normalizedPos.x - 0.5f) * mapImage.rect.width;
        float mapY = -(normalizedPos.y - 0.5f) * mapImage.rect.height;

        mapImage.localPosition = new Vector3(mapX, mapY, 0);

        mapImage.localRotation = Quaternion.Euler(0, 0, -player.eulerAngles.z);
    }
}
