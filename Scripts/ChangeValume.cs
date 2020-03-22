using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ChangeValume : MonoBehaviour
{
    [Range(0f,.5f)]
    [SerializeField]  private float _startVolume = 0f;
    [Range(.1f, 2f)]
    [SerializeField] private float _stepTime = .5f;

    private AudioSource _audioSource;
    private float _stepUpVolume = 0.1f;
    private float _maxVolume = 1f;
    private float _step = 0f;
    private bool _revers = false;

    private void OnEnable()
    {
        _audioSource.volume = _startVolume;
        _step = 0f;
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_audioSource.volume >= _maxVolume)
            _revers = true;
        else if (_audioSource.volume <= _startVolume)
            _revers = false;

        _step += Time.deltaTime;
       
        if (_step > _stepTime && _revers==false)
        {
            SetVolume(_stepUpVolume,ref _step,ref _audioSource);
        }
        else if (_step > _stepTime && _revers == true)
        {
            SetVolume( -_stepUpVolume, ref _step, ref _audioSource);
        }
    }

    private void SetVolume(float _stepUpVolume, ref float step,ref AudioSource audioSource)
    {
        step = 0;
        audioSource.volume += _stepUpVolume;

    }
}
