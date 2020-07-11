using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Parameters : MonoBehaviour
{
    private Text _text;

    private int _shields = 0;

    private void Start()
    {
        var canvas = SceneManager.GetActiveScene().GetRootGameObjects().FirstOrDefault(go => string.Equals(go.name, "Canvas", StringComparison.OrdinalIgnoreCase));
        _text = canvas.GetComponentsInChildren<Text>().FirstOrDefault(go => string.Equals(go.name, "ShieldsBox", StringComparison.OrdinalIgnoreCase));
    }

    internal bool RemoveShield()
    {
        var ret = _shields > 0;
        _shields--;
        return ret;
    }

    internal void AddShield()
    {
        if (_shields < 3)
        {
            _shields++;
        }
    }

    private void OnGUI()
    {
        if (_text != null)
        {
            _text.text = $"Shields: {_shields}";
        }
    }
}
