using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [Header("Son")]
    [SerializeField] private AudioSource buttonClickSound;

    [Header("Panels")]
    [SerializeField] private GameObject panelHistoire;
    [SerializeField] private GameObject panelControles;
    [SerializeField] private GameObject panelPrincipesJeu;
    [SerializeField] private GameObject panelTempetesSolaires;
    [SerializeField] private GameObject panelSeisme;
    [SerializeField] private GameObject panelIntemperies;

    [Header("Buttons")]
    [SerializeField] private GameObject nextButtonHistoire;
    [SerializeField] private GameObject nextButtonPanelControles;
    [SerializeField] private GameObject closeButtonPrincipesJeu;
    [SerializeField] private GameObject closeButtonSeisme;
    [SerializeField] private GameObject closeButtonIntemperies;
    [SerializeField] private GameObject closeButtonTempetesSolaires;

    [Header("WaveManager parameter")]
    [SerializeField] private WaveManager waveManager;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        panelHistoire.SetActive(true);
        panelControles.SetActive(false);
        panelPrincipesJeu.SetActive(false);
        panelIntemperies.SetActive(false);
        panelSeisme.SetActive(false);
        panelTempetesSolaires.SetActive(false);
        EventSystem.current.SetSelectedGameObject(nextButtonHistoire);
    }

    // Update is called once per frame
    void Update()
    {
        switch (waveManager.WaveIndex)
        {
            case 0:
                SeismPanel();
                break;
            case 1:
                CloudPanel();
                break;
            case 2:
                SolarflarePanel();
                break;
        }
    }

    public void NextButtonHistoire()
    {
        PlayClickSound();
        panelHistoire.SetActive(false);
        panelControles.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(nextButtonPanelControles);
    }

    public void NextButtonPanelControles()
    {
        PlayClickSound();
        panelControles.SetActive(false);
        panelPrincipesJeu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(closeButtonPrincipesJeu);
    }

    public void CloseButtonPrincipesJeu()
    {
        PlayClickSound();
        panelPrincipesJeu.SetActive(false);
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void SeismPanel()
    {
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(closeButtonSeisme);
        panelSeisme.SetActive(true);
    }

    public void CloudPanel()
    {
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(closeButtonIntemperies);
        panelIntemperies.SetActive(true);
    }

    public void SolarflarePanel()
    {
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(closeButtonTempetesSolaires);
        panelTempetesSolaires.SetActive(true);
    }

    public void CloseButtonSeisme()
    {
        PlayClickSound();
        panelSeisme.SetActive(false);
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void CloseButtonIntemperies()
    {
        PlayClickSound();
        panelIntemperies.SetActive(false);
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void CloseButtonTempetesSolaires()
    {
        PlayClickSound();
        panelTempetesSolaires.SetActive(false);
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void PlayClickSound()
    {
        buttonClickSound.Play();
    }
}
