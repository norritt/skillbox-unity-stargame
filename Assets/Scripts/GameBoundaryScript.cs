﻿using UnityEngine;

public class GameBoundaryScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
