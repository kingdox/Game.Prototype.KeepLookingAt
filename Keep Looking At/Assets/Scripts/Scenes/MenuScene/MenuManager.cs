#region Usings
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo.Change;
using XavHelpTo.Look;
using XavHelpTo.Know;
using Environment;
#endregion
public class MenuManager : MonoBehaviour
{
    #region Variable

    [Header("Visual")]
    public Text record;
    public Text author;
    public Text version;
    private const string AUTHOR = "Por Xavier Arpa L.";
    [Header("Menu Manager Settings")]
    private const float TIMER_AUTHOR_COLOR = 0.25f;
    private float timerAuthorCount;

    #endregion
    #region Event
    private void Start()
    {
        record.text = $"{Look.InColor(DataPass.GetSavedData().recordPts, Look.RandomColor())} Pts";
        version.text = Data.data.version.InColor(Look.RandomColor());
    }
    private void Update()
    {
        if (TIMER_AUTHOR_COLOR.TimerIn(ref timerAuthorCount))
        {
            author.text = AUTHOR.InColor(Look.RandomColor());
        }
        
    }
    #endregion
    #region Method

    public void ChangeTo(string name) => name.ToScene();

    public void OnApplicationQuit() => Application.Quit();
    #endregion
}