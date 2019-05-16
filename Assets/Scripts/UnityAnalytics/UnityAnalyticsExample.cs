using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class UnityAnalyticsExample : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Analytics.CustomEvent("Level complete", new Dictionary<string, object> { { "Dificultad", 1 }, { "Nivel", 1 }, { "Estrellas", 3 } });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
