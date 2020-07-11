using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float Speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        var laser = GetComponent<Rigidbody>();
        var direction = Mathf.Deg2Rad * transform.rotation.eulerAngles.y;
        laser.velocity = new Vector3(Mathf.Sin(direction), 0, Mathf.Cos(direction)) * Speed;
    }
}
