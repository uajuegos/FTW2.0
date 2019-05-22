using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleRemoteSettings : MonoBehaviour {
    static int titulo = 0;
    //static bool change;
    public static Sprite spriteEspanol;
    public static Sprite spriteEnglish;
    public static Image objectTitulo;

    public Sprite _spriteEspanol;
    public Sprite _spriteEnglish;
    public Image _objectTitulo;

    private void Start()
    {
        // Add this class's updated settings handler to the RemoteSettings.Updated event.
        RemoteSettings.Updated += RemoteSettingsUpdated;
        objectTitulo = _objectTitulo;
        spriteEspanol = _spriteEspanol;
        spriteEnglish = _spriteEnglish;
    }
    // Update is called once per frame

    private void Update()
    {
        RemoteSettings.ForceUpdate();
      /*  if (change) {
            if (titulo == 0)
                objectTitulo.sprite = spriteEspanol;
            else if (titulo == 1)
                objectTitulo.sprite = spriteEnglish;
        }*/
    }

    public static void RemoteSettingsUpdated() {
        if (titulo != RemoteSettings.GetInt("Titulo"))
        {
            titulo = RemoteSettings.GetInt("Titulo");
        }
        Debug.Log(titulo);
        if (titulo == 0)
            objectTitulo.sprite = spriteEspanol;
        else if (titulo == 1)
            objectTitulo.sprite = spriteEnglish;
    }
}
