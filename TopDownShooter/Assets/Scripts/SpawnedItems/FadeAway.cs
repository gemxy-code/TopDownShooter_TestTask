using System.Collections;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    [SerializeField] private float _timer = 5f;

    private void OnEnable()
    {
        StartCoroutine(TimerFadeAway());
    }

    private IEnumerator TimerFadeAway()
    {
        yield return new WaitForSeconds(_timer);
        Spawner.TakBack(this.gameObject);
    }


}
