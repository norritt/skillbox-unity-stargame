using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleTrajectoryScript : MonoBehaviour
{
    public float MinSpeed = 8;
    public float MaxSpeed = 20;

    private Rigidbody _movable;

    void Start()
    {
        float randomSpeed = -Random.Range(MinSpeed, MaxSpeed);
        _movable = GetComponent<Rigidbody>();
        _movable.velocity = new Vector3(0, 0, randomSpeed);
    }
}
