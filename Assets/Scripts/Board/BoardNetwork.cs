using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardNetwork : Board
{
    readonly SyncList<int[]> boardList = new SyncList<int[]>();

    public override IList<int[]> BoardList { get { return boardList; } }


    public override void OnStartServer()
    {
        FillBoardList(boardList);
    }


    [Server]
    public override void MoveOnBoard(Vector2Int oldPosition, Vector2Int newPosition, bool nextTurn)
    {
        MoveOnBoard(boardList, oldPosition, newPosition);
        RpcMoveOnBoard(oldPosition, newPosition, nextTurn);
    }


    [ClientRpc]
    void RpcMoveOnBoard(Vector2Int oldPosition, Vector2Int newPosition, bool nextTurn)
    {

        if (NetworkServer.active)

            return;

        MoveOnBoard(boardList, oldPosition, newPosition);

    }
}
