#region
using UnityEngine;
using XavHelpTo.Get;
using XavHelpTo.Know;
#endregion

//Este paralax solo usa el eje X
public class Parallax : MonoBehaviour
{
    #region Var
    //Atenuaciond el movimiento horizontal
    public float attenX = 0.01f;

    //Atenuacion del movimiento vertical
    public float attenY = 0;

    public float speed;
    [Space]
    public float timeRangeMax;
    //Control de offset de la textura
    private Vector2 pos = Vector2.zero;
    private float count;
    private float timer = 3f;
    //Referencia el renderer del BG
    private Renderer rend;
    #endregion
    #region Events

    private void Start() {
        gameObject.Component(out rend);
        RefreshParallax();
    }
    #endregion
    #region Methods

    private void Update() {

        //cada vez que pasa ese tiempo...
        if (timer.TimerIn(ref count)) RefreshParallax();

        pos += new Vector2(attenX, attenY) * Time.deltaTime * speed;
        rend.material.SetTextureOffset("_MainTex", pos);
    }

    /// <summary>
    /// Updates the parallax with new things..
    /// </summary>
    private void RefreshParallax()
    {
        timer = timeRangeMax.ZeroMax();

        ChangeMinusPlus(ref attenX);
        ChangeMinusPlus(ref attenY);
    }


    /// <summary>
    /// Change sometimes the value - or +
    /// </summary>
    private void ChangeMinusPlus(ref float val) => val = val * (Get.RandomBool() ? 1 : -1);
    #endregion



}
