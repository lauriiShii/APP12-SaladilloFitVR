///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Laura Calvente
// Curso: 2017/2018
// Fichero: MoveJoystick.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoystick : MonoBehaviour {

    #region Variables
    // Velocidad maxima de desplazamiento
    public float maxSpeed = 0.5f;
    // La fuerza de empuje
    public float pushForce = 10f;
    // Referencia al rigidbody qe queremos mover
    public Rigidbody rigidbody;
    #endregion

    #region Métodos
    /// <summary>
    /// Se instancia el rigibody
    /// </summary>
    void Awake () {
        // Recuperamos la referencia al componente Rigidbody
        rigidbody = GetComponent<Rigidbody>();
	}
	
	/// <summary>
    /// Se establece el movimiento vertical y horizontal.
    /// </summary>
	void FixedUpdate () {
        // Recuperamos el valor de los ejes horizontal y vertical
        // Son valores normalizados que van de 0 a 1
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Calculamos el vector de movimiento con la direccion a la que mira la camara
        Vector3 moveDirection = (h * Camera.main.transform.right + v * Camera.main.transform.forward).normalized;

        // Comprobamos la magnitud de desplazamiento y aplicamos el empuje si la velocidad maxima no se ha alcanzado
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            // Aplicamos el empuje en la direccion calculada con la fuerza indicada
            rigidbody.AddForce(moveDirection * pushForce);
        }

	}
    #endregion

}
