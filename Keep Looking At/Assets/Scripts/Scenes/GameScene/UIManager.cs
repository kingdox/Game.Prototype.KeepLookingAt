#region
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo.Get;
#endregion
public class UIManager : MonoBehaviour
{
    #region Variable 
    private static UIManager _;
    [Header("UI Manager")]
    public Text score;
    public Image lifeBar;

    #endregion
    #region Events
    private void Awake()
    {
        if (_ == null) _ = this;
    }
    private void OnEnable()
    {
        GameManager.CheckLife += RefreshLifeBar;
        GameManager.CheckScore += RefreshScoreText;
    }
    private void OnDisable()
    {
        GameManager.CheckLife -= RefreshLifeBar;
        GameManager.CheckScore -= RefreshScoreText;
    }
    #endregion
    #region Methods

    /// <summary>
    /// Refreshes the HP life bar
    /// </summary>
    public static void RefreshLifeBar()
    {
        _.lifeBar.fillAmount = (
            (float)GameManager.GetLife())
            .PercentOf(GameManager.MAX_LIFE) / 100
        ;
    }
    /// <summary>
    /// Refreshes the score
    /// </summary>
    public static void RefreshScoreText()
    {
        _.score.text = $"{GameManager.GetScore()} Pts";
    }
    #endregion
}
