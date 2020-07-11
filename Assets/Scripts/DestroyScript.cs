using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public GameObject Explosion;

    // Update is called once per frame
    public void Demolish()
    {
        if (gameObject.tag == "asteroid")
        {
            GameControllerScript.Instance.IncreaseScore(10);
        }
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
