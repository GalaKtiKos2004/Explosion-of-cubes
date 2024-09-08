using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private void Explode(Rigidbody cube)
    {
        cube.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}
