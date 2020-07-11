using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float Speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        var laser = GetComponent<Rigidbody>();
        laser.velocity = transform.forward * Speed;
    }
}
