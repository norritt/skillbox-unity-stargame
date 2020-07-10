using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject Asteroid;
    public float MinDelay = 0.3f;
    public float MaxDelay = 0.6f;

    private float _nextLaunchTime;

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
        Instantiate(Asteroid, launchPoint, Quaternion.identity);
    }
}
