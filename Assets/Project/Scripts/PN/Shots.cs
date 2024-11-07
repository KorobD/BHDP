using UnityEngine;
using Unity.Mathematics;

namespace PN {

    public static class Shots {

        public static void SimpleShoot(GameObject bulletPrefab, Transform startPos, float speed, float moveDir = -90) {

            SpawnBullet(bulletPrefab, startPos, speed, moveDir);
        }

        public static void SimpleShootToPlayer(GameObject bulletPrefab, Transform startPos, Transform playerPos, float speed) {

            SpawnBullet(bulletPrefab, startPos, speed, GetDirectionToPlayer(playerPos.position, startPos.position));
        }

        public static void SpreadShot(GameObject bulletPrefab, Transform startPos, int numberOfBullets, float speed, float spreadAngle, float moveDir = -90) {

            float angleStep = spreadAngle / (numberOfBullets - 1);
            float startAngle = moveDir - (spreadAngle / 2);
            for (int i = 0; i < numberOfBullets; i++) {
                float currentAngle = startAngle + (i * angleStep);
                SpawnBullet(bulletPrefab, startPos, speed, currentAngle);
            }

        }

        public static void SpreadShotToPlayer(GameObject bulletPrefab, Transform startPos, Transform playerPos, int numberOfBullets, float speed, float spreadAngle) {

            float angleStep = spreadAngle / (numberOfBullets - 1);
            float startAngle = GetDirectionToPlayer(playerPos.position, startPos.position) - (spreadAngle / 2);
            for (int i = 0; i < numberOfBullets; i++) {
                float currentAngle = startAngle + (i * angleStep);
                SpawnBullet(bulletPrefab, startPos, speed, currentAngle);
            }

        }

        public static void CircleShot(GameObject bulletPrefab, Transform startPos, int numberOfBullets, float speed) {

            float angleStep = 360 / numberOfBullets;
            for (int i = 0; i < numberOfBullets; i++) {
                float currentAngle = i * angleStep;
                SpawnBullet(bulletPrefab, startPos, speed, currentAngle);
            }

        }

        public static void SpiralShot(GameObject bulletPrefab, Transform startPos, int numberOfBullets, float speed, float currentAngle) {

            float angleStep = 360f / numberOfBullets;
            for (int i = 0; i < numberOfBullets; i++) {
                float angle = currentAngle + (i * angleStep);
                SpawnBullet(bulletPrefab, startPos, speed, angle);
            }

        }



        public static float GetDirectionToPlayer(Vector3 playerPosition, Vector3 startPosition) {
            Vector3 direction = playerPosition - startPosition;
            return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        public static void SpawnBullet(GameObject bulletPrefab, Transform startPos, float speed, float moveDir) {

            GameObject bullet = GameObject.Instantiate(bulletPrefab, startPos.position, Quaternion.identity);
            bullet.GetComponent<BulletEnemy>().Speed = speed;
            bullet.GetComponent<BulletEnemy>().Angle = GetVectorFromAngle(moveDir);

        }

        private static Vector3 GetVectorFromAngle(float angle) {
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }

    }

}
