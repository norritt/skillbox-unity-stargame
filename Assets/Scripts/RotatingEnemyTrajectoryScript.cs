using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyState))]
public class RotatingEnemyTrajectoryScript : MonoBehaviour
{
    public float MinSpeed = 8;
    public float MaxSpeed = 20;
    public string PlayerObjectName;
    public float RotationSpeed;

    [Tags]
    public string BoundaryTag;

    private Rigidbody _movable;
    private GameObject _target;
    private EnemyState _state;
    private Vector3 _lastKnownPosition;
    private float _angle = 0;

    void Start()
    {
        _target = SceneManager.GetActiveScene().GetRootGameObjects().FirstOrDefault(x => string.Equals(x.name, PlayerObjectName, StringComparison.OrdinalIgnoreCase));
        _state = GetComponent<EnemyState>();

        var randomSpeed = -UnityEngine.Random.Range(MinSpeed, MaxSpeed);
        _movable = GetComponent<Rigidbody>();
        _movable.velocity = new Vector3(0, 0, randomSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            _lastKnownPosition = _target.transform.position;
        }
        if (_state.State != EnemyState.EvilState.Rotated && _lastKnownPosition.z > transform.position.z)
        {
            var sign = _lastKnownPosition.x > transform.position.x ? -1 : +1;
            _angle += sign * RotationSpeed * Time.deltaTime;
            _movable.rotation = Quaternion.Euler(0, _angle, 0);
        }
        if (transform.rotation.eulerAngles.y < 185 && 175 < transform.rotation.eulerAngles.y)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _state.State = EnemyState.EvilState.Rotated;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (string.Equals(other.gameObject.tag, BoundaryTag, StringComparison.OrdinalIgnoreCase))
        {
            _movable.velocity = Vector3.zero;
        }
    }
}
