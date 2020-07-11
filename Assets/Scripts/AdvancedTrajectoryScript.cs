using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AdvancedTrajectoryScript : MonoBehaviour
{
    public float MinSpeed = 8;
    public float MaxSpeed = 20;

    private Rigidbody _movable;

    void Start()
    {
        float randomSpeed = -UnityEngine.Random.Range(MinSpeed, MaxSpeed);
        float randomDirection = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        _movable = GetComponent<Rigidbody>();
        var velocity = new Vector3(randomDirection * randomSpeed, 0, randomSpeed);
        _movable.velocity = Vector3.ClampMagnitude(velocity, -randomSpeed);
    }

    private void OnTriggerExit(Collider other)
    {
        if (string.Equals(other.gameObject.tag, "boundary", StringComparison.OrdinalIgnoreCase))
        {
            _movable.velocity = new Vector3(- _movable.velocity.x, _movable.velocity.y, _movable.velocity.z);
        }
    }
}
