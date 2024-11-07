using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour {

    public static GameInput Instance { get; private set; }


    private GameControls _gameControls;

    public Action OnPauseAction;


    private void Awake() {

        Instance = this;
        _gameControls = new GameControls();

        _gameControls.Player.Enable();
    }

    private void OnDestroy() {

        _gameControls.Dispose();
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = _gameControls.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }

    public bool OnShooting() {
        bool isShooting = _gameControls.Player.Shot.ReadValue<float>() > 0.1f;
        return isShooting;
    }


    public bool OnSlowMove() {
        bool isSlowMove = _gameControls.Player.SlowMove.ReadValue<float>() > 0.1f;
        return isSlowMove;
    }

    private void Pause_performed(InputAction.CallbackContext context) {
        OnPauseAction?.Invoke();
    }
}

