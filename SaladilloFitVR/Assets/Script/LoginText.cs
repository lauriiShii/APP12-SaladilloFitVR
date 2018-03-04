///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Laura Calvente
// Curso: 2017/2018
// Fichero: LoginText.cs
///////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoginText : MonoBehaviour {

    #region Variables
    // Texto donde esta escrito el DNI
    public Text dni;
    // Botones de los ejercicios
    public GameObject trainings;
    // Detalles del ejercicio
    public GameObject details;
    // Mensaje de bienvenida
    public Text welcome;
    #endregion

    #region Métodos
    /// <summary>
    /// Comprueba si existe conexión con la Web API y alamacena el dni en Game Manager.
    /// </summary>
    /// <remarks>
    /// Llamar a la corrutina CheckConnectivityWebAPI para comprobar la conexión.
    /// </remarks>
    public void Click()
    {
        GameManager.dni = dni.text;
        StartCoroutine(LoginWebAPI());
    }

    /// <summary>
    /// Según la respuesta de la Web API habilita o deshabilita cientos paneles.
    /// </summary>
    /// <remarks>
    /// 
    /// Si existe la respuesta se le da la bien venida al cliente y se activan los paneles
    /// de trainings y details, se almacena tambien el nombre en el Game Manager.
    /// 
    /// Sino se da la bien venida generica y se desactivan los dos paneles. 
    /// En el Game Manager se guardaria una cadena vacia como nombre.
    /// 
    /// </remarks>
    /// <returns>Devuelve el control a Unity</returns>
    IEnumerator LoginWebAPI()
    {
        // using (UnityWebRequest www = UnityWebRequest.Get(
        // Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_CLIENT, GameManager.ipAdress, GameManager.dni))))
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_CLIENT_LOCAL, GameManager.localhost, GameManager.dni))))
        {
            // Hace la peticion a la web api
            yield return www.SendWebRequest();
            string result = www.downloadHandler.text;
            if(result.Equals("\"\""))
            {
                GameManager.name = "";
                welcome.text = "Bienvenid@ a SaladilloFitVR";
                trainings.SetActive(false);
                details.SetActive(false);
            }
            else if (result.Length > 0)
            {
                GameManager.name = result.Substring(1, result.Length - 2);
                dni.text = GameManager.name;
                welcome.text = string.Format("Hola {0}", GameManager.name);
                trainings.SetActive(true);
                details.SetActive(true);
            }
        }
    }
    #endregion

}
