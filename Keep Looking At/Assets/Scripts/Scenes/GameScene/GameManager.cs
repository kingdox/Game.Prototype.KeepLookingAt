#region
using UnityEngine;
using XavHelpTo.Change;
using XavHelpTo.Know;
using XavHelpTo.Look;
using XavHelpTo.Get;
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
    [Space]
    public static Vector2 screenSize;

    [Header("Events")]

    public static Action CheckScore;
    public static Action CheckLife;

    [Space]
    public static Action CheckHovers;

    [Header("Items Settings")]
    public GameObject pref_item;
    public Transform @Items;

    [Space]
    private readonly Vector2 ITEM_TIMER_RANGE = new Vector2(5, 15);
    private float itemTimerActual=0;
    private float itemTimerCount = 0;
    [Space]
    private Camera cam;

    #endregion
    #region Events
    private void Awake()
    {
        if (_ == null) _ = this;
        Time.timeScale = 1f;
        cam = Camera.main;
        RefreshCamera();
    }
    private void Start()
    {
        life = MAX_LIFE;
        count = 0;

        
    }
    private void Update()
    {
        RefreshCamera();

        // > LIFE
        if (LIFE_TIME_CHECK.TimerIn(ref lifeTimeCount))
        {
            CheckLife?.Invoke();

            //Pierdes vida si no hay nadie mirando
            if (CheckHovers?.GetInvocationList().Length == null)
            {
                AddInLife(-1);
            }
        }
        // > SCORE
        if (SCORE_TIME_CHECK.TimerIn(ref count))
        {
            CheckScore?.Invoke();
        }
        // > ITEM
        if (itemTimerActual.TimerIn(ref itemTimerCount))
        {
            itemTimerActual = ITEM_TIMER_RANGE.y.ZeroMax().Min(ITEM_TIMER_RANGE.x);

            Instantiate(pref_item,@Items);
        }
    }
    #endregion
    #region Methods

    /// <summary>
    /// Refreshes the camera
    /// </summary>
    private void RefreshCamera()
    {
        screenSize = Get.RectScreen() / 2;
        Vector2 scale = (Vector2.one * cam.aspect);
        Vector3 _scale = new Vector3(scale.x, scale.y, 1);
        cam.transform.localScale = _scale;
    }

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

        Time.timeScale = 0.5f;

        SavedData saved = DataPass.GetSavedData();
        saved.recordPts = scoreActual > saved.recordPts ? scoreActual : saved.recordPts;
        DataPass.SetData(saved);
        DataPass.SaveLoadFile(true);

        "MenuScene".ToScene();
        Time.timeScale = 1;


    }


    #endregion
}