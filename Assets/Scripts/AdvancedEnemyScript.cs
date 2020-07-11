using UnityEngine;

[RequireComponent(typeof(PlayerTargetingGunScript))]
public class AdvancedEnemyScript : MonoBehaviour
{
    private PlayerTargetingGunScript _mainGun;

    void Start()
    {
        _mainGun = GetComponent<PlayerTargetingGunScript>();
    }

    void Update()
    {
        _mainGun.Fire();
    }
}
