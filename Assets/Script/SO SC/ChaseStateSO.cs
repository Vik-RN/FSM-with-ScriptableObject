using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Chase")]
public class ChaseStateSO : StateSO
{
    public StateSO idleState;
    public StateSO attackState;

    public override void Enter(EnemyController enemy)
    {
        Debug.Log("Masuk State: Chase");
    }

    public override void Execute(EnemyController enemy)
    {
        // Logika pergerakan mendekati player
        enemy.transform.position = Vector2.MoveTowards(
            enemy.transform.position,
            enemy.player.position,
            enemy.speed * Time.deltaTime
        );

        float distance = enemy.DistanceToPlayer();

        // Transisi ke Attack jika sangat dekat, atau kembali ke Idle jika player menjauh
        if (distance < enemy.attackRange)
        {
            enemy.ChangeState(attackState);
        }
        else if (distance > enemy.chaseRange)
        {
            enemy.ChangeState(idleState);
        }
    }

    public override void Exit(EnemyController enemy) { }
}