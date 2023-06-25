using UnityEngine;

public class Pistol : MonoBehaviour, IShootable
{
    public void Shoot()
    {
        Debug.Log("я стрел€ю из пистолета");
    }
}
