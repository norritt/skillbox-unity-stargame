using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTargetingGunScript : MonoBehaviour
{
    public GameObject Weapon;
    public Transform Gun;
    public float ShotDelay = 0.3f;
    [Tags]
    public string PlayerTag;

    private GameObject _target;
    private float _nextShotTime;
    private Vector3 _lastKnownPostion;

    private void Start()
    {
        _nextShotTime = Time.time;
        _target = SceneManager.GetActiveScene().GetRootGameObjects().FirstOrDefault(x => x.CompareTag(PlayerTag));
    }

    internal void Fire()
    {
        if (Time.time > _nextShotTime)
        {
            if (_target != null)
            {
                _lastKnownPostion = _target.transform.position;
            }
            var direction = Vector3.Angle(new Vector3(0.0f, transform.position.y, 10.0f), _lastKnownPostion - transform.position);
            if (_lastKnownPostion.x > transform.position.x)
            {
                direction = 360 - direction;
            }
            Instantiate(Weapon, Gun.position, Quaternion.Euler(0, -direction, 0));
            _nextShotTime = Time.time + ShotDelay;
        }
    }
}
