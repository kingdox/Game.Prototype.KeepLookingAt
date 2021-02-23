#region
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo.Get;
using XavHelpTo.Change;
#endregion
public class UIManager : MonoBehaviour
{
    #region Variable 

    [Header("UI Manager")]
    public Text score;
    public Image lifeBar;

    #endregion
    #region Events
    private void Update()
    {
        score.text = $"{GameManager.GetScore()} Pts";

        lifeBar.fillAmount =(
            (float)GameManager.GetLife())
            .PercentOf(GameManager.MAX_LIFE) / 100
        ;

    }
    #endregion
    #region Methods

    #endregion
}
