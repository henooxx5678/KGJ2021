using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;


public class SentCountDisplay : DynamicTextDisplay {


    protected override void Awake () {
        base.Awake();
    }


    public override void UpdateDisplay () {
        if (!_isInited)
            return;

        int sentCount = GameSceneManager.current.SentCount;
        TextString = _initText.Replace("<count>", sentCount.ToString()).Replace("<rate>", (sentCount / 400f).ToString("0.00"));
    }

}
