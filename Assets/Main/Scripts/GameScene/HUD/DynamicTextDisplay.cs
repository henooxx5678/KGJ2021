using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

[RequireComponent(typeof(Text))]
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

    protected bool _isInited = false;

    protected string _initText = "";


    protected virtual void Awake () {
        _text = GetComponent<Text>();
        _initText = _text.text;

        _isInited = true;

        list.Add(this);
    }

    protected virtual void OnDestroy () {
        list.Remove(this);
    }

    public virtual void UpdateDisplay () {}

}
