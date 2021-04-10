using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class OverlayEventManager : MonoBehaviour {

    public float eventDuration = 1f;

    [Header("REFS")]
    public GameObject[] events;


    Sequence _currentSeq;


    void Awake () {
        foreach(GameObject e in events) {
            e.SetActive(false);
        }
    }

    public void PlayEvent (int index) {

        for (int i = 0 ; i < events.Length ; i++) {
            if (i == index) {
                GameObject e = events[i];

                if (_currentSeq != null)
                    _currentSeq.Kill();

                _currentSeq = DOTween.Sequence()
                    .AppendCallback( () => e.SetActive(true) )
                    .AppendInterval(eventDuration)
                    .AppendCallback( () => e.SetActive(false) );
            }
            else {
                events[i].SetActive(false);
            }
        }
    }


}
