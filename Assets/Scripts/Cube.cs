using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public int ChanceCreate = 100;

    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private CubeCreator _cubeCreator;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private int _minCubeCreate = 2;
    [SerializeField] private int _maxCubeCreate = 6;

    private int _maxChanceCreate = 100;
    private bool _isDivide => Utils.GetRandomInt(0, _maxChanceCreate) < ChanceCreate;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(_ray, out hit, Mathf.Infinity) && hit.transform.gameObject == gameObject)
            {
                Explode();
                Destroy(gameObject);
            }
        }
    }

    private void Explode()
    {
        if (_isDivide)
        {
            int cubeNumbers = Utils.GetRandomInt(_minCubeCreate, _maxCubeCreate);

            for (int i = 0; i < cubeNumbers; i++)
                _cubeCreator.Create(ChanceCreate).AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
