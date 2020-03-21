using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    private AudioSource _signal;
    private ChangeValume _changeValume;

    private void Awake()
    {
        _signal = GetComponent<AudioSource>();
        _changeValume = GetComponent<ChangeValume>();
        _changeValume.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _changeValume.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_signal.isPlaying)
            { 
                _signal.Stop();
                _changeValume.enabled = false;            
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_signal.isPlaying)
                return;
            _signal.Play();
        }
    }
}
