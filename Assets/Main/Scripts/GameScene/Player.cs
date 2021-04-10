using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class Player : SingletonMonoBehaviour<Player> {

    public float moveSpeed = 1f;
    public LayerMask moveLayerMask;

    [Header("REFS")]
    public PlayerCarried carried;

    public bool IsControllable => GameSceneManager.current.IsDayRunning;

    Rigidbody2D _rb;

    protected override void Awake () {
        base.Awake();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update () {

        if (IsControllable) {
            // MOVE
            Vector2 moveDir = (Input.GetAxisRaw("Horizontal") * Vector2.right + Input.GetAxisRaw("Vertical") * Vector2.up).normalized;
            transform.position += (Vector3) PhysicsTools2D.GetFinalDeltaPosAwaringObstacle(_rb, moveDir, moveSpeed * Time.deltaTime, moveLayerMask);
        }

    }

    void OnTriggerEnter2D (Collider2D other) {
        DoorTriggerHandler door = other.gameObject.GetComponent<DoorTriggerHandler>();

        if (door != null) {

        }
    }

}
