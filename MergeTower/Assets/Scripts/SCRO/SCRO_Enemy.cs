using ObjectsOnScene;
using UnityEngine;

[CreateAssetMenu(fileName = "SCRO_Enemy", menuName = "Objects/SCRO_Enemy")]
public class SCRO_Enemy : ScriptableObject
{
    public int Health, PriceReward;
    public float Speed;
    public Enemy Prefab;
}
