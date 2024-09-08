using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    public Rigidbody Create(int chance)
    {
        GameObject cube;
        int chanceDivider = 2;

        cube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
        cube.transform.localScale /= 2;
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        cube.GetComponent<Cube>().ChanceCreate = chance / chanceDivider;

        return cube.GetComponent<Rigidbody>();
    }
}
