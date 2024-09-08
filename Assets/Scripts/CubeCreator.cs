using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    private void OnEnable()
    {
        foreach (var cube in FindObjectsOfType<Cube>())
        {
            cube.Dividing += Create;
        }
    }

    private void OnDisable()
    {
        foreach (var cube in FindObjectsOfType<Cube>())
        {
            cube.Dividing -= Create;
        }
    }

    public void Create(Cube explodedCube)
    {
        Cube cube;

        cube = Instantiate(explodedCube, explodedCube.transform.position, Quaternion.identity);
        cube.Dividing += Create;
        cube.ReduceScale();
        cube.ReduceChance();
    }
}
