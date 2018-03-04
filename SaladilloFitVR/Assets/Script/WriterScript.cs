///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Laura Calvente
// Curso: 2017/2018
// Fichero: WriterScript.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriterScript : MonoBehaviour {

    #region Variables

    // Objeto con la direccion IP instroducida por el usuario
    public Text ipAddress;

    #endregion

    #region Métodos

    /// <summary>
    /// Método que se ejecuta cuando se pulsa en el boton.
    /// </summary>
    /// <remarks>
    /// Obtiene el texto del boton y se lo concatena al texto de ipAddress.
    /// </remarks>
    public void Click()
    {
        ipAddress.GetComponent<Text>().text += GetComponentInChildren<Text>().text;
    }

    #endregion

}