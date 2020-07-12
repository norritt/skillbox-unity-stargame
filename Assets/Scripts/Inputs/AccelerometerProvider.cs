using UnityEngine;

internal class AccelerometerProvider : IInputProvider
{
    //private static Quaternion GyroToUnity(Quaternion q)
    //{
    //    return new Quaternion(q.x, q.y, -q.z, -q.w);
    //}

    public float GetX()
    {
        return Input.acceleration.x * 3;
    }

    public float GetZ()
    {
        return Input.acceleration.y * 3;
    }
}