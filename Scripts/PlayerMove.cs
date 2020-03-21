using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed=4;
    private float _horisontal;
    private float _vertical;
    private float _step;
    
    private void Update()
    {
        _step = Time.deltaTime * _speed;
        _horisontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(-_vertical, 0, _horisontal) * _step);
    }
}
