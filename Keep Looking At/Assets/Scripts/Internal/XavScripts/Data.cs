#region Imports
using UnityEngine;
#endregion

namespace Environment
{
    #region Environment
    /// <summary>
    /// Representa los datos basicos del enviroment
    /// </summary>
    public class Data 
    {
        [HideInInspector]
        public static Data data = new Data();

        public readonly string savedPath = "saved2.txt";
        public readonly string version = "v1.0.5";

    }
    #endregion
    #region Enums
    /// <summary>
    /// Enumerador de los nombres de las escenas de este proyecto
    /// Estos se colocan manualmente...
    /// </summary>
    public enum Scenes
    {
        MenuScene, //el menu principal apra acceder a los demás sitios
        GameScene, //Pantalla de juego

    }
    /// <summary>
    /// Son las llaves que posee el jugador en este proyecto
    /// </summary>
    public enum KeyPlayer
    {
      
    }
    #endregion
}


/// <summary>
/// Identificador de los colores
/// es solo un facilitador...
/// </summary>
public enum ColorType
{
    r,
    g,
    b,
    a,
    RGB = -1
}