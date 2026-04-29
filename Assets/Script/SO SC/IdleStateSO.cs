using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Idle")]
public class IdleStateSO : StateSO
{
    public StateSO chaseState;

    public override void Enter(EnemyController enemy)
    {
        Debug.Log("Masuk State: Idle");
    }

    public override void Execute(EnemyController enemy)
    {
        // Jika player masuk ke area deteksi (chase range), ubah ke state Chase
        if (enemy.DistanceToPlayer() < enemy.chaseRange)
        {
            enemy.ChangeState(chaseState);
        }
    }

    public override void Exit(EnemyController enemy) { }
}