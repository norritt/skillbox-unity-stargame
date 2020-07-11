using UnityEngine;

[RequireComponent(typeof(ArmedAndDangerous))]
public class SimpleEnemyScript : MonoBehaviour
{
    private ArmedAndDangerous _mainGun;

    // Start is called before the first frame update
    void Start()
    {
        _mainGun = GetComponent<ArmedAndDangerous>();
    }

    // Update is called once per frame
    void Update()
    {
        _mainGun.Fire(isPlayerShip: false);
    }
}
