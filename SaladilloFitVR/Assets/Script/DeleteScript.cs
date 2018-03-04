///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Laura Calvente
// Curso: 2017/2018
// Fichero: DeleteScript.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteScript : MonoBehaviour {

    #region Variables
    // Objeto con la direccion IP introducida por el usuario
    public Text ipAddress;
    #endregion

    #region Métodos
    /// <summary>
    /// Método que se ejecuta cuando se pulsa en este boton.
    /// </summary>
    /// <remarks>
    /// Borra el último caracter del texto de ipAdress
    /// </remarks>
    public void Click()
    {
        string texto = ipAddress.GetComponent<Text>().text;

        if (texto.Length > 0)
        {
            ipAddress.GetComponent<Text>().text = texto.Substring(0, texto.Length - 1);
        }
    }
    #endregion

}
