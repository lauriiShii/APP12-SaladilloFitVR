///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Laura Calvente
// Curso: 2017/2018
// Fichero: StartTriningScript.cs
///////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class StartTrainingScript : MonoBehaviour
{

    #region Métodos
    /// <summary>
    /// Deja un Log en la Web api y nos lleva a la sala de entrenamiento.
    /// </summary>
    public void Click()
    {
        StartCoroutine(StartTraining());
    }

    /// <summary>
    /// Manda el formulario con la informacion del cliente y el entrenamiento escogido al log de la web API.
    /// Despues de ello nos lleva a la nueva escena.
    /// </summary>
    /// <returns> Devuelve el control a Unity</returns>
    private IEnumerator StartTraining()
    {
        // Construimos la informacion que se envia a la WebAPI
        WWWForm form = new WWWForm();
        form.AddField("dni", GameManager.dni);
        form.AddField("training", GameManager.training);

        // Crea la peticion a la WebAPI
        using (UnityWebRequest www = UnityWebRequest.Post(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_LOG_TRAINING_LOCAL, GameManager.localhost)), form))
        {
            // Envia la peticion a la WebAPI y espera la respuesta
            yield return www.SendWebRequest();

            // Accion a realizar si se ha ejecutado son error
            if (!www.isNetworkError)
            {
                SceneManager.LoadScene("Machines");
            }
        }
    }
    #endregion
}
