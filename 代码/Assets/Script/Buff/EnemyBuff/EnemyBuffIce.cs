using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuffIce : BaseBuffEnemy
{
    // Start is called before the first frame update
    private GameObject BufficePrefab;
    private GameObject newiceBuffPrefab;
    public override void Launch()
    {
        enemy_Walk.walkSpeed *= 0.5f;
        OnStateFinished += State_EnemyBuffIce_OnStateFinished;

        BufficePrefab = Resources.Load<GameObject>("BuffImage/ice");
        newiceBuffPrefab = Instantiate(BufficePrefab);
        newiceBuffPrefab.transform.SetParent(transform, false);
        float changeScale = 1.50f / transform.localScale.x;
        newiceBuffPrefab.transform.localScale = new Vector2(changeScale
            , changeScale);
        newiceBuffPrefab.transform.position = new Vector2(transform.position.x + 2.4f, transform.position.y + 4.0f);
        Debug.Log(newiceBuffPrefab.transform.position.x);
    }

    private void State_EnemyBuffIce_OnStateFinished()
    {
        enemy_Walk.walkSpeed /= 0.5f;
        Destroy(this);
        Destroy(newiceBuffPrefab);
    }
}
