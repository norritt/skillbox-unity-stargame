using UnityEngine;

public class ArmedAndDangerous : MonoBehaviour
{
    public GameObject Weapon;
    public Transform Gun;
    public float ShotDelay = 0.3f;
    private float _nextShotTime;

    internal void Fire(bool isPlayerShip)
    {
        if (Time.time > _nextShotTime)
        {
            var angle = isPlayerShip ? 0 : -180;
            Instantiate(Weapon, Gun.position, Quaternion.Euler(0, angle, 0));
            _nextShotTime = Time.time + ShotDelay;
        }
    }
}
