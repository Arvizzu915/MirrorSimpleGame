using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] public Color color { get; private set; } = UnityEngine.Color.white;

    public void SetColor(Color newColor)
    {
        color = newColor;
    }
}
