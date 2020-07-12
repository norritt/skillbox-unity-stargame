using UnityEngine;
using UnityEngine.UI;

public class Parameters : MonoBehaviour
{
    public float VerticalSpeed = 20.0f;
    public float HorizontalSpeed = 35.0f;
    public int MaxShieldCount = 3;

    public Text Text;

    private int _shields = 0;

    internal bool RemoveShield()
    {
        var ret = _shields > 0;
        _shields--;
        return ret;
    }

    internal void AddShield()
    {
        if (_shields < MaxShieldCount)
        {
            _shields++;
        }
    }

    private void OnGUI()
    {
        if (Text != null)
        {
            Text.text = $"Shields: {_shields}";
        }
    }
}
