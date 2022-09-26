using UnityEngine;

namespace Traps
{
    public class FireGrateTrap : MonoBehaviour
    {
        [SerializeField] private float fireCloudStartDelay = 1;
        [SerializeField] private float fireCloudStopDelay = 1;
        [SerializeField] private int fireDamage = 1;
        [SerializeField] private ParticleSystem fireCloudParticle;

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
            _damageTrigger.SetDamage(fireDamage);
            ResetTimers();
            _countdownStart = true;
        }

        private void Update()
        {
            FireCloudStartTimer();
            FireCloudStopTimer();
            CheckParticles();
        }

        private void FireCloudStartTimer()
        {
            if (!_countdownStart) return;
            if (_currStartDelay > 0) _currStartDelay -= Time.deltaTime;
            if (_currStartDelay <= 0) StartFireCloud();
        }

        private void FireCloudStopTimer()
        {
            if (!_countdownStop) return;
            if (_currStopDelay > 0) _currStopDelay -= Time.deltaTime;
            if (_currStopDelay <= 0) StopFireCloud();
        }

        private void StartFireCloud()
        {
            fireCloudParticle.Play(true);
            _damageTrigger.TurnCollisionOn();
            _countdownStart = false;
            _countdownStop = true;
        }

        private void StopFireCloud()
        {
            fireCloudParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        private void ResetTimers()
        {
            _currStartDelay = fireCloudStartDelay;
            _currStopDelay = fireCloudStopDelay;
        }

        // fireCloudParticle.IsAlive()
        private void CheckParticles()
        {
            if (!_countdownStop) return;
            if (fireCloudParticle.isEmitting) return;
            _damageTrigger.TurnCollisionOff();
            _countdownStop = false;
            ResetTimers();
            _countdownStart = true;
        }
    }
}