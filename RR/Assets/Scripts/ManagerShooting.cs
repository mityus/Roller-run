using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class ManagerShooting : MonoBehaviour
    {
        public static ManagerShooting Singleton { get; private set; }

        public bool isShooting;
        
        [Header("Bullet")]
        [SerializeField] private Transform targetBullet;
        [SerializeField] private GameObject prefabBullet;
        
        private float time = 0.0f;
        private float interpolationPeriod = 0.5f;

        private void Start()
        {
            isShooting = false;
        }

        private void Awake()
        {
            Singleton = this;
        }

        private void Update()
        {
            if (isShooting)
            {
                time += Time.deltaTime;
            
                if (time >= interpolationPeriod)
                {
                    Instantiate(prefabBullet, targetBullet.position, targetBullet.rotation);
                    time = time - interpolationPeriod;
                }
            }
        }
    }
}