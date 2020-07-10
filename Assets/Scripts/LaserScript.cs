using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right,
        Direct,
    }
    public float Speed = 50f;
    public Direction ShotDirection = Direction.Left;

    // Start is called before the first frame update
    void Start()
    {
        var laser = GetComponent<Rigidbody>();
        switch (ShotDirection)
        {
            case Direction.Left:
                laser.velocity = Vector3.ClampMagnitude(new Vector3(-Speed, 0, Speed), Speed);
                break;
            case Direction.Right:
                laser.velocity = Vector3.ClampMagnitude(new Vector3(Speed, 0, Speed), Speed);
                break;
            case Direction.Direct:
                laser.velocity = new Vector3(0, 0, Speed);
                break;
        }
    }
}
