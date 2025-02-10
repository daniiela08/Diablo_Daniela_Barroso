using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MisionToggle : MonoBehaviour
{
    [SerializeField] private TMP_Text missionText;

    private Toggle toggleVisual;

    public TMP_Text MissionText { get => missionText; }
    public Toggle ToggleVisual { get => toggleVisual; }

    private void Awake()
    {
        toggleVisual = GetComponent<Toggle>();
    }
}
