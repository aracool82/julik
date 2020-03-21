using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ChangeValume : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _stepTime = 1f;
    private float _stepUpVolume = 0.1f;
    private float _startVolume = 0.5f;
    private float _maxVolume = 1f;
    private float _step = 0f;

    private void OnEnable()
    {
        _audioSource.volume = _startVolume;
        _step = 0f;
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        _step += Time.deltaTime;
        if (_step > _stepTime && _audioSource.volume < _maxVolume)
        {
            _step = 0f;
            _audioSource.volume += _stepUpVolume;
        }
    }
}
