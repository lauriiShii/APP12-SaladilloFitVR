///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Laura Calvente
// Curso: 2017/2018
// Fichero: ConfigurationText.cs
///////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConfigurationText : MonoBehaviour {

    #region Variables

    // Objeto que indica que se ha establecido conexion
    public GameObject connected;
    // Objeto que indica que se no ha establecido conexion
    public GameObject disconnected;

    public GameObject clientPanel;

    #endregion

    #region Métodos

    // Use this for initialization
    void Start () {
        // Se recupera el valor de direccion IP almacenado en la configuracion de la aplicacion
        GameManager.ipAddress = PlayerPrefs.GetString(GameManager.IP_ADDRESS);
        // Mostramos la direccion IP
        GetComponent<Text>().text = GameManager.ipAddress;
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
