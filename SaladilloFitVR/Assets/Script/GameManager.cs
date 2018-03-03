///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Laura Calvente
// Curso: 2017/2018
// Fichero: GameManager.cs
///////////////////////////////

public static class GameManager {

    // Clave para la direccion IP
    public const string IP_ADDRESS = "IP_ADDRESS";
    // SOLO USO LOCAL. IP
    public static string localhost = "localhost:49446";

    // Variable para almacenar la direccion IP de la Web API
    public static string ipAddress;
    // Variable para almacenar el DNI del usuario
    public static string dni;
    // Variable para almacenar el nombre del usuario
    public static string name;
    // variable para alamcenar el entrenamiento seleccionado
    public static int training;

    // Constante con la URL del metodo de la Web API para comprobar la conectividad
    public const string WEB_API_CHECK_CONECTIVITY = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/CheckConnectivity";
    // (SOLO USO LOCAL) 
    public const string WEB_API_CHECK_CONECTIVITY_LOCAL = "http://{0}/api/SaladilloFitVR/CheckConnectivity";

    // Constante con la URL de la WEb API que contiene una lista de clientes
    public const string WEB_API_GET_CLIENT = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetClientName?dni={1}";
    // (SOLO USO LOCAL)
    public const string WEB_API_GET_CLIENT_LOCAL = "http://{0}/api/SaladilloFitVR/GetClientName?dni={1}";

    // Constante con la URL de la WEb API que guarda la informacion de un cliente
    public const string WEB_API_LOG_TRAINING = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/LogTraining";
    // (SOLO USO LOCAL) 
    public const string WEB_API_LOG_TRAINING_LOCAL = "http://{0}/api/SaladilloFitVR/LogTraining";

    // Constante con la URL de la WEb API que contiene una lista de ejercicios
    public const string WEB_API_GET_TRAINING = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetTraining";
    // (SOLO USO LOCAL) 
    public const string WEB_API_GET_TRAINING_LOCAL = "http://{0}/api/SaladilloFitVR/GetTrainingList?training={1}";
}