using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.IncreaseScore();
            SoundManager.Instance.PlaySwoosh();
        }
    }
}
