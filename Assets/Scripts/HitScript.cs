using UnityEngine;

[RequireComponent(typeof(Parameters))]
[RequireComponent(typeof(DestroyScript))]
public class HitScript : MonoBehaviour
{
    public GameObject HitExplosion;

    private Parameters _parameters;
    private DestroyScript _demolish;

    private void Start()
    {
        _parameters = GetComponent<Parameters>();
        _demolish = GetComponent<DestroyScript>();
    }

    public void Hit()
    {
        Instantiate(HitExplosion, transform.position, Quaternion.identity);
        if (!_parameters.RemoveShield())
        {
            _demolish.Demolish();
        }
    }
}
