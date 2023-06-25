using UnityEngine;

public class Factory : MonoBehaviour
{
    public static GameObject CreateProduct(GameObject Object)
    {
        GameObject newProduct = Instantiate(Object);
        newProduct.name = Object.name;
        return newProduct;
    }
}
