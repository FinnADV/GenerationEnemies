using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);

            transform.rotation = rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Wall>(out _))
        {
            Destroy(gameObject);
        }
    }
}