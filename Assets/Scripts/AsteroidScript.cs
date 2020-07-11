using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float AngularSpeed = 5;

    private Rigidbody _asteroid;

    void Start()
    {
        _asteroid = GetComponent<Rigidbody>();
        _asteroid.angularVelocity = UnityEngine.Random.insideUnitSphere * AngularSpeed;
    }
}
