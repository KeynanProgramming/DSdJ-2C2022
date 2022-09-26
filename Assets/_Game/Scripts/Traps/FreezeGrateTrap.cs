using UnityEngine;

namespace Traps
{
    public class FreezeGrateTrap : MonoBehaviour
    {
        [SerializeField] private float freezeCloudStartDelay = 1;
        [SerializeField] private float freezeCloudStopDelay = 1;
        [SerializeField] private int freezeDamage = 1;
        [SerializeField] private ParticleSystem freezeCloudParticle;

        private float _currStartDelay;
        private float _currStopDelay;
        private bool _countdownStart;
        private bool _countdownStop;
        private DamageTrigger _damageTrigger;

        private void Awake()
        {
            _damageTrigger = GetComponent<DamageTrigger>();
        }

        private void Start()
        {
            _damageTrigger.SetDamage(freezeDamage);
            ResetTimers();
            _currStartDelay = Random.Range(1f, freezeCloudStartDelay);
            _countdownStart = true;
        }

        private void Update()
        {
            FreezeCloudStartTimer();
            FreezeCloudStopTimer();
            CheckParticles();
        }

        private void FreezeCloudStartTimer()
        {
            if (!_countdownStart) return;
            if (_currStartDelay > 0) _currStartDelay -= Time.deltaTime;
            if (_currStartDelay <= 0) StartFreezeCloud();
        }

        private void FreezeCloudStopTimer()
        {
            if (!_countdownStop) return;
            if (_currStopDelay > 0) _currStopDelay -= Time.deltaTime;
            if (_currStopDelay <= 0) StopFreezeCloud();
        }

        private void StartFreezeCloud()
        {
            freezeCloudParticle.Play(true);
            _damageTrigger.TurnCollisionOn();
            _countdownStart = false;
            _countdownStop = true;
        }

        private void StopFreezeCloud()
        {
            freezeCloudParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        private void ResetTimers()
        {
            _currStartDelay = freezeCloudStartDelay;
            _currStopDelay = freezeCloudStopDelay;
        }


        private void CheckParticles()
        {
            if (!_countdownStop) return;
            if (freezeCloudParticle.isEmitting) return;
            _damageTrigger.TurnCollisionOff();
            _countdownStop = false;
            ResetTimers();
            _countdownStart = true;
        }
    }
}