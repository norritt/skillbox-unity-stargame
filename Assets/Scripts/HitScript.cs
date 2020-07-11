using UnityEngine;

public class HitScript : MonoBehaviour
{
    public GameObject HitExplosion;

    public void Hit()
    {
        Instantiate(HitExplosion, transform.position, Quaternion.identity);
    }
}
