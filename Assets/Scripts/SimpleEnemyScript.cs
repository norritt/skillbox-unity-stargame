using System;
using UnityEngine;

[RequireComponent(typeof(ArmedAndDangerous))]
[RequireComponent(typeof(DestroyScript))]
public class SimpleEnemyScript : MonoBehaviour
{
    private DestroyScript _destroyable;
    private ArmedAndDangerous _mainGun;

    // Start is called before the first frame update
    void Start()
    {
        _destroyable = GetComponent<DestroyScript>();
        _mainGun = GetComponent<ArmedAndDangerous>();
    }

    // Update is called once per frame
    void Update()
    {
        _mainGun.Fire();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (string.Equals(other.gameObject.tag, "boundary", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(other.gameObject.tag, "asteroid", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(other.gameObject.tag, "enemy", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }
        var destroyable = other.GetComponentInParent<DestroyScript>();
        if (destroyable != null)
        {
            destroyable.Demolish();
        }
        _destroyable.Demolish();
    }
}
