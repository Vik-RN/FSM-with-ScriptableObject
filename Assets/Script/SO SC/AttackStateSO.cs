using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Attack")]
public class AttackStateSO : StateSO
{
    public StateSO chaseState;

    public override void Enter(EnemyController enemy)
    {
        Debug.Log("Masuk State: Attack");
    }

    public override void Execute(EnemyController enemy)
    {
        Debug.Log("Menyerang Player!");
        
        // Jika player menjauh dari jarak serang, kembali kejar (Chase)
        if (enemy.DistanceToPlayer() > enemy.attackRange)
        {
            enemy.ChangeState(chaseState);
        }
    }

    public override void Exit(EnemyController enemy) { }
}