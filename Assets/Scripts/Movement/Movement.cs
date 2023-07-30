using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    const float moveSpeed = 0.5f;
    const float jumpHeight = 0.5f;
    SpriteRenderer spriteRenderer;
    Transform jumper;
    TilesLogic actualTile;

    void Start()
    {
        jumper = transform.Find("Jumper");
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public IEnumerator Move(List<TilesLogic> path)
    {
        actualTile = Turn.character.tile;
        actualTile.content = null;

        for (int i = 0; i < path.Count; i++)
        {
            TilesLogic destination = path[i];

            if (actualTile.floor != destination.floor)
            {
                yield return StartCoroutine(Jump(destination));
            }
            else
            {
                yield return StartCoroutine(Walk(destination));
            }

            Turn.character.tile = destination;
        }
    }

    IEnumerator Walk(TilesLogic destination)
    {
        int id = LeanTween.move(transform.gameObject, destination.worldPos, moveSpeed).id;
        actualTile = destination;

        yield return new WaitForSeconds(moveSpeed * 0.5f);
        spriteRenderer.sortingOrder = destination.contentOrder;

        while (LeanTween.descr(id) != null)
        {
            yield return null;
        }

        destination.content = this.gameObject;
    }

    IEnumerator Jump(TilesLogic destination)
    {
        int id1 = LeanTween.move(transform.gameObject, destination.worldPos, moveSpeed).id;
        LeanTween.moveLocalY(jumper.gameObject, jumpHeight, moveSpeed * 0.5f).setLoopPingPong(1).setEase(LeanTweenType.easeInOutQuad);

        float timeOrderUpdate = moveSpeed;

        if (actualTile.floor.tilemap.tileAnchor.y > destination.floor.tilemap.tileAnchor.y)
        {
            timeOrderUpdate *= 0.85f;
        }
        else
        {
            timeOrderUpdate *= 0.2f;
        }
        yield return new WaitForSeconds(timeOrderUpdate);
        actualTile = destination;
        spriteRenderer.sortingOrder = destination.contentOrder;

        while (LeanTween.descr(id1) != null)
        {
            yield return null;
        }

        destination.content = this.gameObject;
    }
}
