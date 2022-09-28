using UnityEngine;

public class NewCharacterStats : MonoBehaviour
{
    [SerializeField] private CharacterStatsSO baseCharacterStats;
    [SerializeField] private StatFloatDictionary floatDictionaryBuffs = new StatFloatDictionary();
    [SerializeField] private StatFloatDictionary floatDictionaryDeBuffs = new StatFloatDictionary();
    [SerializeField] private StatIntDictionary intDictionaryBuffs = new StatIntDictionary();
    [SerializeField] private StatIntDictionary intDictionaryDeBuffs = new StatIntDictionary();

    #region Min Total Variable Value

    // Min Variable Amounts
    private const int MIN_MAX_HEALTH = 1;
    private const int MIN_SPREAD = 0;
    private const int MIN_DAMAGE = 0;
    private const int MIN_PIERCE = 0;
    private const float MIN_FIRE_RATE = 0.1f;
    private const float MIN_KNOCK_BACK = 0f;
    private const float MIN_MOVE_SPEED = 0f;

    #endregion

    // Total Base+Buff-Debuff
    public int MaxHealth => CalculateTotalMaxHealth();
    public int TotalSimultaneousArrows => CalculateTotalSpread();
    public int TotalAttackDamage => CalculateTotalDamage();
    public int TotalAttackPierce => CalculateTotalPierce();
    public float TotalFireRate => CalculateTotalFireRate();
    public float TotalAttackKnockBack => CalculateTotalKnockBack();
    public float TotalMoveSpeed => CalculateTotalMoveSpeed();

    private void Start()
    {
        SetupStatDictionaries();
        ResetAllModifiers();
    }

    private int CalculateTotalMaxHealth()
    {
        return Mathf.Max(baseCharacterStats.MaxHealth +
                         intDictionaryBuffs[StatNames.MaxHealthI] -
                         intDictionaryDeBuffs[StatNames.MaxHealthI], MIN_MAX_HEALTH);
    }

    public void TemporaryMaxHealthModifier()
    {
    }

    private int CalculateTotalSpread()
    {
        return Mathf.Max(baseCharacterStats.Spread +
                         intDictionaryBuffs[StatNames.SpreadI] -
                         intDictionaryDeBuffs[StatNames.SpreadI], MIN_SPREAD);
    }

    private int CalculateTotalDamage()
    {
        return Mathf.Max(baseCharacterStats.Damage +
                         intDictionaryBuffs[StatNames.DamageI] -
                         intDictionaryDeBuffs[StatNames.DamageI], MIN_DAMAGE);
    }

    private int CalculateTotalPierce()
    {
        return Mathf.Max(baseCharacterStats.Pierce +
                         intDictionaryBuffs[StatNames.PierceI] -
                         intDictionaryDeBuffs[StatNames.PierceI], MIN_PIERCE);
    }

    private float CalculateTotalFireRate()
    {
        return Mathf.Max(baseCharacterStats.FireRate +
                         floatDictionaryBuffs[StatNames.FireRateF] -
                         floatDictionaryDeBuffs[StatNames.FireRateF], MIN_FIRE_RATE);
    }

    private float CalculateTotalKnockBack()
    {
        return Mathf.Max(baseCharacterStats.KnockBack +
                         floatDictionaryBuffs[StatNames.KnockBackF] -
                         floatDictionaryDeBuffs[StatNames.KnockBackF], MIN_KNOCK_BACK);
    }

    private float CalculateTotalMoveSpeed()
    {
        return Mathf.Max(baseCharacterStats.MoveSpeed +
                         floatDictionaryBuffs[StatNames.MoveSpeedF] -
                         floatDictionaryDeBuffs[StatNames.MoveSpeedF], MIN_MOVE_SPEED);
    }

    [ContextMenu("Setup Dictionaries")]
    private void SetupStatDictionaries()
    {
        var originalFloat = baseCharacterStats.FloatStatsDic;
        var originalInt = baseCharacterStats.IntStatDic;
        CopyDictionaryFloat(originalFloat, floatDictionaryBuffs);
        CopyDictionaryFloat(originalFloat, floatDictionaryDeBuffs);
        CopyDictionaryInt(originalInt, intDictionaryBuffs);
        CopyDictionaryInt(originalInt, intDictionaryDeBuffs);
    }

    private void CopyDictionaryInt(StatIntDictionary original, StatIntDictionary copied)
    {
        foreach (var pair in original)
        {
            var pairKey = pair.Key;
            if (!copied.ContainsKey(pairKey)) copied.Add(pair);
        }
    }

    private void CopyDictionaryFloat(StatFloatDictionary original, StatFloatDictionary copied)
    {
        foreach (var pair in original)
        {
            var pairKey = pair.Key;
            if (!copied.ContainsKey(pairKey)) copied.Add(pair);
        }
    }

    public void ChangeModifier(StatNames stat, bool isBuff, int intValue = int.MinValue,
        float floatValue = float.MinValue)
    {
        if (isBuff)
        {
            if (intValue != int.MinValue)
                if (intDictionaryBuffs.ContainsKey(stat))
                    intDictionaryBuffs[stat] += intValue;

            if (!(floatValue > float.MinValue)) return;
            if (floatDictionaryBuffs.ContainsKey(stat))
                floatDictionaryBuffs[stat] += floatValue;
        }
        else
        {
            if (intValue != int.MinValue)
                if (intDictionaryDeBuffs.ContainsKey(stat))
                    intDictionaryDeBuffs[stat] += intValue;

            if (!(floatValue > float.MinValue)) return;
            if (floatDictionaryDeBuffs.ContainsKey(stat))
                floatDictionaryDeBuffs[stat] += floatValue;
        }
    }

    [ContextMenu("ResetModifiers")]
    public void ResetAllModifiers()
    {
        ResetBuffs();
        ResetDeBuffs();
    }

    public void ResetBuffs()
    {
        foreach (var pair in baseCharacterStats.IntStatDic)
        {
            var key = pair.Key;
            if (intDictionaryBuffs.ContainsKey(key)) intDictionaryBuffs[key] = 0;
        }

        foreach (var pair in baseCharacterStats.FloatStatsDic)
        {
            var key = pair.Key;
            if (floatDictionaryBuffs.ContainsKey(key)) floatDictionaryBuffs[key] = 0;
        }
    }

    public void ResetDeBuffs()
    {
        foreach (var pair in baseCharacterStats.IntStatDic)
        {
            var key = pair.Key;
            if (intDictionaryDeBuffs.ContainsKey(key)) intDictionaryDeBuffs[key] = 0;
        }

        foreach (var pair in baseCharacterStats.FloatStatsDic)
        {
            var key = pair.Key;
            if (floatDictionaryDeBuffs.ContainsKey(key)) floatDictionaryDeBuffs[key] = 0;
        }
    }
}