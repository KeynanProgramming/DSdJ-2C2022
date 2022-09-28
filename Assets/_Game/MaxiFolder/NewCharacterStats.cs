using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCharacterStats : MonoBehaviour
{
    [SerializeField] private CharacterStatsSO baseCharacterStats;

    [Header("Current Modifiers")] [Space(5)] [SerializeField]
    private StatFloatDictionary floatDictionaryBuffs = new StatFloatDictionary();

    [SerializeField] private StatFloatDictionary floatDictionaryDeBuffs = new StatFloatDictionary();
    [SerializeField] private StatFloatDictionary floatDictionaryTempBuffs = new StatFloatDictionary();
    [SerializeField] private StatFloatDictionary floatDictionaryTempDeBuffs = new StatFloatDictionary();
    [SerializeField] private StatIntDictionary intDictionaryBuffs = new StatIntDictionary();
    [SerializeField] private StatIntDictionary intDictionaryDeBuffs = new StatIntDictionary();
    [SerializeField] private StatIntDictionary intDictionaryTempBuffs = new StatIntDictionary();
    [SerializeField] private StatIntDictionary intDictionaryTempDeBuffs = new StatIntDictionary();

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
        var buffs = intDictionaryBuffs[StatNames.MaxHealthI] + intDictionaryTempBuffs[StatNames.MaxHealthI];
        var deBuffs = intDictionaryDeBuffs[StatNames.MaxHealthI] + intDictionaryTempDeBuffs[StatNames.MaxHealthI];
        var minValue = Mathf.Max(baseCharacterStats.MaxHealth + buffs - deBuffs, MIN_MAX_HEALTH);
        return Mathf.Min(minValue, 999);
    }

    private int CalculateTotalSpread()
    {
        var buffs = intDictionaryBuffs[StatNames.SpreadI] + intDictionaryTempBuffs[StatNames.SpreadI];
        var deBuffs = intDictionaryDeBuffs[StatNames.SpreadI] + intDictionaryTempDeBuffs[StatNames.SpreadI];
        var minValue = Mathf.Max(baseCharacterStats.Spread + buffs - deBuffs, MIN_SPREAD);
        return Mathf.Min(minValue, 5);
    }

    private int CalculateTotalDamage()
    {
        var buffs = intDictionaryBuffs[StatNames.DamageI] + intDictionaryTempBuffs[StatNames.DamageI];
        var deBuffs = intDictionaryDeBuffs[StatNames.DamageI] + intDictionaryTempDeBuffs[StatNames.DamageI];
        var minValue = Mathf.Max(baseCharacterStats.Damage + buffs - deBuffs, MIN_DAMAGE);
        return Mathf.Min(minValue, 999);
    }

    private int CalculateTotalPierce()
    {
        var buffs = intDictionaryBuffs[StatNames.PierceI] + intDictionaryTempBuffs[StatNames.PierceI];
        var deBuffs = intDictionaryDeBuffs[StatNames.PierceI] + intDictionaryTempDeBuffs[StatNames.PierceI];
        var minValue = Mathf.Max(baseCharacterStats.Pierce + buffs - deBuffs, MIN_PIERCE);
        return Mathf.Min(minValue, 999);
    }

    private float CalculateTotalFireRate()
    {
        var buffs = floatDictionaryBuffs[StatNames.FireRateF] + floatDictionaryTempBuffs[StatNames.FireRateF];
        var deBuffs = floatDictionaryDeBuffs[StatNames.FireRateF] + floatDictionaryTempDeBuffs[StatNames.FireRateF];
        var minValue = Mathf.Max(baseCharacterStats.FireRate + buffs - deBuffs, MIN_FIRE_RATE);
        return Mathf.Min(minValue, 999);
    }

    private float CalculateTotalKnockBack()
    {
        var buffs = floatDictionaryBuffs[StatNames.KnockBackF] + floatDictionaryTempBuffs[StatNames.KnockBackF];
        var deBuffs = floatDictionaryDeBuffs[StatNames.KnockBackF] + floatDictionaryTempDeBuffs[StatNames.KnockBackF];
        var minValue = Mathf.Max(baseCharacterStats.KnockBack + buffs - deBuffs, MIN_KNOCK_BACK);
        return Mathf.Min(minValue, 999);
    }

    private float CalculateTotalMoveSpeed()
    {
        var buffs = floatDictionaryBuffs[StatNames.MoveSpeedF] + floatDictionaryTempBuffs[StatNames.MoveSpeedF];
        var deBuffs = floatDictionaryDeBuffs[StatNames.MoveSpeedF] + floatDictionaryTempDeBuffs[StatNames.MoveSpeedF];
        var minValue = Mathf.Max(baseCharacterStats.MoveSpeed + buffs - deBuffs, MIN_MOVE_SPEED);
        return Mathf.Min(minValue, 20);
    }

    [ContextMenu("Setup Dictionaries")]
    private void SetupStatDictionaries()
    {
        var originalFloat = baseCharacterStats.FloatStatsDic;
        var originalInt = baseCharacterStats.IntStatDic;
        CopyDictionaryFloat(originalFloat, floatDictionaryBuffs);
        CopyDictionaryFloat(originalFloat, floatDictionaryTempBuffs);
        CopyDictionaryFloat(originalFloat, floatDictionaryDeBuffs);
        CopyDictionaryFloat(originalFloat, floatDictionaryTempDeBuffs);
        CopyDictionaryInt(originalInt, intDictionaryBuffs);
        CopyDictionaryInt(originalInt, intDictionaryTempBuffs);
        CopyDictionaryInt(originalInt, intDictionaryDeBuffs);
        CopyDictionaryInt(originalInt, intDictionaryTempDeBuffs);
    }

    public void ChangeModifier(StatNames stat, bool isBuff, int intValue = int.MinValue,
        float floatValue = float.MinValue, bool isTemporal = false, float tempDuration = 0f)
    {
        if (tempDuration > 0)
            StartCoroutine(ModifierCountdown(tempDuration, stat, isBuff, intValue, floatValue, isTemporal));

        if (isBuff)
        {
            if (intValue != int.MinValue)
                AddIntToDictionaryKey(isTemporal ? intDictionaryTempBuffs : intDictionaryBuffs, stat, intValue);

            if (!(floatValue > float.MinValue)) return;
            AddFloatToDictionaryKey(isTemporal ? floatDictionaryTempBuffs : floatDictionaryBuffs, stat, floatValue);
        }
        else
        {
            if (intValue != int.MinValue)
                AddIntToDictionaryKey(isTemporal ? intDictionaryTempDeBuffs : intDictionaryDeBuffs, stat, intValue);

            if (!(floatValue > float.MinValue)) return;
            AddFloatToDictionaryKey(isTemporal ? floatDictionaryTempDeBuffs : floatDictionaryDeBuffs, stat, floatValue);
        }
    }

    private IEnumerator ModifierCountdown(float duration, StatNames stat, bool isBuff, int intValue, float floatValue,
        bool isTemporal)
    {
        var currCount = 0f;
        while (currCount <= duration)
        {
            currCount += Time.deltaTime;
            yield return null;
        }

        var nInt = intValue == int.MinValue ? int.MinValue : intValue * -1;
        var nFloat = floatValue > float.MinValue ? floatValue * -1 : float.MinValue;
        ChangeModifier(stat, isBuff, nInt, nFloat, isTemporal);
    }

    [ContextMenu("ResetModifiers")]
    public void ResetAllModifiers()
    {
        ResetBuffs();
        ResetDeBuffs();
    }

    public void ResetBuffs()
    {
        ResetIntDic(intDictionaryBuffs);
        ResetIntDic(intDictionaryTempBuffs);
        ResetFloatDic(floatDictionaryBuffs);
        ResetFloatDic(floatDictionaryTempBuffs);
    }

    public void ResetDeBuffs()
    {
        ResetIntDic(intDictionaryDeBuffs);
        ResetIntDic(intDictionaryTempDeBuffs);
        ResetFloatDic(floatDictionaryDeBuffs);
        ResetFloatDic(floatDictionaryTempDeBuffs);
    }

    private void ResetIntDic(StatIntDictionary intDictionary)
    {
        foreach (var pair in baseCharacterStats.IntStatDic)
        {
            var key = pair.Key;
            if (intDictionary.ContainsKey(key)) intDictionary[key] = 0;
        }
    }

    private void ResetFloatDic(StatFloatDictionary floatDictionary)
    {
        foreach (var pair in baseCharacterStats.FloatStatsDic)
        {
            var key = pair.Key;
            if (floatDictionary.ContainsKey(key)) floatDictionary[key] = 0;
        }
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

    private void AddIntToDictionaryKey(StatIntDictionary intDictionary, StatNames key, int valueAdded)
    {
        if (intDictionary.ContainsKey(key))
            intDictionary[key] += valueAdded;
    }

    private void AddFloatToDictionaryKey(StatFloatDictionary floatDictionary, StatNames key, float valueAdded)
    {
        if (floatDictionary.ContainsKey(key))
            floatDictionary[key] += valueAdded;
    }
}