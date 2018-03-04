///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Laura Calvente
// Curso: 2017/2018
// Fichero: TrainingButtonScript.cs
///////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TrainingButtonScript : MonoBehaviour {

    #region Variables
    // Entero que corresponde con el número del entrenamiento
    public int training;
    // Texto donde vamos a mostrar el detalle del entrenamiento
    public GameObject trainingItem;
    // Texto donde vamos a mostrar el título de los detalles
    public GameObject detail;
    #endregion

    #region Métodos
    /// <summary>
    /// Realiza la acción que implementa LogButton.
    /// </summary>
    public void Click()
    {
        // Llamamos al metodo que guarda la informacion del cliente
        LogButton();
    }

    /// <summary>
    /// Guarda la informacion del cliente.
    /// </summary>
    /// <remarks>
    /// Llama a la corrutina que conecta con la WebAPI para guardar la información.
    /// </remarks>
    private void LogButton()
    {
        StartCoroutine(LogTrainingtWebAPI());
    }

    /// <summary>
    /// Cuando se hace click en un boton de entrenamiento carga los ejercicios que se hacen en esa sesión.
    /// </summary>
    /// <remarks>
    /// 
    /// Destruye a todos los hijos del "panel" Detail  y se hace visible para cargar los 
    /// itemtrainings que son textos como sus hijos, estos mostraran los ejercicios que 
    /// se realizaran en este entrenamiento.
    /// 
    /// Cada itemTraining que es introducido es posicionado y reescalado para que sea totalmente leible.
    /// 
    /// Encima de los itemTraining hay una especie de cabecera que indica el entrenamiento que estamos viendo.
    /// 
    /// Cuando se hace click en el boton del entrenamiento se almacena en Game Manager qué entrenamiento se ha elegido.
    /// 
    /// </remarks>
    /// <returns>Devuelve el control a Unity</returns>
    IEnumerator LogTrainingtWebAPI()
    {
        // using (UnityWebRequest www = UnityWebRequest.Get(
        // Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_TRAINING, GameManager.ipAdress, training))))
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_TRAINING_LOCAL, GameManager.localhost, training))))
        {
            // Hace la peticion a la web api
            yield return www.SendWebRequest();
            TrainingtList list = JsonUtility.FromJson<TrainingtList>(www.downloadHandler.text);

            // Destruimos todos los hijos de detail
            int childs = detail.transform.childCount;
            for (int i = childs - 1; i > 0; i--)
            {
                Destroy(detail.transform.GetChild(i).gameObject);
            }

            // Y si la WebAPI nos da alguna respuesta
            if (list.training.Length != 0)
            {
                detail.SetActive(true);

                // Almacenamos el entrenamiento
                GameManager.training = training;

                // Ponemos el titulo del entrenamiento
                detail.GetComponentInChildren<Text>().text = "Entrenamiento " + training + ": ";

                // Y por cada ejercicio que tenga el entrenamiento
                for (int i = 0; i < list.training.Length; i++)
                {

                    /// Se crea el objeto para el item.
                    GameObject item = Instantiate(trainingItem);
                    /// Se asigna el texto que debe mostrar.
                    item.GetComponentInChildren<Text>().text = list.training[i].machine;
                    /// Se establece su padre que esta en la escena.
                    item.transform.SetParent(detail.transform);
                    /// Se asigna la escala del item.
                    item.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
                    /// Se posiciona en la escena.
                    item.GetComponent<RectTransform>().localPosition = new Vector3(0, -((i+1) * 20), 0);
                }
            }
        }
    }
    #endregion

    #region Entidades
    public class TrainingtList
    {
        // Es importante que el nombre de esta variable coincida con el padre de lo que te dan en Postman
        public Training[] training;
    }

    [Serializable]
    public class Training
    {
        public int training;
        public string machine;
    }
    #endregion
}
