using UnityEngine;

public class PointCounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var valObject = other.gameObject.GetComponent<ValueableObject>();
        if (valObject != null)
        {
            GameControllerScript.Instance.IncreaseScore(valObject.Points);
        }
    }
}
