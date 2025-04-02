using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;

    public void SetColor()
    {
        playerInfo.SetColor(GetComponent<Image>().color);
    }
}
