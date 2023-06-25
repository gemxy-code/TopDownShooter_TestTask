using UnityEngine;

public class AssaultRifle : MonoBehaviour, IShootable
{
    public void Shoot()
    {
        Debug.Log("я стрел€ю из автомата");
    }
}
