using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class changeScene : MonoBehaviour
{
    public Animator transicion;
    public void Change(string scene)
    {
        if (scene != "exit")
            StartCoroutine(LoadScene(scene));
        else {
            GameAnalytics.NewDesignEvent("Se ha salido del juego");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
        }
    }

    public void SendTrace(string traceLog)
    {
        GameAnalytics.NewDesignEvent(traceLog);
    }
    IEnumerator LoadScene(string scene)
    {
        GameAnalytics.NewDesignEvent("Paso a escena: " + scene);
       
        transicion.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scene);
    }

}