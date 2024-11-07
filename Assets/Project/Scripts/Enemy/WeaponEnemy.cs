using UnityEngine;
using PN;

public class WeaponEnemy : MonoBehaviour {

    //---

    private enum ShotPatterns {

        None,
        SimpleShoot,
        SimpleShootToPlayer,
        SpreadShot,
        SpreadShotToPlayer,
        CircleShoot,
        SpiralShoot

    }

    private ShotPatterns _currentShotPatterns;

    //---


    [SerializeField] private GameObject _bullet0;
    [SerializeField] private GameObject _bullet1;
    [SerializeField] private GameObject _bullet2;
    [SerializeField] private GameObject _bullet3;
    [SerializeField] private GameObject _bullet4;
    [SerializeField] private GameObject _bullet5;
    [SerializeField] private GameObject _bullet6;

    [SerializeField] private Transform _weaponPos;

    private GameObject _player;
    private float _timer;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update() {

        if (Input.GetKeyDown(KeyCode.Alpha1)) _currentShotPatterns = ShotPatterns.SimpleShoot;
        if (Input.GetKeyDown(KeyCode.Alpha2)) _currentShotPatterns = ShotPatterns.SimpleShootToPlayer;
        if (Input.GetKeyDown(KeyCode.Alpha3)) _currentShotPatterns = ShotPatterns.SpreadShot;
        if (Input.GetKeyDown(KeyCode.Alpha4)) _currentShotPatterns = ShotPatterns.SpreadShotToPlayer;
        if (Input.GetKeyDown(KeyCode.Alpha5)) _currentShotPatterns = ShotPatterns.CircleShoot;
        if (Input.GetKeyDown(KeyCode.Alpha6)) _currentShotPatterns = ShotPatterns.SpiralShoot;

        Shot(0.1f);

    }


    private void Shot(float fireRate) {

        _timer += Time.deltaTime;
        if (_timer > fireRate) {
            switch (_currentShotPatterns) {
                
                case ShotPatterns.SimpleShoot:
                    
                    PN.Shots.SimpleShoot(_bullet0, _weaponPos, 10f);
                    break;

                case ShotPatterns.SimpleShootToPlayer:
                    
                    PN.Shots.SimpleShootToPlayer(_bullet1, _weaponPos, _player.transform, 10f);
                    break;

                case ShotPatterns.SpreadShot:
                    
                    PN.Shots.SpreadShot(_bullet2, _weaponPos, 5, 10f, 30f);
                    break;

                case ShotPatterns.SpreadShotToPlayer:
                    
                    PN.Shots.SpreadShotToPlayer(_bullet3, _weaponPos, _player.transform, 5, 10f, 30f);
                    break;

                case ShotPatterns.CircleShoot:
                    
                    PN.Shots.CircleShot(_bullet4, _weaponPos, 36, 10f);
                    break;

                case ShotPatterns.SpiralShoot:
                    
                    float currentAngle = Time.time * 50f;
                    PN.Shots.SpiralShot(_bullet5, _weaponPos, 1, 2f, currentAngle);
                    break;

                case ShotPatterns.None:
                    
                    break;
            }

            _timer = 0f;

        }
    }
}
