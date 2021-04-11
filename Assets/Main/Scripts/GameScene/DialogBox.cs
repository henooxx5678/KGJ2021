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

    public bool HasMaintainEnoughTime {get; set;} = false;
    public bool IsReturnable {get; set;} = true;

    public string DialogText {
        get => textUI.text;
        set {
            if (textUI != null)
                textUI.text = value;
        }
    }

    Sequence _currentSeq;
    string _returnedString = "";

    void Update () {
        if (HasMaintainEnoughTime && IsReturnable) {

            DialogText = _returnedString;

            HasMaintainEnoughTime = false;
            IsReturnable = false;
        }
    }

    public void SetToAllFine () {
        DialogText = Dialog.RandomAllFine;
    }

    public void ShowDialog (string dialog, bool returnToAllFine = true, string alteredText = "") {

        HasMaintainEnoughTime = false;
        IsReturnable = false;

        if (returnToAllFine)
            _returnedString = Dialog.RandomAllFine;
        else
            _returnedString = alteredText;

        if (_currentSeq != null)
            _currentSeq.Kill(false);

        _currentSeq = DOTween.Sequence()
            .AppendCallback( () => DialogText = dialog )
            .AppendInterval(dialogDuration)
            .AppendCallback( () => {
                HasMaintainEnoughTime = true;
            } );
    }
}
