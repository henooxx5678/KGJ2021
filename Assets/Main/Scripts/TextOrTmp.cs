using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class TextOrTmp : MonoBehaviour {
    void Start () {
        if (Global.current.currentTextType == 0) {
            if (GetComponent<Text>() == null)
                Destroy(gameObject);
        }
        else {
            if (GetComponent<TextMeshProUGUI>() == null)
                Destroy(gameObject);
        }
    }
}
