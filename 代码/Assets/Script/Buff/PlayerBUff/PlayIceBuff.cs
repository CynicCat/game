using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayIceBuff : BuffBase
{
    // Start is called before the first frame update

    private GameObject BufficePrefab;
    private GameObject newiceBuffPrefab;
    public override void Launch()
    {
        player.runSpeed *= 0.5f;
        player.PCC.attackDamage *= 0.5f;
        GameController.instance.BulletDamage *= 0.5f;
        OnStateFinished += State_PlayIceBuff_OnStateFinished;


        BufficePrefab = Resources.Load<GameObject>("BuffImage/ice");
        newiceBuffPrefab = Instantiate(BufficePrefab, transform.position, new Quaternion(0, 0, 0, 0));
        newiceBuffPrefab.transform.SetParent(transform, false);
        newiceBuffPrefab.transform.position = new Vector2(transform.position.x+2.4f, transform.position.y + 4.0f);
        Debug.Log(newiceBuffPrefab.transform.localScale);
    }

    private void State_PlayIceBuff_OnStateFinished()
    {
        player.runSpeed /= 0.5f;
        player.PCC.attackDamage /= 0.5f;
        GameController.instance.BulletDamage /= 0.5f;
        Destroy(this);
        Destroy(newiceBuffPrefab);
    }
}
