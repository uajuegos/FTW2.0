using RAGE.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class InteractedTracker : MonoBehaviour
{

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Se comprueba si en el punto del mouse al hacer click hay colisión con algún objeto. Se devuelven todos los objetos en result.
            Collider2D[] result = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            int i = result.Length;
            if (i == 0)
            {
                Tracker.T.setVar("empty", 1);
                GameAnalytics.NewDesignEvent("Se ha pulsado: empty");

            }
            else
            {
                while (i > 0)
                {
                    i--;
                    string objName = result[i].name;
                    if (objName != null)
                    {
                        Tracker.T.setVar(objName, 1);
                        GameAnalytics.NewDesignEvent("Se ha pulsado: " + objName);
                    }
                }
            }

            //Return the current Active Scene in order to get the current Scene's name
            Scene scene = SceneManager.GetActiveScene();
            string name = scene.name;

            Tracker.T.GameObject.Interacted(name);
            //TODO: Yo no se si hay que generar aquí evento de que cada vez que se hace click se indica en qué escena se hace
        }
    }
}