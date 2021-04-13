using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class Global : SingletonMonoBehaviour<Global> {


    public int currentTextType;

    public TransitionManager transitionManager;

    protected override void Awake () {
        base.Awake();

        DontDestroyOnLoad(gameObject);

        PlayerPrefs.DeleteAll();

        DOTween.Init();
        DOTween.defaultTimeScaleIndependent = false;
    }

}
