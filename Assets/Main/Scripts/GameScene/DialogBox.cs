using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class DialogBox : MonoBehaviour {

    public float dialogDuration = 1f;

    [Header("REFS")]
    public Text textUI;

    public string DialogText {
        get => textUI.text;
        set {
            textUI.text = value;
        }
    }

    Sequence _currentSeq;

    public void SetToAllFine () {
        DialogText = Dialog.RandomAllFine;
    }

    public void ShowDialog (string dialog) {
        if (_currentSeq != null)
            _currentSeq.Kill(false);

        _currentSeq = DOTween.Sequence()
            .AppendCallback( () => DialogText = dialog )
            .AppendInterval(dialogDuration)
            .AppendCallback(SetToAllFine);
    }
}
