using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanagement : MonoBehaviour
{
    [SerializeField] private GameObject escenaPrincipal;
    [SerializeField] private GameObject escenaAjustes;

    public void Ajustes()
    {
        escenaPrincipal.SetActive(false);
        escenaAjustes.SetActive(true);
    }
    public void Principal()
    {
        escenaPrincipal.SetActive(true);
        escenaAjustes.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
