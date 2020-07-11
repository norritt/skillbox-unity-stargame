using UnityEngine;

[RequireComponent(typeof(ArmedAndDangerous))]
public class SimpleEnemyScript : MonoBehaviour
{
    private ArmedAndDangerous _mainGun;

    void Start()
    {
        _mainGun = GetComponent<ArmedAndDangerous>();
    }

    void Update()
    {
        _mainGun.Fire(isPlayerShip: false);
    }
}
