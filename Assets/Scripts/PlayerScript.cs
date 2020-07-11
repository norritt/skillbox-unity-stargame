using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ArmedAndDangerous))]
[RequireComponent(typeof(SideArmed))]
[RequireComponent(typeof(Parameters))]
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

    private Rigidbody _body;
    private ArmedAndDangerous _mainGun;
    private SideArmed _sideGun;
    private Parameters _parameters;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _mainGun = GetComponent<ArmedAndDangerous>();
        _sideGun = GetComponent<SideArmed>();
        _parameters = GetComponent<Parameters>();
        _sideGun.SetDelay(_mainGun.ShotDelay / 2);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (_mainGun && Input.GetButton("Fire1"))
        {
            _mainGun.Fire(isPlayerShip: true);
        }
        if (_sideGun && Input.GetButton("Fire2"))
        {
            _sideGun.Fire();
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

    private void OnTriggerEnter(Collider other)
    {
        if (string.Equals(other.gameObject.tag, "bonus", StringComparison.OrdinalIgnoreCase))
        {
            var demolish = other.gameObject.GetComponent<DestroyScript>();
            if (demolish != null)
            {
                demolish.Demolish();
            }
            _parameters.AddShield();
            GameControllerScript.Instance.IncreaseScore(50);
        }
    }

    private void OnDestroy()
    {
        GameControllerScript.Instance.CloseGame();
    }
}
