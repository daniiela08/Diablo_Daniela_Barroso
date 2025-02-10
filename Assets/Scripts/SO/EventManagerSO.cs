using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Event manager")]
public class EventManagerSO : ScriptableObject
{
    public event Action<MisionSO> onNuevaMision;
    public event Action<MisionSO> onActualizarMision;
    public event Action<MisionSO> onNoMision;

    public void NuevaMision(MisionSO mision)
    {
        onNuevaMision?.Invoke(mision);
    }
    public void ActualizarMision(MisionSO mision)
    {
        onActualizarMision?.Invoke(mision);
    }
    public void FinMision(MisionSO mision)
    {
        onNoMision?.Invoke(mision);
    }
}
