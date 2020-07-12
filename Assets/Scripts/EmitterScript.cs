using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject[] Objects;
    public float StartDelay = 0f;
    public float MinDelay = 0.5f;
    public float MaxDelay = 2f;

    private float _nextLaunchTime;

    private void Start()
    {
        _nextLaunchTime = Time.time + StartDelay;
    }

    private void Update()
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
        var index = Random.Range(0, Objects.Length);
        Instantiate(Objects[index], launchPoint, Quaternion.identity);
    }
}
