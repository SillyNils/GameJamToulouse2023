using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class QTEAreaDectection : MonoBehaviour
{
    //private bool _EnterDetected = false;

    [SerializeField] GameObject _Qtesprite_A;
    [SerializeField] GameObject _Qtesprite_B;
    [SerializeField] GameObject _Qtesprite_Y;
    [SerializeField] GameObject _Qtesprite_X;

    [SerializeField] private int _QTEGen;
    [SerializeField] private int _WaitingForKey;
    [SerializeField] private int _CorrectKey;
    [SerializeField] private int _countingDown;
    private bool _enter = false;

    public PlayerControler PlayerControler;

    public PopupManager _popupManager;

    // Start is called before the first frame update
    void Start()
    {
        _Qtesprite_A.SetActive(false);
        _Qtesprite_B.SetActive(false);
        _Qtesprite_Y.SetActive(false);
        _Qtesprite_X.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.Debug.Log(_enter);
        if (_enter)
        {
            
            if (_WaitingForKey == 0)
            {
                _QTEGen = Random.Range(0, 4);

                _countingDown = 1;
                StartCoroutine(QteTimer());
                
                if (_QTEGen == 0)
                {
                    _WaitingForKey = 1;
                    _Qtesprite_A.SetActive(true);
                }
                if (_QTEGen == 1)
                {
                    _WaitingForKey = 1;
                    _Qtesprite_B.SetActive(true);
                }
                if (_QTEGen == 2)
                {
                    _WaitingForKey = 1;
                    _Qtesprite_X.SetActive(true);
                }
                if (_QTEGen == 3)
                {
                    _WaitingForKey = 1;
                    _Qtesprite_Y.SetActive(true);
                }
            }

            if (Input.GetButtonDown("QTE 0") || Input.GetButtonDown("QTE 1") || Input.GetButtonDown("QTE 2") || Input.GetButtonDown("QTE 3"))
            {
                if (Input.GetButtonDown("QTE " + _QTEGen))
                {
                    _CorrectKey = 1;
                    
                }
                else
                {
                    _CorrectKey = 2;
                }
                StartCoroutine(KeyPresing());
                _enter = false;
            }
        }
        
    }


    public void OnTriggerEnter(Collider other)
    {
        _enter = true;
    }
    

    IEnumerator QteTimer()
    {
     yield return new WaitForSeconds(_QTETiming);
        if(_countingDown == 1)
        {
            _QTEGen = 4;
            _countingDown= 2;

            UnityEngine.Debug.Log("Echec QTE Timer");
            _popupManager.GameOverMenu();//fonction defaite

            //yield return new WaitForSeconds(0.5f);
            _CorrectKey = 0;
            _Qtesprite_A.SetActive(false);
            _Qtesprite_B.SetActive(false);
            _Qtesprite_Y.SetActive(false);
            _Qtesprite_X.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            _WaitingForKey = 0;
            _countingDown = 0;
        }
    }

    IEnumerator KeyPresing()
    {
        _QTEGen = 4;
        if(_CorrectKey == 1)
        {
            _countingDown = 2;

            UnityEngine.Debug.Log("Reussite QTE");
            PlayerControler.qteSpeedReset();//fonction victoire

            //yield return new WaitForSeconds(0.5f);
            _CorrectKey= 0;
            _Qtesprite_A.SetActive(false);
            _Qtesprite_B.SetActive(false);
            _Qtesprite_Y.SetActive(false);
            _Qtesprite_X.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            _WaitingForKey = 0;
            _countingDown= 0;
        }

        if (_CorrectKey == 2)
        {
            _countingDown = 2;

            UnityEngine.Debug.Log("Echec QTE button");
            _popupManager.GameOverMenu();//fonction defaite

           
            _CorrectKey = 0;
            _Qtesprite_A.SetActive(false);
            _Qtesprite_B.SetActive(false);
            _Qtesprite_Y.SetActive(false);
            _Qtesprite_X.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            _WaitingForKey = 0;
            _countingDown = 0;
        }
    }
    
}
