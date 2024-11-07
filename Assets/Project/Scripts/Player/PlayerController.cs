using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private GameInput _gameInput;
    [Space]
    [Header("Movement")]
    private float _moveSpeed;
    [SerializeField, Range(1f, 20f)] private float _normalMoveSpeed = 10f;
    [SerializeField, Range(1f, 20f)] private float _slowMoveSpeed = 5f;


    //---FuckingVariables----
    private GameBound _gameBound;
    private float _gameAreaMinX;
    private float _gameAreaMaxX;
    private float _gameAreaMinY;
    private float _gameAreaMaxY;
    //------------------------


    private void Awake() {
        _gameBound = FindAnyObjectByType<GameBound>();
        _gameInput = FindAnyObjectByType<GameInput>();
    }
    private void Start() {
        _gameAreaMinX = _gameBound.GameAreaMinX;
        _gameAreaMaxX = _gameBound.GameAreaMaxX;
        _gameAreaMinY = _gameBound.GameAreaMinY;
        _gameAreaMaxY = _gameBound.GameAreaMaxY;

    }

    private void Update() {
        Move();
        ClampedPosition();
    }

    public void Move() {
        SlowMove();
        Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);
        transform.position += moveDir * _moveSpeed * Time.deltaTime;
    }
    private void ClampedPosition() {
        Vector2 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, _gameAreaMinX, _gameAreaMaxX);
        clampedPos.y = Mathf.Clamp(clampedPos.y, _gameAreaMinY, _gameAreaMaxY);
        transform.position = clampedPos;
    }

    private void SlowMove() {
        bool slowMove = _gameInput.OnSlowMove();
        if (slowMove) {
            _moveSpeed = _slowMoveSpeed;
        } else {
            _moveSpeed = _normalMoveSpeed;
        }
    }

}
