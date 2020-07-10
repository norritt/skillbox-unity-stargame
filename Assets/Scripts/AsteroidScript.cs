﻿using System;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float AngularSpeed = 5;

    private Rigidbody _asteroid;
    private DestroyScript _destroyable;

    // Start is called before the first frame update
    void Start()
    {
        _asteroid = GetComponent<Rigidbody>();
        _asteroid.angularVelocity = UnityEngine.Random.insideUnitSphere * AngularSpeed;
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
