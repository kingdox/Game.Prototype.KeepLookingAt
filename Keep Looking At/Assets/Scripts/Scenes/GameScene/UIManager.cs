#region
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo.Get;
using XavHelpTo.Set;
using XavHelpTo.Change;
#endregion
public class UIManager : MonoBehaviour
{
    #region Variable 
    private static UIManager _;
    [Header("UI Manager")]
    public Text score;
    public Image lifeBar;
    public Image HUD_BG;
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

        RefreshHUD_BG();
    }

    public static void RefreshHUD_BG()
    {
        float val = _.lifeBar.fillAmount - 1;
        _.HUD_BG.color = _.HUD_BG.color.ColorParam(ColorType.a.ToInt(), val.Positive().Min(0.2f));
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
