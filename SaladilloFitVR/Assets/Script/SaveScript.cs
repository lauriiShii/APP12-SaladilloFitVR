///////////////////////////////
// Práctica: SaladilloVR
// Alumno: Laura Calvente
// Curso: 2017/2018
// Fichero: SaveScript.cs
///////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveScript : MonoBehaviour {

    #region Variables

    // Objeto con la direccion IP instroducida por el usuario
    public Text ipAddress;

    // Objeto que indica que se ha establecido conexion
    public GameObject connected;
    // Objeto que indica que se no ha establecido conexion
    public GameObject disconnected;

    public GameObject clientPanel;

    #endregion

    #region Métodos

    /// <summary>
    /// Metodo que se ejecuta cuando se pulsa en el boton Save
    /// </summary>
    /// <remarks>
    /// Obtiene la direccion IP introducida por el usuario y la guarda en las preferencias de la aplicacion.
    /// </remarks>
    public void Click()
    {
        // Se obtiene la direccion IP introducida por el usuario
        GameManager.ipAddress = ipAddress.GetComponent<Text>().text;
        // Se guarda la direccion IP
        PlayerPrefs.SetString(GameManager.IP_ADDRESS, GameManager.ipAddress);
        // Se almacena el valor en la configuracion de la aplicacion
        PlayerPrefs.Save();
        // Se comprueba la conectividad con la Wev API
        CheckConnectivity();
    }

    /// <summary>
    /// Comprueba si existe conexion con la Web API
    /// </summary>
    /// <remarks>
    /// Llamar a la corrutina CheckConnectivityWebAPI para comprobar la conexion
    /// </remarks>
    private void CheckConnectivity()
    {
        StartCoroutine(CheckConnectivityWebAPI());
    }

    IEnumerator CheckConnectivityWebAPI()
    {
        // Prepara la peticion a la web api
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_CHECK_CONECTIVITY_LOCAL, GameManager.localhost))))
        {
            // Hace la peticion a la web api
            yield return www.SendWebRequest();


            // Comprueba el valor devuelto por el metodo
            clientPanel.SetActive(www.responseCode == 200);
            connected.SetActive(www.responseCode == 200);
            disconnected.SetActive(!connected.activeSelf);

            //connected.SetActive(false);
            //disconnected.SetActive(true);
        }
    }

    #endregion

}
