using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _minCreate = 2;
    [SerializeField] private int _maxCreate = 6;
    [SerializeField] private int _chanceDivider = 2;
    [SerializeField] private int _scaleDivider = 2;

    private int _maxChanceCreate = 100;
    private int _chanceCreate = 100;

    public event Action<Cube> Dividing;
    public event Action<Cube> Removing;

    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        Explode();
        Destroy(gameObject);
    }

    public void Init()
    {
        transform.localScale /= _scaleDivider;
        _chanceCreate /= _chanceDivider;
    }

    private void Explode()
    {
        Removing?.Invoke(this);

        if (CanDivide())
        {
            int cubeNumbers = UnityEngine.Random.Range(_minCreate, _maxCreate + 1);

            for (int i = 0; i < cubeNumbers; i++)
            {
                Dividing?.Invoke(this);
            }
        }
    }

    private bool CanDivide()
    {
        return UnityEngine.Random.Range(0, _maxChanceCreate + 1) < _chanceCreate;
    }
}
