using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DebugUI : MonoBehaviour
{
    Toggle RainToggle;
    // Use this for initialization
    void Start()
    {
        var toggles = GetComponentsInChildren<Toggle>();
        foreach (var toggle in toggles)
        {
            if (toggle.name.Equals("RainToggle"))
            {
                RainToggle = toggle;
                break;
            }
        }
        RainToggle.onValueChanged.AddListener(OnValueChanged);
    }

    void OnValueChanged(bool toggle)
    {
        var environment = FindObjectOfType<GameEnvironment>();
        if (toggle)
        {
            environment.StartRain();
        } else
        {
            environment.StopRain();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
