using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanagement : MonoBehaviour
{
    [SerializeField] private GameObject escenaPrincipal;
    [SerializeField] private GameObject escenaAjustes;
    [SerializeField] private GameObject escenaHistoria;
    [SerializeField] private GameObject escenaControles;

    public void Ajustes()
    {
        escenaPrincipal.SetActive(false);
        escenaHistoria.SetActive(false);
        escenaControles.SetActive(false);
        escenaAjustes.SetActive(true);
    }
    public void Principal()
    {
        escenaPrincipal.SetActive(true);
        escenaHistoria.SetActive(false);
        escenaControles.SetActive(false);
        escenaAjustes.SetActive(false);
    }
    public void Historia()
    {
        escenaPrincipal.SetActive(false);
        escenaAjustes.SetActive(false);
        escenaHistoria.SetActive(true);
        escenaControles.SetActive(false);
    }
    public void Controles()
    {
        escenaPrincipal.SetActive(false);
        escenaAjustes.SetActive(false);
        escenaHistoria.SetActive(false);
        escenaControles.SetActive(true);
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
