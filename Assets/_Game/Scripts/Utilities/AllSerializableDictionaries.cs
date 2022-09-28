using System;

public enum StatNames
{
    SpreadI,
    FireRateF,
    VolleyF,
    PierceI,
    KnockBackF,
    DisruptionF,
    DamageI,
    MaxHealthI,
    MoveSpeedF
}

public abstract class AllSerializableDictionaries
{
}

[Serializable]
public class StatIntDictionary : SerializableDictionary<StatNames, int>
{
}

[Serializable]
public class StatFloatDictionary : SerializableDictionary<StatNames, float>
{
}