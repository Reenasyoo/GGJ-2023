using System;
using System.Linq;
using Systems.ObjectPooling;
using UnityEngine;

namespace Runtime.Buildables.Turret
{
    public class TurretAttackController : MonoBehaviour
    {
        [SerializeField] private GameObject ammunition;
        [SerializeField] private Transform attackFromPoint;

        private Transform _currentTarget;
        private ObjectPool<GameObject> _ammoPool;
        private InstantiatedObjects objList = new InstantiatedObjects();

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _ammoPool = new ObjectPool<GameObject>(ammunition, 5);
            InstantiatePoolObjects();
        }

        private void InstantiatePoolObjects()
        {
            foreach (var ammo in _ammoPool.PooledObjects)
            {
                var tmp = Instantiate(ammo.poolable.objectPrefab, transform);
                tmp.SetActive(false);
                var temp = new InstantiadedObject(_ammoPool.PooledObjects.IndexOf(ammo), tmp);
                objList.list.Add(temp);
            }
        }

        private void ActivateBullet()
        {
            var tmp = objList.list.FirstOrDefault();
            _ammoPool.ActivateObject();
            objList.ActivateObject();
            
            tmp.obj.transform.position = attackFromPoint.position;
            tmp.obj.SetActive(true);
        }
        
        private void DeactivateBullet()
        {
            var tmp = objList.active.FirstOrDefault();
            _ammoPool.DeactivateObject();
            objList.DeactivateObject();
            
            tmp.obj.SetActive(false);
        }
            
        private void Attack()
        {
            ActivateBullet();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Attack();
            }
        }
    }
    
    
}