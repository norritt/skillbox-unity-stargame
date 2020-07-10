using UnityEngine;

public class ArmedAndDangerous : MonoBehaviour
{
    public GameObject Weapon;
    public Transform Gun;
    public float ShotDelay = 0.3f;
    private float _nextShotTime;

    private void Start()
    {
        _nextShotTime = Time.time;
    }

    internal void Fire()
    {
        if (Time.time > _nextShotTime)
        {
            Instantiate(Weapon, Gun.position, Quaternion.identity);
            _nextShotTime = Time.time + ShotDelay;
        }
    }
}
