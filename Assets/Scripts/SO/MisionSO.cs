using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mision")]
public class MisionSO : ScriptableObject
{
    public string mensajeInicial;
    public string mensajeFinal;
    public bool tieneRepeticion;
    public int repeticionesTotales;
    public int indiceMision;
    [NonSerialized]
    public int repeticionActual;
}
