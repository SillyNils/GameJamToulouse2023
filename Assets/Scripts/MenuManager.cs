using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AudioSource buttonClickSound;
    [SerializeField] private GameObject _panelCredits;
    [SerializeField] private GameObject _closeButton;
    [SerializeField] private GameObject _creditsButton;

    public void Start()
    {

        _panelCredits.SetActive(false);
    }
    public void PlayButton()
    {
        buttonClickSound.Play();
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitButton()
    {
        buttonClickSound.Play();
        Application.Quit();
    }

    public void CreditsButton()
    {
        buttonClickSound.Play();
        EventSystem.current.SetSelectedGameObject(_closeButton);
        _panelCredits.SetActive(true);
    }
    
    public void CloseButton()
    {
        buttonClickSound.Play();
        EventSystem.current.SetSelectedGameObject(_creditsButton);
        _panelCredits.SetActive(false);
    }
}
