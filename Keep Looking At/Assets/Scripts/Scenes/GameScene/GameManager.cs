#region
using UnityEngine;
using XavHelpTo.Change;
using XavHelpTo.Know;
using XavHelpTo.Get;
using XavHelpTo.Look;
#endregion
public class GameManager : MonoBehaviour
{
    #region Variables
    [Header("Game Settings")]
    private static GameManager _;

    public int scoreActual = 0;

    private float scoreTimer = .25f;
    private float count = 0;
    [Header("Player Settings")]
    public int life = 0;
    public const int MAX_LIFE = 100;

    private const float LIFE_TIME_CHECK = .08f;
    private float lifeTimeCount = 0;
    private bool isHurt = false;
    #endregion
    #region Events
    private void Awake()
    {
        if (_ == null) _ = this;
    }
    private void Start()
    {
        life = MAX_LIFE;
        count = 0;
    }
    private void Update()
    {
                
        

        
        if (LIFE_TIME_CHECK.TimerIn(ref lifeTimeCount))
        {
            bool isAnyOnHover = false;
            HoverTarget[] targets;
            TargetManager.GetContainerOf(Targets.TARGET).Components(out targets);
            foreach (HoverTarget h in targets)
            {
                if (!isAnyOnHover && h.isHover)
                {
                    isAnyOnHover = true;
                }
            }

            if (!isAnyOnHover)
            {
                isHurt = true;
                SetDamage(1);
            }
            else
            {
                isHurt = false;
            }
        }

        if (!isHurt && scoreTimer.TimerIn(ref count))
        {
            scoreActual++;
        }

        scoreActual = Mathf.Clamp(scoreActual, 0,scoreActual);
    }
    private void LateUpdate()
    {
        CheckGameOver();
    }
    #endregion
    #region Methods


    public void SetDamage(int qty)
    {
        life -= qty;
        life = Mathf.Clamp(life, 0, MAX_LIFE);
    }

    /// <returns>the actual score</returns>
    public static int GetScore() => _.scoreActual;
    /// <returns>the actual Life</returns>
    public static int GetLife() => _.life;

    private void CheckGameOver()
    {
        if (!life.Equals(0)) return;
        SavedData saved = DataPass.GetSavedData();
        saved.recordPts = scoreActual > saved.recordPts ? scoreActual : saved.recordPts;
        DataPass.SetData(saved);
        DataPass.SaveLoadFile(true);

        "MenuScene".ToScene();
        $"GG -> {saved.recordPts}".Print();
        
    }
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