using System.Collections;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    [SerializeField] private float _timer = 5f;

    public void Start()
    {
        StartCoroutine(nameof(TimerFadeAway));
    }

    private IEnumerator TimerFadeAway()
    {
        yield return new WaitForSeconds(_timer);
        Fade();
    }

    private void OnTriggerEnter(Collider other)
    {
        StopCoroutine(nameof(TimerFadeAway));
        if (other.TryGetComponent(out CharacterMovement player) && this.TryGetComponent(out IBonused bonus))
        {
            Fade();
        }
    }

    private void Fade()
    {
        Spawner.TakeBack(this.gameObject);
    }
}
