using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class InteractedTracker : MonoBehaviour
{

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                //Debug.Log(objectHit.name);
                // Do something with the object that was hit by the raycast.
            }


            //Se comprueba si en el punto del mouse al hacer click hay colisión con algún objeto. Se devuelven todos los objetos en result.
            Collider2D[] result = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Scene scene = SceneManager.GetActiveScene();
            string name = scene.name;
            int i = result.Length;
            if (i == 0)
            {
                //GameAnalytics.NewDesignEvent("Se ha pulsado: empty en la escena: " +name);

                //Analytics.CustomEvent("Pulsación", new Dictionary<string, object> { { "Scene", name },{"Object", "null"} });
                //Debug.Log("Se ha pulsado empty");
            }
            else
            {
                while (i > 0)
                {
                    i--;
                    string objName = result[i].name;
                    if (objName != null)
                    {
                        //GameAnalytics.NewDesignEvent("Se ha pulsado: " + objName+ " en la escena: "+ name);
                       // Analytics.CustomEvent("Pulsación", new Dictionary<string, object> { { "Scene", name }, { "Object", objName } });

                       // Debug.Log("Se ha pulsado " + objName);
                    }
                }
            }
        }
    }
}