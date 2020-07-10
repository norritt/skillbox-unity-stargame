using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    #region Move
    public float VerticalSpeed = 15.0f;
    public float HorizontalSpeed = 15.0f;

    public float MinX;
    public float MaxX;
    public float MinZ;
    public float MaxZ;

    public float Roll = 0.5f;
    public float Pitch = 0.5f;
    #endregion Move

    #region Firepower
    #region Main
    public GameObject Weapon;
    public Transform Gun;
    public float ShotDelay = 0.3f;
    private float _nextShotTime;
    #endregion Main

    #region Side
    public GameObject SideWeapon;
    public Transform LeftGun;
    public Transform RightGun;
    public float SideAngle = 45;
    private float _sideShotDelay;
    private float _nextSideShotTime;
    #endregion Side
    #endregion Firepower

    private Rigidbody _body;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _sideShotDelay = ShotDelay / 2;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ShootMain();
        ShootSide();
    }

    private void ShootSide()
    {
        if (Time.time > _nextSideShotTime && Input.GetButton("Fire2"))
        {
            var shot = Instantiate(SideWeapon, LeftGun.position, Quaternion.Euler(0, -SideAngle, 0));
            var script = shot.GetComponent<LaserScript>();
            script.ShotDirection = LaserScript.Direction.Left;
            shot = Instantiate(SideWeapon, RightGun.position, Quaternion.Euler(0, SideAngle, 0));
            script = shot.GetComponent<LaserScript>();
            script.ShotDirection = LaserScript.Direction.Right;

            _nextSideShotTime = Time.time + _sideShotDelay;
        }
    }

    private void ShootMain()
    {
        if (Time.time > _nextShotTime && Input.GetButton("Fire1"))
        { 
            Instantiate(Weapon, Gun.position, Quaternion.identity);
            _nextShotTime = Time.time + ShotDelay;
        }
    }

    private void MovePlayer()
    {
        var dx = Input.GetAxis("Horizontal");
        var dz = Input.GetAxis("Vertical");

        _body.velocity = new Vector3(dx * HorizontalSpeed, 0, dz * VerticalSpeed);

        var clampedX = Mathf.Clamp(_body.position.x, MinX, MaxX);
        var clampedZ = Mathf.Clamp(_body.position.z, MinZ, MaxZ);
        _body.position = new Vector3(clampedX, _body.position.y, clampedZ);

        _body.rotation = Quaternion.Euler(_body.velocity.z * Pitch, 0, _body.velocity.x * Roll);
    }
}
