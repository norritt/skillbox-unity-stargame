using UnityEngine;

internal class KeyboardProvider : IInputProvider
{
    public float GetX()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetZ()
    {
        return Input.GetAxis("Vertical");
    }
}