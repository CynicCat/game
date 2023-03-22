using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPosionBuff : BuffBase
{

    private GameObject BuffPosionPrefab;
    private GameObject newPosionBuffPrefab;
    public override void Launch()
    {
        OnStateFinished += State_PlayPosionBuff_OnStateFinished;
        BuffPosionPrefab = Resources.Load<GameObject>("BuffImage/posion");
        newPosionBuffPrefab = Instantiate(BuffPosionPrefab, transform.position, new Quaternion(0, 0, 0, 0));
        newPosionBuffPrefab.transform.SetParent(transform, false);
        newPosionBuffPrefab.transform.position = new Vector2(transform.position.x - 2.4f, transform.position.y + 4.0f);
        Debug.Log(newPosionBuffPrefab.transform.position.x);
    }
    private void FixedUpdate()
    {
        player.PH.health -=Time.deltaTime;

    }
    private void State_PlayPosionBuff_OnStateFinished()
    {
        Destroy(this); 
        Destroy(newPosionBuffPrefab);
    }
}
