using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    #region Starting Status Variables

    // Base stats
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int simultaneousArrows = 1;
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private int attackPierce = 1;
    [SerializeField] private float attackSpeed = 1;
    [SerializeField] private float attackKnockBack = 1;
    [SerializeField] private float moveSpeed = 5;

    #endregion

    #region Min Total Variable Value

    // Min Variable Amounts
    private const int MIN_SIMULTANEOUS_ARROWS = 1;
    private const int MIN_ATTACK_DAMAGE = 1;
    private const int MIN_ATTACK_PIERCE = 1;
    private const float MIN_ATTACK_SPEED = 0.1f;
    private const float MIN_ATTACK_KNOCK_BACK = 1f;
    private const float MIN_MOVE_SPEED = 1f;

    #endregion

    #region Buff Variables

    // Buffs
    private int _simultaneousArrowsBuff;
    private int _attackDamageBuff;
    private int _attackPierceBuff;
    private float _attackSpeedBuff;
    private float _attackKnockBackBuff;
    private float _moveSpeedBuff;

    #endregion

    #region DeBuff Variables

    // Debuffs
    private int _simultaneousArrowsDeBuff;
    private int _attackDamageDeBuff;
    private int _attackPierceDeBuff;
    private float _attackSpeedDeBuff;
    private float _attackKnockBackDeBuff;
    private float _moveSpeedDeBuff;

    #endregion

    // Total Base+Buff-Debuff
    public int MaxHealth => maxHealth;

    public int TotalSimultaneousArrows =>
        Math.Max(simultaneousArrows + _simultaneousArrowsBuff - _simultaneousArrowsDeBuff, MIN_SIMULTANEOUS_ARROWS);

    public int TotalAttackDamage => Math.Max(attackDamage + _attackDamageBuff - _attackDamageDeBuff, MIN_ATTACK_DAMAGE);
    public int TotalAttackPierce => Math.Max(attackPierce + _attackPierceBuff - _attackPierceDeBuff, MIN_ATTACK_PIERCE);
    public float TotalAttackSpeed => Math.Max(attackSpeed - _attackSpeedBuff + _attackSpeedDeBuff, MIN_ATTACK_SPEED);

    public float TotalAttackKnockBack =>
        Math.Max(attackKnockBack + _attackKnockBackBuff - _attackKnockBackDeBuff, MIN_ATTACK_KNOCK_BACK);

    public float TotalMoveSpeed => Math.Max(moveSpeed + _moveSpeedBuff - _moveSpeedDeBuff, MIN_MOVE_SPEED);

    public void SimultaneousArrowsBuff(int buffAmount)
    {
        _simultaneousArrowsBuff = buffAmount;
    }

    public void SimultaneousArrowsDeBuff(int deBuffAmount)
    {
        _simultaneousArrowsDeBuff = deBuffAmount;
    }

    public void AttackDamageBuff(int buffAmount)
    {
        _attackDamageBuff = buffAmount;
    }

    public void AttackDamageDeBuff(int deBuffAmount)
    {
        _attackDamageDeBuff = deBuffAmount;
    }

    public void AttackPierceBuff(int buffAmount)
    {
        _attackPierceBuff = buffAmount;
    }

    public void AttackPierceDeBuff(int deBuffAmount)
    {
        _attackPierceDeBuff = deBuffAmount;
    }

    public void AttackSpeedBuff(float buffAmount)
    {
        _attackSpeedBuff = buffAmount;
    }

    public void AttackSpeedDeBuff(float deBuffAmount)
    {
        _attackSpeedDeBuff = deBuffAmount;
    }

    public void AttackKnockBackBuff(float buffAmount)
    {
        _attackKnockBackBuff = buffAmount;
    }

    public void AttackKnockBackDeBuff(float deBuffAmount)
    {
        _attackKnockBackDeBuff = deBuffAmount;
    }

    public void MoveSpeedBuff(float buffAmount)
    {
        _moveSpeedBuff = buffAmount;
    }

    public void MoveSpeedDeBuff(float deBuffAmount)
    {
        _moveSpeedDeBuff = deBuffAmount;
    }

    public void ResetModifiers()
    {
        ResetBuffs();
        ResetDeBuffs();
    }

    public void ResetBuffs()
    {
        _simultaneousArrowsBuff = 0;
        _attackDamageBuff = 0;
        _attackPierceBuff = 0;
        _attackSpeedBuff = 0;
        _attackKnockBackBuff = 0;
        _moveSpeedBuff = 0;
    }

    public void ResetDeBuffs()
    {
        _simultaneousArrowsDeBuff = 0;
        _attackDamageDeBuff = 0;
        _attackPierceDeBuff = 0;
        _attackSpeedDeBuff = 0;
        _attackKnockBackDeBuff = 0;
        _moveSpeedDeBuff = 0;
    }
}