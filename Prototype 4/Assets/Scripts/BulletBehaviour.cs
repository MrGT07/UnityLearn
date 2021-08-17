using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Transform _target;
    private float _speed = 15.0f;
    private bool _homing;

    private float _bulletStrength = 15.0f;
    private float _aliveTimer = 5.0f;

    public void Fire(Transform newTarget)
    {
        _target = newTarget;
        _homing = true;
        Destroy(gameObject, _aliveTimer);
    }

    private void Update()
    {
        if (_homing && _target != null)
        {
            Vector3 moveDirection = (_target.transform.position - transform.position).normalized;
            transform.position += moveDirection * _speed * Time.deltaTime;
            transform.LookAt(_target);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_target != null)
        {
            if (collision.gameObject.CompareTag(_target.tag))
            {
                Rigidbody targetRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 away = -collision.GetContact(0).normal;
                targetRigidbody.AddForce(away * _bulletStrength, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }
}
