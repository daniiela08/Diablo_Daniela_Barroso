using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private MisionToggle[] missionToggles;

    private void OnEnable()
    {
        //suscribirse al evento y vincular al metodo
        eventManager.onNuevaMision += TurnOnToggleMission;
        eventManager.onActualizarMision += UpdateToggleMission;
        eventManager.onNoMision += FinishToggleMission;
    }
    private void OnDisable()
    {
        eventManager.onNuevaMision -= TurnOnToggleMission;
        eventManager.onActualizarMision -= UpdateToggleMission;
        eventManager.onNoMision -= FinishToggleMission;
    }

    private void TurnOnToggleMission(MisionSO mission)
    {
        //texto con el contenido de la misiom
        missionToggles[mission.indiceMision].MissionText.text = mission.mensajeInicial;
        //si tiene repeticion
        if (mission.tieneRepeticion)
        {
            missionToggles[mission.indiceMision].MissionText.text += " (" + mission.repeticionActual + " / " + mission.repeticionesTotales + ")";
        }
        //endender toggle para q se vea en pantalla
        missionToggles[mission.indiceMision].gameObject.SetActive(true);
    }
    private void UpdateToggleMission(MisionSO mission)
    {
        missionToggles[mission.indiceMision].MissionText.text = mission.mensajeInicial;
        missionToggles[mission.indiceMision].MissionText.text += " (" + mission.repeticionActual + " / " + mission.repeticionesTotales + ")";
    }
    private void FinishToggleMission(MisionSO mission)
    {
        //poner el tick en true
        missionToggles[mission.indiceMision].ToggleVisual.isOn = true;
        //poner texto de conseguido
        missionToggles[mission.indiceMision].MissionText.text = mission.mensajeFinal;
    }
}
