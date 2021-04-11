using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class OverlayEvent : MonoBehaviour {


    public float overrideDuration = -1f;


    void OnEnable () {
        AudioSource source = GetComponent<AudioSource>();

        if (source != null) {
            source.Stop();
            source.Play();
        }
    }

}
