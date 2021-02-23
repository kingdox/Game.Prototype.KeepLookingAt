#region Imports
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Environment;
using UnityEngine.EventSystems;
using S = System;
#endregion
//namespace XavLib
//{
/// <summary>
/// Herramientas para facilitar a Xavier contra el codigo
/// <para>Aquí se poseerán funciones unicamente "static"</para>
/// <see cref="XavHelpTo"/> Ultima Actualización => 22 feb 2021
///
/// </summary>
namespace XavHelpTo
    {
        namespace Get
        {
            #region Get
            /// <summary>
            /// Herramienta de obtención de valores
            /// </summary>
            public static class Get{

            /// <summary>
            /// Get the type of the gameobject selected
            /// </summary>
            public static void Component<T>(this GameObject gameobj, out T t) where T : Component
            {
                t = gameobj.GetComponent<T>();
                if (Know.Know.IsNull(t))
                {
                    t = gameobj.AddComponent<T>();
                }
            }
            /// <summary>
            /// TODO - seria bueno hacer que venga ordenado y con corroboración...
            /// Returns the components of this gameobject without any order
            /// </summary>
            public static void ComponentsWithoutOrder<T>(this GameObject gameobj, out T[] t) => t = gameobj.GetComponents<T>();
            /// <summary>
            /// Return the specified component in order from the transform target
            /// </summary>
            public static void Components<T>(this Transform target, out T[] t)
            {
                Set.Set.NewIn(target.childCount, out t);
                for (int x = 0; x < target.childCount; x++)
                {
                    t[x] = target.GetChild(x).GetComponent<T>();
                }
            }
            /// <summary>
            /// Returns the components of this object and this component object whether it have 
            /// </summary>
            public static void ComponentsInChilds<T>(this GameObject gameObject, out T[] t) where T : Component => t = gameObject.GetComponentsInChildren<T>();



            /// <summary>
            /// Assign the value if is finded, else null
            /// <para>Returns true if it was finded</para>
            /// </summary>
            public static bool ChildWithTag(this Transform target, string tag, ref Transform t)
            {
                bool finded = false;
                for (int i = 0; i < target.childCount; i++)
                {
                    Transform child = target.GetChild(i);
                    if (child.CompareTag(tag))
                    {
                        t = child;
                        finded = true;
                        break;
                    }
                }

                if (!finded) t = null;

                return finded;
            }






            /// <summary>
            /// Devuelve el ancho del porcentaje para conocerlo basado en la pantalla
            /// <para>Usa <seealso cref="KnowPercentOfMax(float, float)"/></para>
            /// </summary>
            public static float ScreenWidth(this float w) => QtyOf(w, Screen.width);
                /// <summary>
                /// Devuelve el ancho del porcentaje para conocerlo basado en la pantalla
                /// <para>Usa <seealso cref="KnowPercentOfMax(float, float)"/></para>
                /// </summary>
                public static float ScreenHeight(this float h) => QtyOf(h, Screen.height);

                /// <summary>
                /// Devuelve el ancho y alto del vector de porcentaje basado enla pantalla
                /// <para>Usa <seealso cref="GetWidthOf(float)"/> y <seealso cref="GetHeightOf(float)"/></para>
                /// </summary>
                public static Vector2 ScreenSize(this Vector2 s) => new Vector2(s.x.ScreenWidth(), s.y.ScreenHeight());

                /// <summary>
                /// sacas el alto de una camara o la camara activa por defecto
                /// </summary>
                /// <para>Dependencia con <seealso cref="Camera"/> </para>
                /// <returns>el alto de <seealso cref="Camera"/> en unidades de Unity</returns>
                public static float ScreenHeightUnit(Camera camera = null) => camera ? camera.orthographicSize * 2f : Camera.main.orthographicSize * 2f;

                /// <summary>
                /// Sacas el ancho de la pantalla basado en el alto de la camara 
                /// <para>Dependencia con <seealso cref="Screen"/> </para>
                /// </summary>
                /// <returns>el Ancho de <seealso cref="Camera"/> en unidades Unity</returns>
                public static float ScreenWidthUnit(float camHeight) => camHeight * (Screen.width / Screen.height);

                /// <summary>
                ///  Saca el porcentaje de la cantidad y el maximo en caso de tener
                /// </summary>
                /// <returns>El porcentaje de count sobre el max</returns>
                public static float PercentOf(this float count, float max) => count / max * 100;
                public static int PercentOf(this int count, int max) => count / max * 100;
                public static float PercentOf(this float[] c) => c[0].PercentOf(c[1]);
                public static Vector2 PercentOf(this Vector2 count, Vector2 max) => count / max * 100;


            /// <summary>
            /// Basado en el porcentaje obtienes el valor mediante un maximo establecido
            /// </summary>
                public static float QtyOf(this float percent, float max) => (max / 100) * percent;
                public static Vector2 QtyOf(this Vector2 percent, Vector2 max) => (max / 100) * percent;
                /// <summary>
                /// Obtienes el valor del rango dado 
                /// </summary>
                public static float Range(float[] range) => Random.Range(range[0], range[1]);
                public static int Range(int[] range) => Random.Range(range[0], range[1]);
                public static float Range(Vector2 range) => Random.Range(range[0], range[1]);

            public static T Range<T>(params T[] range) => range[ZeroMax(range.Length)];

            /// <summary>
            /// Tomas el valor entre el -valor y ell valor,
            /// </summary>
            public static float MinusMax(float max) => Random.Range(-max, max);

                public static Vector3 MinusMax(Vector3 pos, float range, int blocked = -1){

                    for (int x = 0; x < 3; x++){
                        if (blocked != x){
                            pos[x] += MinusMax(range);
                        }
                    }
                    return pos;
                }

                /// <summary>
                /// Tomas el valor entre el 0 y el maximo
                /// </summary>
                /// <returns></returns>
                public static int ZeroMax(this int max) => Random.Range(0, max);
                public static float ZeroMax(this float max) => Random.Range(0, max);
                public static int ZeroMax<T>(this T[] arr) => arr.Length.ZeroMax();


           
            /// <summary>
            /// TODO revisar
            /// Coloca el valor puesto en caso de que sea null
            /// </summary>
            public static void Default<T>(this T value, T defaultVal) => value = Know.Know.IsNull(value) ? defaultVal : value;

            /// <summary>
            /// Sumamos los valores de un arreglo
            /// </summary>
            public static float SummAll(params float[] values){
                    float c = 0;
                    foreach (float val in values){c += val;}
                    return c;
                }
                public static float SummAll(this Vector3 values) => SummAll(Change.Change.ToArray(values));


                /// <summary>
                /// Gets a random boolean
                /// </summary>
                public static bool RandomBool() => Random.Range(0, 2) == 0;
        }

        #endregion
        }
        namespace Set
        {
        #region Set
        /// <summary>
        /// Herramienta para modificación del valor,devolviendo los cambios hechos al valor
        /// </summary>
        public static class Set
        {
            /// <summary>
            /// Añade un string a un arreglo de strings.
            /// </summary>
            public static T[] Push<T>(T value, params T[] values)
            {
                T[] newArr = new T[values.Length + 1];
                for (int x = 0; x < newArr.Length; x++) newArr[x] = (x == newArr.Length - 1) ? value : values[x];
                return newArr;
            }
            /// <summary>
            /// Pushes the array with the news values in the last
            /// </summary>
            public static T[] PushIn<T>(this T t, params T[] ts) => Set.Push(t, ts);

            /// <summary>
            /// Creas una nueva dimension de arreglo del tipo que desees
            /// </summary>
            public static T[] NewIn<T>(this int qty, out T[] t) => t = new T[qty];

            /// <summary>
            /// Check the status of a static reference of an object as a Singleton
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="_"></param>
            /// <param name="this"></param>
            /// <param name="gameObject"></param>
            public static void Singletone<T>(this GameObject @gameObject, ref T @_, T @this)
            {
                if (@_ == null)
                {
                    Object.DontDestroyOnLoad(@gameObject);
                    @_ = @this;
                }
                else if (!Equals(@_, @this))//@_ != @this
                {
                    Object.Destroy(@gameObject);
                }
            }
            /// <summary>
            /// Asignas el valor a positivo en caso de ser negativo
            /// </summary>
            public static float Positive(this float f) => f < 0 ? f * -1 : f;
            public static Vector2 Positive(this Vector2 f) => new Vector2(f.x.Positive(), f.y.Positive());
            public static float[] Positive(params float[] f) {
                for (int x = 0; x < f.Length; x++) f[x].Positive();
                return f;
            }

            //public static float Positive(params float[] f) => 

            /// <summary>
            /// Obtenemos el valor dentro de los limites de la unidad de 0 y 1
            /// <para>tambien puede psoeer decimales</para>
            /// </summary>
            public static float InUnitBounds(float v) => Mathf.Clamp(v, 0, 1);

            //int start = 0, int end = -1, string startText = "") {for (int x = start; x < (end.Equals(-1) ? text.Length : end + 1); x++) startText += text[x];return startText; }
            /// <summary>
            /// Une los caracteres de un arreglo de caracteres , puediendo añadir indices de inicio y fin
            /// <para>se puede implementar un texto inicial</para>
            /// </summary> 
            public static string Join(this string text, int start = 0, int end = -1, string startText = "") { for (int x = start; x < (end.Equals(-1) ? text.Length : end + 1); x++) startText += text[x]; return startText; }
            public static string Join(string[] texts, string startText = "") { for (int x = 0; x < texts.Length; x++) startText += texts[x]; return startText; }


            /// <summary>
            /// Buscamos el parametro del <see cref="Color"/> que vas a cambiar
            /// <para>  el parametro debe estar entre los rangos de los parametros de color</para>
            /// <para>  [R == 0,G == 1,B == 2,A == 3] --> iniciando en 0.</para>
            /// <para>   Si i es == -1 entonces aplica a (RGB)</para>
            /// <para>Dependencia con <seealso cref="Color"/> </para>
            /// </summary>
            /// <returns>Devuelve el <see cref="Color"/> con los cambios</returns>
            public static Color ColorParam(this Color c, int i, float val = 1)
            {
                //Si esta fuera de los limites del arreglo
                if (!Know.Know.IsOnBounds(i, 4))
                {
                    if (i == -1)
                    {
                        for (int x = 0; x < 3; x++) c[x] = val;
                    }
                    else
                    {
                        Debug.LogError($"<color=red>Indice errado ?</color>, favor usar un enum de parametros de color o usarlo bien :(");
                    }
                }
                else c[i] = val;

                return c;
            }
            public static void ColorParam(ref Image img, ColorType i, float val = 1)
            {
                Color c = img.color;
                img.color = ColorParam(c, (int)i, val);
            }


            /// <summary>
            /// Actualizamos el arreglo para que posea el mismo tamaño que el nuevo,
            /// estos cambios pueden eliminar o añadir huecos, los nuevos iniciarán en 0
            /// </summary>
            public static float[] Length(float[] oldArr, int newLength)
            {

                //Si es igual no se hace nada
                if (oldArr.Length == newLength) return oldArr;


                //revisamos quién es mas grande
                bool condition = oldArr.Length > newLength;

                float[] newArr = new float[condition
                    ? (oldArr.Length - newLength)
                    : (newLength)
                ];


                //si hay menos datos llenamos el nuevo arreglo
                //Puede que perdamos algunos valores
                if (condition)
                {
                    for (int z = 0; z < newArr.Length; z++) newArr[z] = oldArr[z];
                }
                else
                {
                    for (int z = 0; z < newArr.Length; z++)
                    {
                        newArr[z] = z < oldArr.Length - 1
                            ? oldArr[z]
                            : 0
                        ;
                    }
                }

                return newArr;
            }
            /// <summary>
            /// Hacemos que el valor cambio dentro de un margen de tiempo,
            /// <para>
            /// si este valor se sobrepasa entre 0 y 1 los ajusta
            /// </para>
            /// </summary>
            public static float UnitInTime(float value, float toMax, float timeScale = 1) => Set.InUnitBounds(Mathf.MoveTowards(value, toMax, Time.deltaTime * timeScale * Set.Positive(toMax - value)));

           


                /// <summary>
                /// Llenamos un arreglo con el valor escogido
                /// </summary>
                public static T[] FillWith<T>(T tValue, params T[] ts)
                {
                    for (int x = 0; x < ts.Length; x++)
                    {
                        ts[x] = tValue;
                    }
                    return ts;
                }
                public static T[] FillWith<T>(T tValue, int qty) => FillWith(tValue, new T[qty]);



                /// <summary>
                /// Cambiamos los valores que son iguales de su mismo arreglo, cambiandolos con alguno entre el maximo
                /// <para> Devuelve un arreglo con los valores pero distintos en caso de encontrar repetidos</para>
                /// </summary>
                public static int[] DifferentIndexInEquals(int[] arr, int max)
                {
                    //recorremos el arreglo que vamos a buscar distinciones
                    for (int i = 0; i < arr.Length; i++)
                    {
                        //almacenamos el indice a buscar
                        int indexToFind = arr[i];
                        //limpiamos el arreglo por buscar
                        arr[i] = -1;

                        if (indexToFind < max)
                        {
                            //revisamos si el indice a buscar está entre los demás achievements
                            while (Know.Know.IsEqualOf(indexToFind, arr))
                            {
                                indexToFind = Know.Know.DifferentIndex(max, indexToFind);
                            }
                        }
                        else
                        {
                            Debug.LogError("El Indice a buscar es superior al indice maximo permitido !");
                        }

                        arr[i] = indexToFind;
                    }

                    return arr;
                }

            }
            #endregion
        }
        namespace Change
        {
            #region Change
        /// <summary>
        /// Herramienta para la alteración de cosas
        /// </summary>
        public static class Change{
                /// <summary>
                /// Cambiamos a la escena indicada en numerico
                /// </summary>
                /// <param name="index"></param>
                public static void SceneTo(int index) => SceneManager.LoadScene(index);
                public static void SceneTo(string name) => SceneManager.LoadScene(name);
                public static void ToScene(this int i) => Change.SceneTo(i);
                public static void ToScene(this string i) => Change.SceneTo(i);
                /// <summary>
                /// Activa o desactiva el <seealso cref="GameObject"/> basado en una condición
                /// <para>Dependencia con <seealso cref="GameObject"/> </para>
                /// </summary>
                public static void ActiveObject(GameObject obj, bool condition) => obj.SetActive(condition);
                /// <summary>
                /// Activa unicamente el objeto indicado del arreglo
                /// <para>Por defecto el indice es el primero del arreglo</para>
                /// <para>Dependencia con <seealso cref="ObjOnOff(GameObject, bool)"/> </para>
                /// </summary>
                public static void ActiveObjectsExcept(GameObject[] arr, int index = 0) { for (int x = 0; x < arr.Length; x++) ActiveObject(arr[x], x == index); }
                public static void ActiveObjectsExcept(int index, params GameObject[] arr) { for (int x = 0; x < arr.Length; x++) ActiveObject(arr[x], x == index); }

                /// <summary>
                /// Dependiendo de la condición determinamos si iniciar o apagar la animación
                /// <para>Dependencia con <seealso cref="ParticleSystem"/> </para>
                /// </summary>
                public static void ActiveParticle(ParticleSystem particle, bool condition)
                {
                    if (condition && particle.isStopped) particle.Play();
                    else if (!condition && particle.isPlaying) particle.Stop();
                }

                public static void ActiveAudioSource(AudioSource audio,bool condition)
                {
                    //si está sonando y se quiera desactivar
                    if (audio.isPlaying && !condition) audio.Stop();
                    //sino si NO esta sonando y se quiere encender...
                    else if (!audio.isPlaying && condition) audio.Play();

                }

                
                /// <summary>
                /// Cambia los valores del vector a un arreglo con estos
                /// </summary>
                public static float[] ToArray(Vector3 v) => new float[] {v[0], v[1], v[2] };


                //public static int ToFloat(this int val) => Mathf.Round(val /2);
                /// <summary>
                /// Cambia  a int su valor
                /// </summary>
                public static int ToInt(this bool condition) => condition ? 1 : 0;
                public static int ToInt(this float val) => (int)val;
                public static int ToInt(this S.Enum @enum) => S.Convert.ToInt32(@enum);
                public static int ToInt<T>(this T t)
                {
                int result = -1;
                if (Know.Know.IsEnum(t))
                {
                    return (S.Enum.Parse(typeof(T), t.ToString()) as S.Enum).ToInt();
                }
                else Look.Look.Print("NO ES UN ENUM:::: dejo en -1");
                
                return result;
                }

                public static int[] ToInt<T>(this T[] t)
                {
                    int[] ints = new int[t.Length]; //Set.Set.FillWith(-1,t.Length)

                    for (int x = 0; x < t.Length; x++)
                    {
                        ints[x] = t[x].ToInt();
                    }

                    return ints;
                }
        }
            #endregion
        }
        namespace Know
        {
            #region Know
            /// <summary>
            /// Herramienta que devuelve valores booleanas o de indexación (hay excepciones..)
            /// </summary>
            public static class Know
            {

                /// <summary>
                /// Preguntamos si es nulo el valor indicado
                /// </summary>
                public static bool IsNull<T>(T t) => t == null;

            /// <summary>
            /// Check if the value is an Enumerator
            /// </summary>
            public static bool IsEnum<T>(this T t) => typeof(T).IsEnum;
                /// <summary>
                /// Devuelve el nombre de la escena activa
                /// <para>Dependencia con <seealso cref="Scenes"/> </para>
                /// </summary>
                public static Scenes ActiveScene() => (Scenes)SceneManager.GetActiveScene().buildIndex;
                /// <summary>
                /// Revisa si el objeto está seleccionado
                /// </summary>
                public static bool Focus(GameObject obj) => obj.Equals(EventSystem.current.currentSelectedGameObject);
            
                /// <summary>
                /// Detecta si el indice está dentro del arreglo
                /// </summary>
                public static bool IsOnBounds(int i, int length) => i == Mathf.Clamp(i, 0, length - 1);
                public static bool IsOnBounds(int i, int length, bool direction) => i == Mathf.Clamp(i + (direction ? 1 : -1) , 0, length - 1);
            
            /// <summary>
            /// Check if one of the values from the array are equal
            /// </summary>
            public static bool IsEqualOf<T>(this T value, params T[] vals) { foreach (T val in vals) if (value.Equals(val)) return true; return false; }

            /// <summary>
            /// Detecta el primer caracter de los buscados en el arreglo
            /// <para>Podemos tener un indice inicial</para>
            /// <para>Devuelve -1 si no encuentra</para>
            /// <para>Dependencia con <see cref="IsEqualOf(char, char[])"/> para hacer más de una busqueda</para>
            /// </summary>
            public static int IndexOf<T>( T[] ts, int startIndex, params T[] finder){for (int x = startIndex; x < ts.Length; x++) if (ts[x].IsEqualOf(finder)) return x; return -1;}
                public static int IndexOf(char[] chars, int startIndex, params char[] finder) { for (int x = startIndex; x < chars.Length; x++) if (chars[x].IsEqualOf(finder)) return x; return -1; }
                public static int IndexOf(string text, int startIndex, params char[] finder) { for (int x = startIndex; x < text.Length; x++) if (text[x].IsEqualOf(finder)) return x; return -1; }
                public static int IndexOf<T>(T t, int startIndex, params T[] finder) { for (int x = startIndex; x < finder.Length; x++) if (t.IsEqualOf(finder)) return x; return -1; }

            /// <summary>
            /// Busca en un arreglo y si encuentra, muestra donde
            /// <para> caso contrario devuelve -1 </para>
            /// </summary>
            public static int FocusIndex(params GameObject[] objs)
                {
                    for (int x = 0; x < objs.Length; x++) if (objs.Equals(EventSystem.current.currentSelectedGameObject)) return x;
                    return -1;
                }
                /// <summary>
                /// Busca cual es el valor del arreglo que supera al indicado
                /// <para>Retorna -1 si no encuentra alguno mayor que el mostrado</para>
                /// </summary>
                public static int FirstMajor(float val, float[] arr)
                {
                    for (int x = 0; x < arr.Length; x++) if (val < arr[x]) return x;
                    return -1;
                }
                /// <summary>
                /// Conoces el siguiente indice basado en la longitud del arreglo
                /// <para>Se le puede definir un inicio en caso de haber</para>
                /// </summary>
                public static int NextIndex(bool goNext, int indexLength, int index = 0) => goNext ? (index == indexLength - 1 ? 0 : index + 1) : (index == 0 ? indexLength - 1 : index - 1);
                /// <summary>
                /// Retorna un valor distinto al ultimo suponiendo que la dimension es mayor a 1
                /// </summary>
                public static int DifferentIndex(int max, int lastInt = -1)
                {
                    int _newInt = lastInt;

                    while (lastInt == _newInt && max > 1)
                    {
                        _newInt = Get.Get.ZeroMax(max);
                    }

                    return _newInt;
                }
                /// <summary>
                /// Devolvemos en un arreglo los 4 puntos para tomar una etiqueta. 
                /// <para>Estas etiqutas SOLO manejan 1 nivel de profundidad</para>
                /// </summary>
                public static int[] IndexsOfTag(string text, int index_Start = -1){
                    if (index_Start.Equals(-1)) index_Start = Know.IndexOf(text,0,'<');
                    //creamos el espacio
                    int[] tagIndex = { index_Start, -1,-1,-1 };
                    int tagNameLength;

                    //'>', si encuentra un '=' se tendrá que hacer un reajuste luego...
                    tagIndex[1] = Know.IndexOf(text, index_Start, '=', '>');

                    tagNameLength = Set.Set.Join(text, index_Start, tagIndex[1] - 1).Length;

                    if (text[tagIndex[1]].Equals('='))
                    {
                        // '>'
                        tagIndex[1] = Know.IndexOf(text, tagIndex[1], '>');

                    }
                    // '<'
                    tagIndex[2] = Know.IndexOf(text, tagIndex[1], '<');

                    // '>'
                    tagIndex[3] = tagIndex[2] + tagNameLength + 1;

                    return tagIndex;
                }

                /// <summary>
                /// Based on a cooldown, updates the timer and returns true if pass the cooldown
                /// </summary>
                public static bool TimerIn(this float cooldown, ref float count)
                {
                    count = (count + Time.deltaTime);
                    bool result = count > cooldown;
                    if (result) count = 0;
                    return result;
                }
                /// <summary>
                /// Permite activar el flag "can"___ para poder volver a usarlo, este se mide por tiempo
                /// </summary>
                public static bool TimerFlag(this float timer, ref bool flag, ref float count)
                {
                    if (!flag &&  timer.TimerIn(ref count))
                    {
                        flag = true;
                    }
                    return flag;
                }

            }
            #endregion
        }
        namespace Look
        {
            #region Debug
            /// <summary>
            /// Herramienta para facilitar a xavier su progreso en debug.
            ///  Tambien está para visualizar cosas mejor.
            ///  posee cosas esteticas....
            /// </summary>
            public static class Look
            {
                /// <summary>
                /// Gets the value with a concrete color 
                /// </summary>
                public static string InColor<T>(this T value, string color="red") => $"<color={color}>{value}</color>";

                /// <summary>
                /// Pintamos un mensaje con color
                /// </summary>
                public static void PrintColor<T>(T value,string color="green") => Debug.Log(InColor(value, color));

                /// <summary>
                /// Indicador decorativo de que andas debugeando algo, solo apoyo visual
                /// </summary>
                public static string Debugging() =>  InColor("DEBUG: ", RandomColor());
                /// <summary>
                /// Debugs a thing 
                /// </summary>
                public static void Print<T>(this T s ) => Debug.Log($"{Debugging()} {s}");
                /// <summary>
                /// Selector aleatorio de color, pretenden para debug, no para manejos de otras cosas..
                /// </summary>
                public static string RandomColor() => Get.Get.Range("green", "red", "magenta", "white","yellow");
                /// <summary>
                /// Leemos en consola un arreglo de strings
                /// </summary>
                public static void Array<T>(params T[] strings) { foreach (T s in strings) Debug.Log($"{Debugging()} {s}");}

              
            }
            #endregion
        }
}
#region Committed
//TEST
//public readonly struct Operate
//{
//    public static Operate operator ~(Operate i) => new Operate();
//}
/*
 //public static T operator +<T>(T a) => a;
        //public static float operator ^(float a) => aa;
        public static bool operator (Craft a, ItemContent i) => a.Equals(i);
 */
#endregion