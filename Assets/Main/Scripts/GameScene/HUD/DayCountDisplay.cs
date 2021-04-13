using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;


public class DayCountDisplay : DynamicTextDisplay {

    protected override void Awake () {
        base.Awake();
    }


    public override void UpdateDisplay () {
        if (!_isInited)
            return;

        TextString = _initText.Replace("<count>", GameSceneManager.current.DayCount.ToString());
    }

}
