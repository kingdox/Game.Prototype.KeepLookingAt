#region Usings
using UnityEngine;
using XavHelpTo.Change;
#endregion
public class MenuManager : MonoBehaviour
{
    #region Variable

    #endregion
    #region Event
    private void Awake()
    {
        //1f.ScreenHeight();
        //1f.ScreenWidth();

    }
    #endregion
    #region Method

    public void ChangeTo(string name) => name.ToScene();

    public void OnApplicationQuit() => Application.Quit();
    #endregion
}