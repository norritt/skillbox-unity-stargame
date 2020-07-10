using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject Asteroid1;
    public GameObject Asteroid2;
    public GameObject Asteroid3;
    public float MinDelay = 0.3f;
    public float MaxDelay = 0.6f;

    private float _nextLaunchTime;

    private IReadOnlyCollection<GameObject> _asteroids;

    private void Start()
    {
        _asteroids = new List<GameObject> { Asteroid1, Asteroid2, Asteroid3 };
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextLaunchTime)
        {
            Launch();
        }
    }

    private void Launch()
    {
        _nextLaunchTime = Time.time + Random.Range(MinDelay, MaxDelay);
        var xPosition = Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2);
        var launchPoint = new Vector3(xPosition, 0, transform.position.z);
        var asteroid = _asteroids.Skip(Random.Range(0, _asteroids.Count - 1)).FirstOrDefault();
        Instantiate(asteroid, launchPoint, Quaternion.identity);
    }
}
