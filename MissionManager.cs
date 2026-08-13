using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public bool RelicCollected { get; private set; }

    public void CollectRelic()
    {
        RelicCollected = true;
    }

    public bool CanEscape()
    {
        return RelicCollected;
    }
}
