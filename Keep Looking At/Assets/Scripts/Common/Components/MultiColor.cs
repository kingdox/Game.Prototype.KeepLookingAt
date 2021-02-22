#region imports
using UnityEngine;
using XavHelpTo.Get;
using XavHelpTo.Know;
#endregion
/// <summary>
/// Cambia el "Color deseado" de <see cref="ImageController"/>
/// Cada cierto tiempo
/// <para>Dependencia con <see cref="ImageController"/></para>
/// </summary>
public class MultiColor : MonoBehaviour
{
    #region Variable
    [Header("Settings")]
    public ImageController imgController;
    [Space]
    public Color[] colors;
    [Header("Time")]
    public float tick = 1;
    private float count = 0;

    //guardamos el wanted inicial
    private Color wantedInit;
    public bool isPlaying = true;

    #endregion
    #region Events
    private void Start(){
        if (!imgController) gameObject.Component(out imgController);
        if (!imgController) gameObject.Component(out imgController);

        wantedInit = imgController.color_want;

    }
    private void Update()
    {

        if (isPlaying && tick.TimerIn(ref count))
        {
            ChangeColor();
        }
        else if (!isPlaying && imgController.color_want != wantedInit)
        {
            //asigna el valor del color_want
            imgController.color_want = wantedInit;
        }

    }
    #endregion
    #region Methods
    /// <summary>
    /// Cambiamos a uno de los colores escogidos
    /// </summary>
    public void ChangeColor(){
        imgController.color_want = colors[colors.ZeroMax()];
    }
    #endregion
}
