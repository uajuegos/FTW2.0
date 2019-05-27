using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameAnalyticsSDK;
using UnityEngine.Analytics;

public class ChangePerspective : MonoBehaviour {

    public Sprite isoSprite, cenitSprite;
    public Camera cameraPauseIso, cameraPauseCenit, cameraGameIso, cameraGameCenit;
    bool iso = false;
    public Button button;
	// Use this for initialization
	void Start () {
        Change_Perspective();
	}

    public void Change_Perspective() {
        iso = !iso;
        cameraPauseCenit.gameObject.SetActive(!iso);
        cameraGameCenit.gameObject.SetActive(!iso);
        cameraPauseIso.gameObject.SetActive(iso);
        cameraGameIso.gameObject.SetActive(iso);
        if (!iso) button.GetComponent<Image>().sprite = isoSprite;
        else button.GetComponent<Image>().sprite = cenitSprite;
        string pers = "isometrica";
        if (!iso) pers = "cenital";
        //GameAnalytics.NewDesignEvent("Ha cambiado de perspectiva a: "+ pers);

        Debug.Log("Perspective Changed Nivel" + GM.Instance.numNivel + "Mapa" + GM.Instance.numMapa);
        //Analytics.CustomEvent("Pespective changed", new Dictionary<string, object> { { "Nivel", GM.Instance.numNivel }, { "Mapa", GM.Instance.numMapa } });
        AnalyticsEvent.ScreenVisit("Perspective Changed Nivel" + GM.Instance.numNivel + "Mapa" + GM.Instance.numMapa);
    }
}
