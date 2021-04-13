using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;
using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class DialogBox : MonoBehaviour {

    public float dialogDuration = 1f;

    [Header("REFS")]
    public Text textUI;
    public TextMeshProUGUI textMeshProUI;

    public bool HasMaintainEnoughTime {get; set;} = false;
    public bool IsReturnable {get; set;} = true;

    public string DialogText {
        get {
            switch (Global.current.currentTextType) {
                case 0:
                    if (textUI != null)
                        return textUI.text;
                    break;
                case 1:
                    if (textMeshProUI != null)
                        return textMeshProUI.text;
                    break;
            }
            return "";
        }
        set {
            switch (Global.current.currentTextType) {
                case 0:
                    if (textUI != null)
                        textUI.text = value;
                    break;
                case 1:
                    if (textMeshProUI != null)
                        textMeshProUI.text = value;
                    break;
            }
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
