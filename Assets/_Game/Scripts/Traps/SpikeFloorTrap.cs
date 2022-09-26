using UnityEngine;

namespace Traps
{
    public class SpikeFloorTrap : MonoBehaviour
    {
        [SerializeField] private float spikesRaiseTime = 1;
        [SerializeField] private float spikesDownTime = 1;
        [SerializeField] private int trapDamage = 1;


        private float _currSpikeCountRaise;
        private bool _countRaise;
        private float _currSpikeCountDown;
        private bool _countDown;
        private Animator _animator;
        private static readonly int Raise = Animator.StringToHash("Raise");
        private static readonly int Down = Animator.StringToHash("Down");
        private DamageTrigger _damageTrigger;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _damageTrigger = GetComponentInChildren<DamageTrigger>();
        }

        private void Start()
        {
            ResetTimers();
            _damageTrigger.SetDamage(trapDamage);
        }

        private void Update()
        {
            RaiseTimer();
            DownTimer();
        }

        private void ResetTimers()
        {
            _currSpikeCountRaise = spikesRaiseTime;
            _currSpikeCountDown = spikesDownTime;
        }

        private void RaiseSpikes()
        {
            _animator.SetBool(Raise, true);
            _animator.SetBool(Down, false);
        }

        // Animation Event
        private void RaiseCompleteEvent()
        {
            _countRaise = false;
            _countDown = true;
        }

        private void DownSpikes()
        {
            _animator.SetBool(Raise, false);
            _animator.SetBool(Down, true);
        }

        // Animation Event
        private void DownCompleteEvent()
        {
            _countDown = false;
            ResetTimers();
        }

        private void DownTimer()
        {
            if (!_countDown) return;
            if (_currSpikeCountDown > 0) _currSpikeCountDown -= Time.deltaTime;
            if (_currSpikeCountDown <= 0) DownSpikes();
        }

        private void RaiseTimer()
        {
            if (!_countRaise) return;
            if (_currSpikeCountRaise > 0) _currSpikeCountRaise -= Time.deltaTime;
            if (_currSpikeCountRaise <= 0) RaiseSpikes();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_countDown && !_countRaise) _countRaise = true;
        }

        private void OnTriggerStay(Collider other)
        {
            if (!_countDown && !_countRaise) _countRaise = true;
        }
    }
}