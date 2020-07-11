using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyScript))]
public class BasicEnemyExplosionScript : MonoBehaviour
{
    private DestroyScript _destroyable;
    private HashSet<string> _ignorable;

    void Start()
    {
        _destroyable = GetComponent<DestroyScript>();
        _ignorable = new HashSet<string>(new[] { "boundary", "asteroid", "enemy" }, StringComparer.OrdinalIgnoreCase);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_ignorable.Contains(other.gameObject.tag))
        {
            return;
        }
        var hitObject = other.GetComponentInParent<HitScript>();
        if (hitObject != null)
        {
            hitObject.Hit();
        }
        else
        {
            var destroyable = other.GetComponentInParent<DestroyScript>();
            if (destroyable != null)
            {
                destroyable.Demolish();
            }
        }
        _destroyable.Demolish();
    }
}
