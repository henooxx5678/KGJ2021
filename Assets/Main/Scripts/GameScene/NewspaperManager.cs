using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class NewspaperManager : MonoBehaviour {

    public float waitDuration = 1f;

    public GameObject[] newspapers;
    public GameObject   goableMsg;

    public bool IsNewspapersShowing {get; private set;} = false;

    bool _isGoable = false;

    Sequence _seq;

    void Update () {
        if (_isGoable && Input.anyKeyDown) {

            if (GameSceneManager.current.HasWon) {
                SceneManager.LoadScene("StartScene");
            }
            else {

                _isGoable = false;
                goableMsg.SetActive(false);

                foreach (GameObject newspaper in newspapers) {
                    newspaper.SetActive(false);
                }

                IsNewspapersShowing = false;
            }

        }
    }

    public void Play (int index) {

        _isGoable = false;
        goableMsg.SetActive(false);

        for (int i = 0 ; i < newspapers.Length ; i++) {
            if (i == index) {
                newspapers[i].SetActive(true);
                IsNewspapersShowing = true;

                if (_seq != null)
                    _seq.Kill();

                _seq = DOTween.Sequence()
                    .AppendInterval(waitDuration)
                    .AppendCallback( () => {
                        _isGoable = true;
                        goableMsg.SetActive(true);
                    } );
            }
            else {
                newspapers[i].SetActive(false);
            }
        }
    }

}
