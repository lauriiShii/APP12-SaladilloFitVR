///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Laura Calvente
// Curso: 2017/2018
// Fichero: EndScript.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {

    #region Métodos
    /// <summary>
    /// Regresa a la escena principal.
    /// </summary>
    public void Click()
    {
        SceneManager.LoadScene("Main");
    }
    #endregion
}
