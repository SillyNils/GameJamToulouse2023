using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [Header("Son")]
    [SerializeField] private AudioManager _audioManager;

    [Header("Panels")]
    [SerializeField] private GameObject panelHistoire;
    [SerializeField] private GameObject panelControles;
    [SerializeField] private GameObject panelPrincipesJeu;
    [SerializeField] private GameObject panelTempetesSolaires;
    [SerializeField] private GameObject panelSeisme;
    [SerializeField] private GameObject panelIntemperies;
    [SerializeField] private GameObject _panelGameOver;

    [Header("Buttons")]
    [SerializeField] private GameObject nextButtonHistoire;
    [SerializeField] private GameObject nextButtonPanelControles;
    [SerializeField] private GameObject closeButtonPrincipesJeu;
    [SerializeField] private GameObject closeButtonSeisme;
    [SerializeField] private GameObject closeButtonIntemperies;
    [SerializeField] private GameObject closeButtonTempetesSolaires;
    [SerializeField] private GameObject _boutonMenu;

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
        _panelGameOver.SetActive(false);
        EventSystem.current.SetSelectedGameObject(nextButtonHistoire);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextButtonHistoire()
    {
        _audioManager.PlayClickSound();
        panelHistoire.SetActive(false);
        panelControles.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(nextButtonPanelControles);
    }

    public void NextButtonPanelControles()
    {
        _audioManager.PlayClickSound();
        panelControles.SetActive(false);
        panelPrincipesJeu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(closeButtonPrincipesJeu);
    }

    public void CloseButtonPrincipesJeu()
    {
        _audioManager.PlayClickSound();
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

    public void GameOverMenu()
    {
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(_boutonMenu);
        _panelGameOver.SetActive(true);
    }

    public void CloseButtonSeisme()
    {
        _audioManager.PlayClickSound();
        panelSeisme.SetActive(false);
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void CloseButtonIntemperies()
    {
        _audioManager.PlayClickSound();
        panelIntemperies.SetActive(false);
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void CloseButtonTempetesSolaires()
    {
        _audioManager.PlayClickSound();
        panelTempetesSolaires.SetActive(false);
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void MenuButton()
    {
        _audioManager.PlayClickSound();
        SceneManager.LoadScene("Menu");
    }
}
