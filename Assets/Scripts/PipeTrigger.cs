public class PipeTrigger : MonoBehaviour
{
    private bool hasScored = false;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!hasScored && other.CompareTag("Player"))
        {
            hasScored = true;
            GameManager.Instance.IncreaseScore();
            SoundManager.Instance.PlaySwoosh();
        }
    }

    public void ResetTrigger()
    {
        hasScored = false;
    }
}
