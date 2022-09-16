using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet : MonoBehaviour
    {
        private float _speed = 16f;
        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            //_rb.velocity = transform.forward * _speed;
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
    }
}