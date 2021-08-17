using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    private Rigidbody _playerRB;
    private GameObject _focalPoint;
    public GameObject powerupIndicator;
    private bool hasPowerup;
    private float _powerupStrength = 15.0f;

    public PowerUps currentPowerup = PowerUps.None;

    public GameObject bulletPrefab;
    private GameObject _tmpBullet;
    private Coroutine powerUpCountDown;

    private void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("FocalPoint");
    }

    private void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _playerRB.AddForce(_focalPoint.transform.forward * speed * forwardInput);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if(transform.position.y < -13)
        {
            Time.timeScale = 0f;
        }

        if(currentPowerup == PowerUps.Bullets && Input.GetKeyDown(KeyCode.F))
        {
            LaunchBullets();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp")){
            hasPowerup = true;
            currentPowerup = other.gameObject.GetComponent<PowerUp>().powerUpType;
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerUpCountdownRoutine());

            if(powerUpCountDown != null)
            {
                StopCoroutine(powerUpCountDown);
            }
            powerUpCountDown = StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && currentPowerup == PowerUps.PushBack)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRB.AddForce(awayFromPlayer * _powerupStrength, ForceMode.Impulse);

            Debug.Log("Player collided with: " + collision.gameObject.name + " with powerup set to: " + currentPowerup.ToString());
        }
    }

    void LaunchBullets()
    {
        foreach(var enemy in FindObjectsOfType<Enemy>())
        {
            _tmpBullet = Instantiate(bulletPrefab, transform.position + Vector3.up, Quaternion.identity);
            _tmpBullet.GetComponent<BulletBehaviour>().Fire(enemy.transform);
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        currentPowerup = PowerUps.None;
        powerupIndicator.SetActive(false);
    }
}
