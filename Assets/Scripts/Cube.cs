using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public int ChanceCreate = 100;

    [SerializeField] private CubeCreator _cubeCreator;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private int _minCubeCreate = 2;
    [SerializeField] private int _maxCubeCreate = 6;

    private int _maxChanceCreate = 100;

    private bool IsDivide => Random.Range(0, _maxChanceCreate + 1) < ChanceCreate;

    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    private void OnMouseDown()
    {
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        if (IsDivide)
        {
            int cubeNumbers = Random.Range(_minCubeCreate, _maxCubeCreate + 1);

            for (int i = 0; i < cubeNumbers; i++)
            {
                GameObject cube = _cubeCreator.Create(gameObject);
            }
        }
    }
}
