using Data;
using ObjectsOnScene;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "BulletManager", menuName = "Managers/BulletManager")]
    public class BulletManager : BaseManager
    {
        [SerializeField] private Bullet bulletPrefab;                
        private List<Bullet> bullets = new List<Bullet>();
        private List<Bullet> poolBullets = new List<Bullet>();               

        public void CreateBullet(BulletData bulletData, Transform transformSpawn, ObjectScene target)
        {
            Bullet SetBullet = new Bullet(); // Это зачем было создано?
            Bullet newBullet = BoxManager.GetManager<CreatorManager>().CreateBullet(bulletPrefab, transformSpawn);
            newBullet.SetDataBullet = bulletData; // Вот присвоение через свойство
            newBullet.SetTarget(target);
            newBullet.OnInitialize();
            newBullet.DeathObjectEvent += BulletDeath;            
            bullets.Add(newBullet);           
        }

        private void BulletDeath(ObjectScene objectScene)
        {
            objectScene.DeathObjectEvent += BulletDeath;

            if (objectScene is Bullet)
            {
                Bullet bullet = objectScene as Bullet;
                bullets.Remove(bullet);
                poolBullets.Add(bullet);
                bullet.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log($"<color=red>?????? ?? Bullet! {objectScene.gameObject.name}</color>");
            }
        }
    }
}