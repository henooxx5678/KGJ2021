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
    public GameObject[] globalMsgs;

    public GameObject GlobalMsg => globalMsgs[Global.current.currentTextType];

    public bool IsNewspapersShowing {get; private set;} = false;

    bool _isGoable = false;

    Sequence _seq;

    void Update () {
        if (_isGoable && Input.inputString.Length > 0) {

            if (GameSceneManager.current.HasWon) {
                SceneManager.LoadScene("StartScene");
            }
            else {

                _isGoable = false;
                GlobalMsg.SetActive(false);

                foreach (GameObject newspaper in newspapers) {
                    newspaper.SetActive(false);
                }

                IsNewspapersShowing = false;
            }

        }
    }

    public void Play (int index) {

        _isGoable = false;
        GlobalMsg.SetActive(false);

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
                        GlobalMsg.SetActive(true);
                    } );
            }
            else {
                newspapers[i].SetActive(false);
            }
        }
    }

    public void OpenUrl (string url) {
        Application.OpenURL(url);
    }

}
