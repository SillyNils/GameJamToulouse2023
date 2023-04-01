using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEAreaDectection : MonoBehaviour
{
    private bool _EnterDetected = false;

    [SerializeField] GameObject _Qtesprite1;
    [SerializeField] GameObject _Qtesprite2;
    [SerializeField] GameObject _Qtesprite3;
    [SerializeField] GameObject _Qtesprite4;

    private bool _GameOver = false;
    private bool _QteWin = false;
    private bool _TimerOff = false;

    private int _RandQTE;
    // Start is called before the first frame update
    void Start()
    {
        _Qtesprite1.SetActive(false);
        _Qtesprite2.SetActive(false);
        _Qtesprite3.SetActive(false);
        _Qtesprite4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(QteTimer());

        _RandQTE = Random.Range(1,4);

    if(_RandQTE == 1)
        {
            _Qtesprite1.SetActive(true);

            if(Input.GetKeyDown("QTE 1") && !_TimerOff)
            {
                //condition reset perso
            }
            else if(_TimerOff)
            {
                _GameOver= true;
            }
        }
    else if(_RandQTE == 2)
        {
            _Qtesprite2.SetActive(true);
            if (Input.GetKeyDown("QTE 2") && !_TimerOff)
            {
                //condition reset perso
            }
            else if (_TimerOff)
            {
                _GameOver = true;
            }
        }
    else if (_RandQTE== 3)
        {
            _Qtesprite3.SetActive(true);
            if (Input.GetKeyDown("QTE 3") && !_TimerOff)
            {
                //condition reset perso
            }
            else if (_TimerOff)
            {
                _GameOver = true;
            }
        }
    else if (_RandQTE== 4) 
        {
            _Qtesprite4.SetActive(true);
            if (Input.GetKeyDown("QTE 4") && !_TimerOff)
            {
                //condition reset perso
            }
            else if (_TimerOff)
            {
                _GameOver = true;
            }
        }

            

    }

    IEnumerator QteTimer()
    {
        yield return new WaitForSeconds(2f);
        _TimerOff= true;
    }
    
}
