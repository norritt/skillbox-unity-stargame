using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ArmedAndDangerous))]
[RequireComponent(typeof(SideArmed))]
[RequireComponent(typeof(Parameters))]
[RequireComponent(typeof(TagListComponent))]
[RequireComponent(typeof(UniversalInputController))]
public class PlayerScript : MonoBehaviour
{
    #region Move
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
    private TagListComponent _tagList;
    private UniversalInputController _inputController;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _mainGun = GetComponent<ArmedAndDangerous>();
        _sideGun = GetComponent<SideArmed>();
        _parameters = GetComponent<Parameters>();
        _tagList = GetComponent<TagListComponent>();
        _inputController = GetComponent<UniversalInputController>();
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
        var dx = _inputController.GetX();
        var dz = _inputController.GetZ();

        _body.velocity = new Vector3(dx * _parameters.HorizontalSpeed, 0, dz * _parameters.VerticalSpeed);

        var clampedX = Mathf.Clamp(_body.position.x, MinX, MaxX);
        var clampedZ = Mathf.Clamp(_body.position.z, MinZ, MaxZ);
        _body.position = new Vector3(clampedX, _body.position.y, clampedZ);

        _body.rotation = Quaternion.Euler(_body.velocity.z * Pitch, 0, _body.velocity.x * Roll);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_tagList.Contains(other.gameObject.tag))
        {
            return;
        }
        var demolish = other.gameObject.GetComponent<DestroyScript>();
        if (demolish != null)
        {
            demolish.Demolish();
        }
        _parameters.AddShield();
    }

    private void OnDestroy()
    {
        GameControllerScript.Instance.OpenMenu();
    }
}
