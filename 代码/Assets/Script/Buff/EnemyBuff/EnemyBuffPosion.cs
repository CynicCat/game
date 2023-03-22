using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBuffPosion : BaseBuffEnemy
{
    private GameObject BuffPosionPrefab;
    private GameObject newPosionBuffPrefab;
    // Start is called before the first frame update
    public override void Launch()
    {
        OnStateFinished += State_EnemyBuffIce_OnStateFinished;

        BuffPosionPrefab = Resources.Load<GameObject>("BuffImage/posion");
        newPosionBuffPrefab = Instantiate(BuffPosionPrefab, transform.position, new Quaternion(0, 0, 0, 0));
        newPosionBuffPrefab.transform.SetParent(transform, false);
        float changeScale = 1.50f / transform.localScale.x;
        newPosionBuffPrefab.transform.localScale = new Vector2(changeScale
            , changeScale);
        newPosionBuffPrefab.transform.position = new Vector2(transform.position.x - 2.4f, transform.position.y + 4.0f);
        Debug.Log(newPosionBuffPrefab.transform.position.x);
    }

    private void FixedUpdate()
    {
        enemy_Health._health -= Time.deltaTime * SkillLevel;
        Debug.Log(enemy_Health._health);
    }
    private void State_EnemyBuffIce_OnStateFinished()
    {
        Destroy(this);
        Destroy(newPosionBuffPrefab);
    }
}
