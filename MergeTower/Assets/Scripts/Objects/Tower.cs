using UnityEngine;

public class Tower : MonoBehaviour
{
    private ShootSystem shootSystem;

    public void InitTower()
    {
        shootSystem = new ShootSystem();
    }
}
