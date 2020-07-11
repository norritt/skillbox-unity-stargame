using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject Asteroid1;
    public GameObject Asteroid2;
    public GameObject Asteroid3;
    public GameObject SimpleEnemy;
    public GameObject AdvancedEnemy;
    public GameObject Bonus;
    public GameObject EvilEnemy;
    public float MinDelay = 0.3f;
    public float MaxDelay = 0.6f;

    private float _nextLaunchTime;

    private GameObject[] _enemies;

    private void Start()
    {
        _enemies = new[] { Asteroid1, Asteroid2, Asteroid3, SimpleEnemy, AdvancedEnemy, Bonus, Bonus, EvilEnemy };
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextLaunchTime && GameControllerScript.Instance.IsStarted())
        {
            Launch();
        }
    }

    private void Launch()
    {
        _nextLaunchTime = Time.time + Random.Range(MinDelay, MaxDelay);
        var xPosition = Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2);
        var launchPoint = new Vector3(xPosition, 0, transform.position.z);
        var index = Random.Range(0, _enemies.Length);
        Instantiate(_enemies[index], launchPoint, Quaternion.identity);
    }
}
