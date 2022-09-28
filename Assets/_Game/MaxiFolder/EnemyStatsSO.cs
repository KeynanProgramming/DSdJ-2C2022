using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBaseStats", menuName = "CharacterStats/Enemy", order = 0)]
public class EnemyStatsSO : ScriptableObject
{
    [SerializeField] private StatIntDictionary intStats = new StatIntDictionary()
    {
        { StatNames.MaxHealthI, 1 },
        { StatNames.DamageI, 1 }
    };

    [SerializeField] private StatFloatDictionary floatStats = new StatFloatDictionary()
    {
        { StatNames.MoveSpeedF, 1 }
    };

    public int Damage => intStats[StatNames.DamageI];
    public int MaxHealth => intStats[StatNames.MaxHealthI];
    public float MoveSpeed => floatStats[StatNames.MoveSpeedF];
}