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

// Script que se ejecuta nada más arrancar el juego y 
// carga la ipAdress almacenada con los PlayerPrefs
public class ConfigurationText : MonoBehaviour {

    #region Variables
    // Objeto que indica que se ha establecido conexión
    public GameObject connected;
    // Objeto que indica que se no ha establecido conexión
    public GameObject disconnected;
    // Panel donde se introduce el dni, este solo debe ser visible cuando se extrablece conexión
    public GameObject clientPanel;
    #endregion

    #region Métodos
    /// <summary>
    /// Se inicializan ciertas variables y componentes. Se comprueba si hay conexión o no.
    /// </summary>
    /// <remarks>
    /// Utilizamos el PlayerPrefs para guardar la ipAdress en GameManager.
    /// De esta forma cuando volvamos a iniciar la aplicación se recordara.
    /// </remarks>
    void Start () {
        // Se recupera el valor de direccion IP almacenado en la configuracion de la aplicacion
        GameManager.ipAddress = PlayerPrefs.GetString(GameManager.IP_ADDRESS);
        // Mostramos la direccion IP
        GetComponent<Text>().text = GameManager.ipAddress;
        // Se comprueba la conectividad con la Wev API
        CheckConnectivity();
	}

    /// <summary>
    /// Comprueba si existe conexión con la Web API.
    /// </summary>
    /// <remarks>
    /// Llamar a la corrutina CheckConnectivityWebAPI para comprobar la conexión.
    /// </remarks>
    private void CheckConnectivity()
    {
        StartCoroutine(CheckConnectivityWebAPI());
    }

    /// <summary>
    /// Dependiendo de si hay respuesta o no de la Web API se muestra una esfera de 
    /// conexión u otra, así indicamos el estado de la conexión.
    /// </summary>
    /// <remarks>
    /// Si hay conexión se muestra el panel del cliente.
    /// </remarks>
    /// <returns>Devuelve el control a Unity</returns>
    IEnumerator CheckConnectivityWebAPI()
    {
        //using (UnityWebRequest www = UnityWebRequest.Get(
        //Uri.EscapeUriString(string.Format(GameManager.WEB_API_CHECK_CONECTIVITY, GameManager.ipAddress))))
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_CHECK_CONECTIVITY_LOCAL, GameManager.localhost))))
        {
            // Hace la peticion a la web api
            yield return www.SendWebRequest();

            // Comprueba el valor devuelto por el metodo
            clientPanel.SetActive(www.responseCode == 200);
            connected.SetActive(www.responseCode == 200);
            disconnected.SetActive(!connected.activeSelf);
        }
    }
    #endregion

}
