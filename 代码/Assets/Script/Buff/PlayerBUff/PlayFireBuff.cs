using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFireBuff : BuffBase
{
    // Start is called before the first frame update
    private GameObject BuffFirePrefab;
    private GameObject newFireBuffPrefab;
    public override void Launch()
    {
        player.PH.fixedDamage *= 2.0f;
        OnStateFinished += State_PlayIceBuff_OnStateFinished;

        BuffFirePrefab = Resources.Load<GameObject>("BuffImage/fire");
        newFireBuffPrefab = Instantiate(BuffFirePrefab, transform.position, new Quaternion(0, 0, 0, 0));
        newFireBuffPrefab.transform.SetParent(transform, false);
        newFireBuffPrefab.transform.position = new Vector2(transform.position.x, transform.position.y+4.0f);
        Debug.Log(newFireBuffPrefab.transform.position.x);

    }

    private void State_PlayIceBuff_OnStateFinished()
    {
        player.PH.fixedDamage /= 2.0f;
        Destroy(this);
        Destroy(newFireBuffPrefab);
    }
}
