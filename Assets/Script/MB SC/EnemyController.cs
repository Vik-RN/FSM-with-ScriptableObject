using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public StateSO currentState;
    public Transform player;
    public float speed = 2f;
    public float chaseRange = 3f;
    public float attackRange = 1f;

    void Start()
    {
        // Mengeksekusi state awal jika ada
        if (currentState != null)
            currentState.Enter(this);
    }

    void Update()
    {
        if (currentState != null)
        {
            // Debug.Log("State: " + currentState.name); // Aktifkan jika ingin melihat log state
            currentState.Execute(this);
        }
    }

    public void ChangeState(StateSO newState)
    {
        // Keluar dari state saat ini
        if (currentState != null)
            currentState.Exit(this);

        // Mengganti ke state baru
        currentState = newState;

        // Memasuki state baru
        if (currentState != null)
            currentState.Enter(this);
    }

    public float DistanceToPlayer()
    {
        if (player == null) return Mathf.Infinity; // Mencegah error jika player tidak ditemukan
        return Vector2.Distance(transform.position, player.position);
    }
}