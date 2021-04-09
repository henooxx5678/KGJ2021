﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class Global : SingletonMonoBehaviour<Global> {

    protected override void Awake () {
        base.Awake();

        DontDestroyOnLoad(gameObject);

        DOTween.Init();
        DOTween.defaultTimeScaleIndependent = false;
    }

}