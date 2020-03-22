using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ChangeValume))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _signal;
    [SerializeField] private ChangeValume _changeValume;

    private void Awake()
    {
        _signal = GetComponent<AudioSource>();
        _changeValume = GetComponent<ChangeValume>();
        _changeValume.enabled = false;
    }

    private void OnTriggerEnter(Collider someBody)
    {
        if (someBody.TryGetComponent(out PlayerMove playerMove))
        {
            _changeValume.enabled = true;
            if (!_signal.isPlaying)
                _signal.Play();
        } 
    }

    private void OnTriggerExit(Collider someBody)
    {
        if (someBody.TryGetComponent(out PlayerMove playerMove))
        { 
            _changeValume.enabled = false;
            if (_signal.isPlaying)
                _signal.Stop();
        }
    }

    private void OnTriggerStay(Collider someBody)
    {
        if (someBody.TryGetComponent(out PlayerMove playerMove))
            if (!_signal.isPlaying)
                _signal.Play();
    }
}
