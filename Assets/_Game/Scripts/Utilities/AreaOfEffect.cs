using System.Collections;
using System.Drawing;
using UnityEngine;

public class AreaOfEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle1;
    [SerializeField] private ParticleSystem particle2;
    [SerializeField] private DamageTrigger damageTrigger;
    private SphereCollider _sphereCollider;
    private AnimationCurve _curve = new AnimationCurve();

    public float AreaSize { get; private set; }
    public int Damage { get; private set; }
    public float AreaDuration { get; private set; }

    [ContextMenu("Full Test")]
    private void FullActivation()
    {
        Init(AreaSize, Damage, AreaDuration);
        ChangeSize();
        StartParticle();
    }

    private void Awake()
    {
        damageTrigger = GetComponent<DamageTrigger>();
        _sphereCollider = GetComponent<SphereCollider>();
    }

    public void Init(float areaSize, int damage, float areaDuration)
    {
        AreaSize = areaSize;
        Damage = damage;
        AreaDuration = areaDuration;
        damageTrigger.SetDamage(Damage);
        ChangeSize();
        StartParticle();
    }

    private void StartParticle()
    {
        ChangeDuration(AreaDuration);
        particle1.Play(true);
        StartCoroutine(GrowCollider(AreaDuration));
        Destroy(gameObject, AreaDuration);
    }

    private IEnumerator GrowCollider(float duration)
    {
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            _sphereCollider.radius = _curve.Evaluate(normalizedTime);
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
    }

    private void ChangeSize()
    {
        var sz = particle1.sizeOverLifetime;
        var sz2 = particle2.sizeOverLifetime;

        _curve.AddKey(0.0f, 0.1f);
        _curve.AddKey(0.25f, AreaSize);

        sz.size = new ParticleSystem.MinMaxCurve(1f, _curve);
        sz2.size = new ParticleSystem.MinMaxCurve(1f, _curve);
    }

    private void ChangeDuration(float duration)
    {
        var sz = particle1.main;
        var sz2 = particle2.main;

        sz.duration = duration;
        sz2.duration = duration;
        sz.startLifetime = duration;
        sz2.startLifetime = duration;
    }
}