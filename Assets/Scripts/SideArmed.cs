using UnityEngine;

public class SideArmed : MonoBehaviour
{
    public GameObject SideWeapon;
    public Transform LeftGun;
    public Transform RightGun;
    public float SideAngle = 45;
    private float _sideShotDelay;
    private float _nextSideShotTime;

    internal void SetDelay(float sideShotDelay)
    {
        _sideShotDelay = sideShotDelay;
    }

    internal void Fire()
    {
        if (Time.time > _nextSideShotTime)
        {
            Instantiate(SideWeapon, LeftGun.position, Quaternion.Euler(0, -SideAngle, 0));
            Instantiate(SideWeapon, RightGun.position, Quaternion.Euler(0, SideAngle, 0));

            _nextSideShotTime = Time.time + _sideShotDelay;
        }
    }
}
