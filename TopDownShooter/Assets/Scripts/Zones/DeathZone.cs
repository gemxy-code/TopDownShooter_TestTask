public class DeathZone : Zone
{
    protected override void Activate()
    {
        EventBus.GameOver();
    }
}
