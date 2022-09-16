using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float maxDistance;

        private Collider _collider;
        private Transform _transform;
        private RaycastHit _raycastHit;
        private bool _hiteDetect;

        private void Start()
        {
            _collider = GetComponent<BoxCollider>();
            _transform = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
           Attack();
        }
        
        private void Attack()
        {
            _hiteDetect = Physics.BoxCast(_collider.bounds.center, _transform.localScale / 2,
                _transform.forward, out _raycastHit, _transform.rotation, maxDistance);

            if (_hiteDetect)
            {
                ManagerShooting.Singleton.isShooting = true;
            }
            else
            {
                ManagerShooting.Singleton.isShooting = false;
            }

        }
        
        /////////////////Gizmos
        #if UNITY_EDITOR

            private void OnDrawGizmos()
            {
                Gizmos.color = Color.red;

                if (_hiteDetect)
                {
                    Gizmos.DrawRay(transform.position, transform.forward * _raycastHit.distance);
                    Gizmos.DrawWireCube(transform.position + transform.forward * _raycastHit.distance,
                        transform.localScale);
                }
                else
                {
                    Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
                    Gizmos.DrawWireCube(transform.position + transform.forward * maxDistance, transform.localScale);
                }

            }

        #endif
    }
}
    