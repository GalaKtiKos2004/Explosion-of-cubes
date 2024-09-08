using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    public GameObject Create(GameObject cubePrefab)
    {
        GameObject cube;
        int chanceDivider = 2;

        cube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
        cube.transform.localScale /= 2;
        cube.GetComponent<Cube>().ChanceCreate = cubePrefab.GetComponent<Cube>().ChanceCreate / chanceDivider;

        return cube;
    }
}
