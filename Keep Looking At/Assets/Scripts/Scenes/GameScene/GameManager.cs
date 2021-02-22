#region
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo.Change;
#endregion
public class GameManager : MonoBehaviour
{
    #region Variables

    #endregion
    #region Events
    private void Awake()
    {
        
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    #endregion
    #region Methods

    /// <summary>
    /// Change the scene to the named
    /// </summary>
    public void ChangeTo(string name) => name.ToScene();
    #endregion
}
/*
 * TODO Qué nesecitamos?
 * 
 * 
 * Script para mover aleatoriamente en el screen (PERO DEL MUNDO)
 *  - Se puede calcular el tamaño de la screen y transformar los movimientos en porcentajes
 *  - Se puede hacer que pasado cierto tiempo cambie el tamaño basado en el tamaño de la pantalla
 *  - Se puede ahcer que exista un rango de tiempo modificable en el que se cambie la dirección? (?esto no choca con ir a pos permitibles? TODO)
 *  
 *  
 *  
 * Script para ajustar proceduralmente el tamaño
 * 
 * Contador de tiempo y guardado de esta
 *  - Se manejará un timer que contará cada vez que detecte que el jugador esté en contacto con el target, sino se devuelve falso y por ende la perdida de puntos
 *  - Se tendrá un timer que cuando se acaba se termina la partida, de manera de que tienes un lapso de tiempo para resolver el problema
 *  
 * 
 * 
 * Detección del mouse cuando esta encima, podría userse un raycast....
 * 
 * 
 * 
 * 
 */