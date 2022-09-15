using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int simultaneousArrows = 1;
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private int attackPierce = 1;
    [SerializeField] private float attackSpeed = 1;
    [SerializeField] private float attackKnockBack = 1;
    [SerializeField] private float arrowSpreadDegrees = 1;

    private int _simultaneousArrowsBuff;
    private int _attackDamageBuff;
    private int _attackPierceBuff;
    private float _attackSpeedBuff;
    private float _attackKnockBackBuff;
    private float _arrowSpreadDegreesBuff;

    public int TotalSimultaneousArrows => simultaneousArrows + _simultaneousArrowsBuff;
    public int TotalAttackDamage => attackDamage + _attackDamageBuff;
    public int TotalAttackPierce => attackPierce + _attackPierceBuff;
    public float TotalAttackSpeed => attackSpeed + _attackSpeedBuff;
    public float TotalAttackKnockBack => attackKnockBack + _attackKnockBackBuff;
    public float TotalArrowSpreadDegreesArrows => arrowSpreadDegrees + _arrowSpreadDegreesBuff;

    public void SimultaneousArrowsBuff(int buffAmount)
    {
        _simultaneousArrowsBuff = buffAmount;
    }

    public void SimultaneousArrowsDeBuff(int deBuffAmount)
    {
        _simultaneousArrowsBuff = deBuffAmount;
    }

    public void AttackDamageBuff(int buffAmount)
    {
        _attackDamageBuff = buffAmount;
    }
    
    public void AttackDamageDeBuff(int deBuffAmount)
    {
        _attackDamageBuff = deBuffAmount;
    }

    public void AttackPierceBuff(int buffAmount)
    {
        _attackPierceBuff = buffAmount;
    }
    
    public void AttackPierceDeBuff(int deBuffAmount)
    {
        _attackPierceBuff = deBuffAmount;
    }

    public void AttackSpeedBuff(float buffAmount)
    {
        _attackSpeedBuff = buffAmount;
    }
    
    public void AttackSpeedDeBuff(float deBuffAmount)
    {
        _attackSpeedBuff = deBuffAmount;
    }

    public void AttackKnockBackBuff(float buffAmount)
    {
        _attackKnockBackBuff = buffAmount;
    }
    
    public void AttackKnockBackDeBuff(float deBuffAmount)
    {
        _attackKnockBackBuff = deBuffAmount;
    }
    
    public void ArrowSpreadDegreesBuff(float buffAmount)
    {
        _arrowSpreadDegreesBuff = buffAmount;
    }
    
    public void ArrowSpreadDegreesDeBuff(float deBuffAmount)
    {
        _arrowSpreadDegreesBuff = deBuffAmount;
    }
}
