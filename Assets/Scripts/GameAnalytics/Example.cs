using UnityEngine;
using GameAnalyticsSDK;

public class Example : MonoBehaviour
{
    void Start()
    {
        //Hay que inicializar manualmente la SDK. Se pueden generar eventos después de esta llamada
       // GameAnalytics.Initialize();
       // ProgressionEvent();
    }

    /// <summary>
    /// Para trackear Transanciones de dinero
    /// Con BusinessEvent se puede incluir información de que tipo de item se ha comprado y donde se ha hecho la compra. Ademas tenemos el recibo.
    /// </summary>
    private void BusinessEvent()
    {
        GameAnalytics.NewBusinessEvent("currency", 0, "itemType", "itemID", "cartType");
    }

    /// <summary>
    /// Para trackear la economia dentro del juego.
    /// TODO: NO
    /// </summary>
    private void ResourceEvent()
    {
    }

    /// <summary>
    /// Para trackear cuando un jugados empieza y acaba un nivel
    /// Sigue una jerarquía de tiers (World,Level,Phase) para indicar el sitio del jugador en el juego
    /// </summary>
    private void ProgressionEvent()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Dificultad1", "Nivel1", 3);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Dificultad1", "Nivel2");
    }

    /// <summary>
    /// Para trackear cualquier otro concepto del juego.
    /// Por ejemplo para trackear GUI elements o pasos de tutorial.
    /// No tiene dimensiones custom
    /// </summary>
    private void DesignEvent()
    {
        GameAnalytics.NewDesignEvent("SonidoActivado", 1.0f);
    }

    /// <summary>
    /// Para loguear errores y warnings que los jugadores generan en el juego
    /// Se puede agrupar eventos por severidad y añadirles un mensaje, así como la pila de trazas
    /// </summary>
    private void ErrorEvent()
    {
        GameAnalytics.NewErrorEvent(GAErrorSeverity.Critical, "Ha petado todo");
    }

    /// <summary>
    /// TODO: No se que es
    /// </summary>
    private void CustomEvent()
    {
        //GameAnalytics.SetCustomDimension01()
    }
}
