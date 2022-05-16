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

        public void CreateBullet(BulletData bulletData, Vector3 startPosition, ObjectScene target)
        {
            // TODO: сделать pool  и проверить в нём, возможно не нужно создавать новую пулю
            Bullet newBullet = BoxManager.GetManager<CreatorManager>().CreateBullet(bulletPrefab, startPosition);
            newBullet.SetDataBullet(bulletData);
            newBullet.SetTarget(target);
            newBullet.OnInitialize();

            bullets.Add(newBullet);
        }
    }
}