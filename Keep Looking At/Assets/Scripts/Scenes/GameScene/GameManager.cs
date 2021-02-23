#region
using UnityEngine;
using XavHelpTo.Change;
using XavHelpTo.Know;
using XavHelpTo.Get;
using XavHelpTo.Set;
using XavHelpTo.Look;
using System;
#endregion
public class GameManager : MonoBehaviour
{
    #region Variables
    [Header("Game Settings")]
    private static GameManager _;

    public int scoreActual = 0;

    private const float SCORE_TIME_CHECK = .05f;
    private float count = 0;
    [Header("Player Settings")]
    public int life = 0;
    public const int MAX_LIFE = 100;

    private const float LIFE_TIME_CHECK = .04f;
    private float lifeTimeCount = 0;
    //private bool isHurt = false;
    [Header("Events")]

    public static Action CheckScore;
    public static Action CheckLife;

    [Space]
    public static Action CheckHovers;

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

        //Actualiza los que están en el score 
        if (LIFE_TIME_CHECK.TimerIn(ref lifeTimeCount))
        {
            CheckLife?.Invoke();

            //Pierdes vida si no hay nadie mirando
            if (CheckHovers?.GetInvocationList().Length == null)
            {
                AddInLife(-1);
            }
        }
        if (SCORE_TIME_CHECK.TimerIn(ref count))
        {
            //scoreActual++;
            CheckScore?.Invoke();
            //scoreActual = Mathf.Clamp(scoreActual, 0, scoreActual);
        }
    }
    #endregion
    #region Methods

    /// <summary>
    /// Add or remove scorepoints
    /// </summary>
    public static void AddInScore(int value)
    {
        _.scoreActual += value;
        _.scoreActual = _.scoreActual.Min(0);

    }
    /// <summary>
    /// Add or remove life
    /// </summary>
    public static void AddInLife(int qty)
    {
        _.life += qty;
        _.life = Mathf.Clamp(_.life, 0, MAX_LIFE);
        _.CheckGameOver();
    }

    /// <returns>the actual score</returns>
    public static int GetScore() => _.scoreActual;
    /// <returns>the actual Life</returns>
    public static int GetLife() => _.life;

    private void CheckGameOver()
    {
        if (!life.Equals(0)) return;

        Time.timeScale = 0;

        SavedData saved = DataPass.GetSavedData();
        saved.recordPts = scoreActual > saved.recordPts ? scoreActual : saved.recordPts;
        DataPass.SetData(saved);
        DataPass.SaveLoadFile(true);

        "MenuScene".ToScene();
        
    }

    
    #endregion
}