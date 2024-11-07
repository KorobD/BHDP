using UnityEngine;


public class BulletEnemy : MonoBehaviour {
    
    private GameObject _player;
    private Rigidbody2D _rb;
    private GameBound _gameBound;
    private Vector3 _angle;

    private float _speed;

    public Vector3 Angle { set { _angle = value; } }
    public float Speed { get { return _speed; } set { _speed = value; } }

    private void Start() {

        _gameBound = FindAnyObjectByType<GameBound>();
        _rb = GetComponent<Rigidbody2D>();

        _rb.linearVelocity = new Vector2(_angle.x, _angle.y).normalized * _speed;

        float rot = Mathf.Atan2(_angle.y, _angle.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }

    private void Update() {

        DeleteBullet();

    }


    private void DeleteBullet() {

        if (IsNotInGameField(transform.position)) {

            Destroy(this.gameObject);

        }

    }

    bool IsNotInGameField(Vector3 position) {

        return position.x < _gameBound.GameAreaMinX - 10f || position.x > _gameBound.GameAreaMaxX + 10f || position.y < _gameBound.GameAreaMinY - 10f || position.y > _gameBound.GameAreaMaxY + 10f;

    }

}
