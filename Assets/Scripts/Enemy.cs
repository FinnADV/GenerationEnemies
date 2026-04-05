using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private Vector3 _moveDirection;

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime,Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Wall>(out _))
        {
           gameObject.SetActive(false);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _moveDirection = direction.normalized;

        if (_moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_moveDirection);
        }
    }
}