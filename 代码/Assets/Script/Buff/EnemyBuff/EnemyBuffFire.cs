using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuffFire : BaseBuffEnemy
{
    // Start is called before the first frame update
    private GameObject BuffFirePrefab;
    private GameObject newFireBuffPrefab;
    public override void Launch()
    {
        enemy_Health.def *= 2.0f;
        Debug.Log("fireOnEnemy");
        OnStateFinished += State_EnemyBuffIce_OnStateFinished;

        BuffFirePrefab = Resources.Load<GameObject>("BuffImage/fire");
        newFireBuffPrefab = Instantiate(BuffFirePrefab, transform.position, new Quaternion(0, 0, 0, 0));
        newFireBuffPrefab.transform.SetParent(transform, false);

        float changeScale = 1.50f / transform.localScale.x;
        newFireBuffPrefab.transform.localScale = new Vector2(changeScale
            , changeScale);
        newFireBuffPrefab.transform.position = new Vector2(transform.position.x, transform.position.y + 4.0f);
        Debug.Log(newFireBuffPrefab.transform.position.x);

    }
    private void State_EnemyBuffIce_OnStateFinished()
    {
        enemy_Health.def /= 2.0f;
        Destroy(this);
        Destroy(newFireBuffPrefab);

    }
}
