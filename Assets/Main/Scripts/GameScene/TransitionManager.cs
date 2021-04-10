using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class TransitionManager : MonoBehaviour {

    public float fadeDuration;

    [Header("REFS")]
    public CanvasGroup blackScreen;

    Tween _currentTransition;

    public void FadeScreenOut (TweenCallback endCallback) {
        if (_currentTransition != null)
            _currentTransition.Kill();

        _currentTransition = blackScreen.DOFade(1f, fadeDuration)
            .From(0f)
            .OnComplete(endCallback);
    }

    public void FadeScreenIn (TweenCallback endCallback) {
        if (_currentTransition != null)
            _currentTransition.Kill();
            
        _currentTransition = blackScreen.DOFade(0f, fadeDuration)
            .From(1f)
            .OnComplete(endCallback);
    }

}
