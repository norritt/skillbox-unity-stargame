using System;
using UnityEngine;

[RequireComponent(typeof(DestroyScript))]
public class BasicEnemyExplosionScript : MonoBehaviour
{
    private DestroyScript _destroyable;

    void Start()
    {
        _destroyable = GetComponent<DestroyScript>();
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
