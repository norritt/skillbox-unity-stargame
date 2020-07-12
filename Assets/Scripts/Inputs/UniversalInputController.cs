using UnityEngine;

public class UniversalInputController : MonoBehaviour
{
    private IInputProvider _provider;

    private void Start()
    {
        if (SystemInfo.supportsAccelerometer)
        {
            _provider = new AccelerometerProvider();
        }
        else
        {
            _provider = new KeyboardProvider();
        }
    }

    public float GetZ()
    {
        return _provider.GetZ();
    }

    public float GetX()
    {
        return _provider.GetX();
    }

    internal string Type()
    {
        return (_provider is KeyboardProvider) ? "keyboard" : "gyro";
    }
}