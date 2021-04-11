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


    public bool IsEventPlaying {get; private set;} = false;

    Sequence _currentSeq;


    void Awake () {
        foreach(GameObject eGO in events) {
            eGO.SetActive(false);
        }
    }

    public void PlayEvent (int index) {

        for (int i = 0 ; i < events.Length ; i++) {
            if (i == index) {
                GameObject eGO = events[i];

                if (_currentSeq != null)
                    _currentSeq.Kill();

                IsEventPlaying = true;

                OverlayEvent e = eGO.GetComponent<OverlayEvent>();
                float duration = (e != null && e.overrideDuration > 0) ? e.overrideDuration : eventDuration;

                _currentSeq = DOTween.Sequence()
                    .AppendCallback( () => eGO.SetActive(true) )
                    .AppendInterval(duration)
                    .AppendCallback( () => eGO.SetActive(false) )
                    .OnComplete( () => IsEventPlaying = false );
            }
            else {
                events[i].SetActive(false);
            }
        }
    }


}
