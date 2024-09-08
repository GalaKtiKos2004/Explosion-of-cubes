using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    public GameObject Create(Cube explodedCube)
    {
        GameObject cube;
        int chanceDivider = 2;

        cube = Instantiate(explodedCube.gameObject, transform.position, Quaternion.identity);
        cube.transform.localScale /= 2;
        cube.GetComponent<Cube>().ReduceChance();
        cube.GetComponent<Cube>().ReduceScale();

        return cube;
    }
}
