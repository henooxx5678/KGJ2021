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


public class DynamicTextDisplay : MonoBehaviour {

    public static List<DynamicTextDisplay> list = new List<DynamicTextDisplay>();


    Text _text;
    public Text TextUI {
        get {
            if (_text == null)
                _text = GetComponent<Text>();

            return _text;
        }
    }

    TextMeshProUGUI _tmpUI;
    public TextMeshProUGUI TmpUI {
        get {
            if (_tmpUI == null)
                _tmpUI = GetComponent<TextMeshProUGUI>();

            return _tmpUI;
        }
    }

    public string TextString {
        get {
            switch (Global.current.currentTextType) {
                case 0:
                    return TextUI != null ? TextUI.text : "";
                case 1:
                    return TmpUI != null ? TmpUI.text : "";
            }
            return "";
        }
        set {
            switch (Global.current.currentTextType) {
                case 0:
                    if (TextUI != null)
                        TextUI.text = value;
                    break;
                case 1:
                    if (TmpUI != null)
                        TmpUI.text = value;
                    break;
            }
        }
    }

    protected bool _isInited = false;

    protected string _initText = "";


    protected virtual void Awake () {

        _initText = TextString;

        _isInited = true;

        list.Add(this);
    }

    protected virtual void OnDestroy () {
        list.Remove(this);
    }

    public virtual void UpdateDisplay () {}

}
