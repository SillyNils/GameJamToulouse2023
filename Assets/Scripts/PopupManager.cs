using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private AudioSource buttonClickSound;

    [SerializeField] private GameObject panelControles;
    [SerializeField] private GameObject panelPrincipesJeu;
    [SerializeField] private GameObject panelTempetesSolaires;
    [SerializeField] private GameObject panelSeisme;
    [SerializeField] private GameObject panelIntemperies;

    [SerializeField] private GameObject closeButtonPrincipesJeu;
    [SerializeField] private GameObject closeButtonSeisme;
    [SerializeField] private GameObject closeButtonIntemperies;
    [SerializeField] private GameObject closeButtonTempetesSolaires;

    // Start is called before the first frame update
    void Start()
    {
        panelControles.SetActive(true);
        panelPrincipesJeu.SetActive(false);
        panelIntemperies.SetActive(false);
        panelSeisme.SetActive(false);
        panelTempetesSolaires.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextButton()
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
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(closeButtonSeisme);
    }

    public void CloseButtonSeisme()
    {
        PlayClickSound();
        panelSeisme.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(closeButtonIntemperies);
    }

    public void CloseButtonIntemperies()
    {
        PlayClickSound();
        panelIntemperies.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(closeButtonTempetesSolaires);
    }

    public void CloseButtonTempetesSolaires()
    {
        PlayClickSound();
        panelTempetesSolaires.SetActive(false);
    }

    public void PlayClickSound()
    {
        buttonClickSound.Play();
    }
}
