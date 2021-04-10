using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using DoubleHeat;
using DoubleHeat.Utilities;


[RequireComponent(typeof(Camera))]
public class PlayerCameraManager : MonoBehaviour {

    public Player player;

    public bool isFollowing = true;

    public Camera Cam {
        get {
            if (_cam == null)
                _cam = GetComponent<Camera>();

            return _cam;
        }
    }

    Camera _cam;


    void LateUpdate () {


        if (isFollowing && player != null) {
            transform.SetPosXY(player.transform.position);
        }

    }

}
