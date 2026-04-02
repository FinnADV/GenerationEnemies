using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;

    public Vector3 GetDirection()
    {
        return _direction;
    }
}