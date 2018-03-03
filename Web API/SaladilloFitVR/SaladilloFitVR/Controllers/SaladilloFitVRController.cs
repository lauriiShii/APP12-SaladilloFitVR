using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using SaladilloFitVR.Models;
using System;

namespace SaladilloFitVR.Controllers
{
    public class SaladilloFitVRController : ApiController
    {
        #region Métodos Públicos

        /// <summary>
        /// Método que debe ser utilizado por otros sistemas para
        /// comprobar la conectividad con la Web API.
        /// </summary>
        /// <remarks>
        /// Devuelve HttpStatusCode.OK.
        /// </remarks>
        /// <returns>
        /// HttpResponseMessage con el resultado de la ejecución:
        /// - StatusCode = código de excepción.
        /// </returns>
        [HttpGet]
        public HttpResponseMessage CheckConnectivity()
        {
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Obtiene el nombre del cliente para el DNI recibido como parámetro.
        /// </summary>
        /// <remarks>
        /// - Llama al método privado GetClientNameInfo.
        /// - Serializa el modelo que devuelve el método.
        /// </remarks>
        /// <param name="dni">DNI del cliente.</param>
        /// <returns>
        /// HttpResponseMessage con el resultado de la ejecución:
        /// - StatusCode = código de excepción.
        /// - Content: datos que se devuelven.
        /// </returns>
        [HttpGet]
        public HttpResponseMessage GetClientName(string dni)
        {
            // Crea la respuesta
            var response = this.Request.CreateResponse(HttpStatusCode.OK);

            // Llama al método GetClientNameInfo y serializa los datos obtenidos
            response.Content = new StringContent(JsonConvert.SerializeObject(GetClientNameInfo(dni)), Encoding.UTF8, "application/json");

            // Devuelve la respuesta
            return response;
        }

        /// <summary>
        /// Obtiene el listado de máquinas que hay que utilizar para el entranamiento indicado.
        /// </summary>
        /// <remarks>
        /// - Llama al método privado GetTrainingList.
        /// - Convierte la entidad devuelta por la llamada en un modelo usando el método ModelConversion de ModelsHelper.
        /// - Serializa el modelo que debe ser devuelto por el método.
        /// </remarks>
        /// <param name="training">Identificador de entrenamiento.</param>
        /// <returns>
        /// HttpResponseMessage con el resultado de la ejecución:
        /// - StatusCode = código de excepción.
        /// - Content: datos que se devuelven.
        /// </returns>
        [HttpGet]
        public HttpResponseMessage GetTraining(int training)
        {
            // Crea la respuesta
            var response = this.Request.CreateResponse(HttpStatusCode.OK);

            // Llama al método GetTraining y serializa los datos devueltos
            response.Content = new StringContent("{\"training\":" + JsonConvert.SerializeObject(GetTrainingList(training)) + "}", Encoding.UTF8, "application/json");

            // Devuelve la respuesta
            return response;
        }

        /// <summary>
        /// Guarda la información del entrenamiento de un cliente.
        /// </summary>
        /// <remarks>
        /// - Llama al método privado GetTrainingList.
        /// - Convierte la entidad devuelta por la llamada en un modelo usando el método ModelConversion de ModelsHelper.
        /// - Serializa el modelo que debe ser devuelto por el método.
        /// </remarks>
        /// <param name="training">Identificador de entrenamiento.</param>
        /// <returns>
        /// HttpResponseMessage con el resultado de la ejecución:
        /// - StatusCode = código de excepción.
        /// - Content: datos que se devuelven.
        /// </returns>
        [HttpPost]
        public IHttpActionResult LogTraining(FormDataCollection form)
        {
            // Crea el modelo LogTrainingModel con la información recibida como parámetro
            LogTrainingModel logTrainingModel = new LogTrainingModel();
            logTrainingModel.dni = form.Get("dni").ToString();
            logTrainingModel.training = int.Parse(form.Get("training"));

            // Llama al método privado LogTraining para procesar la información recibida
            LogTraining(logTrainingModel);

            // Devuelve la ejecución del método como Ok
            return Ok();
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Obtiene el nombre del cliente para el DNI recibido como parámetro.
        /// </summary>
        /// <param name="dni">DNI del cliente.</param>
        /// <returns>Nombre del cliente.</returns>
        private string GetClientNameInfo(string dni)
        {
            // Nombre del cliente
            string name = string.Empty;

            // Se comprueba el dni y se devuelve el nombre correspondiente
            switch(dni)
            {
                case "21341568":
                    name = "Laura";
                    break;
                case "31342568":
                    name = "Alejandro";
                    break;
                case "41343568":
                    name = "Sergio";
                    break;
                case "61344568":
                    name = "Fran";
                    break;
                case "71345568":
                    name = "Antonio";
                    break;
                case "81346568":
                    name = "Diego";
                    break;
                case "91347568":
                    name = "Carlos";
                    break;
                case "11348568":
                    name = "Ramón";
                    break;
                case "51349568":
                    name = "David";
                    break;
            }

            // Devuelve el nombre del cliente
            return name;
        }

        /// <summary>
        /// Obtiene la lista de máquinas para el entrenamiento recibido como parámetro.
        /// </summary>
        /// <remarks>
        /// Evalúa el identificador de entrenamiento y devuelve la lista de máquinas
        /// correspondientes.
        /// </remarks>
        /// <param name="training">Identificador del entrenamiento.</param>
        /// <returns></returns>
        private List<TrainingModel> GetTrainingList(int training)
        {
            // Variable auxiliar con el modelo
            TrainingModel trainingModel;
            // Inicializa la lista de modelos que devuelve el método
            List<TrainingModel> trainingModelList = new List<TrainingModel>();

            // Se evalúa el entranamiento recibido
            switch(training)
            {
                case 1:
                    // Se crea un modelo
                    trainingModel = new TrainingModel();
                    trainingModel.training = training;
                    trainingModel.machine = "Biceps";
                    // Se añadel el modelo a la lista
                    trainingModelList.Add(trainingModel);
                    // Se crea un modelo
                    trainingModel = new TrainingModel();
                    trainingModel.training = training;
                    trainingModel.machine = "Bike";
                    // Se añadel el modelo a la lista
                    trainingModelList.Add(trainingModel);
                    // Se crea un modelo
                    trainingModel = new TrainingModel();
                    trainingModel.training = training;
                    trainingModel.machine = "Chest";
                    // Se añadel el modelo a la lista
                    trainingModelList.Add(trainingModel);
                    break;
                case 2:
                    // Se crea un modelo
                    trainingModel = new TrainingModel();
                    trainingModel.training = training;
                    trainingModel.machine = "LowerAbs";
                    // Se añadel el modelo a la lista
                    trainingModelList.Add(trainingModel);
                    // Se crea un modelo
                    trainingModel = new TrainingModel();
                    trainingModel.training = training;
                    trainingModel.machine = "PressChest";
                    // Se añadel el modelo a la lista
                    trainingModelList.Add(trainingModel);
                    // Se crea un modelo
                    trainingModel = new TrainingModel();
                    trainingModel.training = training;
                    trainingModel.machine = "Running";
                    // Se añadel el modelo a la lista
                    trainingModelList.Add(trainingModel);
                    break;
                case 3:
                    // Se crea un modelo
                    trainingModel = new TrainingModel();
                    trainingModel.training = training;
                    trainingModel.machine = "Steps";
                    // Se añadel el modelo a la lista
                    trainingModelList.Add(trainingModel);
                    // Se crea un modelo
                    trainingModel = new TrainingModel();
                    trainingModel.training = training;
                    trainingModel.machine = "UpperAbs";
                    // Se añadel el modelo a la lista
                    trainingModelList.Add(trainingModel);
                    // Se crea un modelo
                    trainingModel = new TrainingModel();
                    trainingModel.training = training;
                    trainingModel.machine = "Biceps";
                    // Se añadel el modelo a la lista
                    trainingModelList.Add(trainingModel);
                    break;
            }

            // Return the list of entities
            return trainingModelList;
        }

        /// <summary>
        /// Procesa la información recibida para almacenar el entrenamiento de un cliente.
        /// </summary>
        /// <remarks>
        /// No implementado.
        /// </remarks>
        /// <param name="logTrainingModel"></param>
        private void LogTraining(LogTrainingModel logTrainingModel)
        {
            //TODO: Implementar según lo que queráis comprobar
        }

        #endregion
    }
}