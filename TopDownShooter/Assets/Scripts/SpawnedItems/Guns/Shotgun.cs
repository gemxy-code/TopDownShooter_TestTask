using UnityEngine;

public class Shotgun : MonoBehaviour, IShootable
{
    public void Shoot()
    {
        Debug.Log("я стрел€ю из дробовика");
    }
}
