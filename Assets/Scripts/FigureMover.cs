using UnityEngine;
using System.Collections.Generic;

public class FigureMover : MonoBehaviour
{
    public FigureType type;
    public bool isWhite;
    public int PossibleMovesPerType;
    public int PossibleMovesPerPiece;
    public bool CanCastling;
    public bool Checked = false;
    public bool Mated = false;
    public List<Vector3> PossibleMoves;

    public delegate List<Vector3> GetMoves(Vector3 position);

    public List<Vector3> MovementPawn(Vector3 position)
    {
        PossibleMovesPerType = 4;
        PossibleMovesPerPiece = 0;
        List<Vector3> moves = new List<Vector3>();
        if (isWhite)
        {
            if (position.z == 1 && MovementManager.CellIsUsedByBlackPiece(position + Vector3.forward) == false && MovementManager.CellIsUsedByBlackPiece(position + Vector3.forward * 2) == false && MovementManager.CellIsUsedByWhitePiece(position + Vector3.forward) == false && MovementManager.CellIsUsedByWhitePiece(position + Vector3.forward * 2) == false)
            {
                PossibleMovesPerPiece++;
                moves.Add((position + new Vector3(0, 0, 2)));
            }
            if (MovementManager.CellIsUsedByBlackPiece((position + new Vector3(1, 0, 1))))
            {
                if(position.x != 7 || position.z != 7)
                {
                    PossibleMovesPerPiece++;
                    moves.Add((position + new Vector3(1, 0, 1)));
                }
            }
            if (MovementManager.CellIsUsedByBlackPiece((position + new Vector3(-1, 0, 1))))
            {
                if(position.x != 0 || position.z != 7)
                {
                    PossibleMovesPerPiece++;
                    moves.Add((position + new Vector3(-1, 0, 1)));
                }
            }
            if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.forward) == false && MovementManager.CellIsUsedByBlackPiece(position + Vector3.forward) == false)
            {
                if(position.z != 7)
                {
                    PossibleMovesPerPiece++;
                    moves.Add(position + Vector3.forward);
                }
            }
        }
        else
        {
            if (position.z == 6 && MovementManager.CellIsUsedByBlackPiece(position + Vector3.back) == false && MovementManager.CellIsUsedByBlackPiece(position + Vector3.back * 2) == false && MovementManager.CellIsUsedByWhitePiece(position + Vector3.back) == false && MovementManager.CellIsUsedByWhitePiece(position + Vector3.back * 2) == false)
            {
                PossibleMovesPerPiece++;
                moves.Add((position + new Vector3(0, 0, 2)));
            }
            if (MovementManager.CellIsUsedByWhitePiece((position + new Vector3(1, 0, -1))))
            {
                if(position.x != 7 || position.z != 0)
                {
                    PossibleMovesPerPiece++;
                    moves.Add((position + new Vector3(1, 0, 1)));
                }
            }
            if (MovementManager.CellIsUsedByWhitePiece((position + new Vector3(-1, 0, -1))))
            {
                if(position.x != 0 || position.z != 0)
                {
                    PossibleMovesPerPiece++;
                    moves.Add((position + new Vector3(-1, 0, 1)));
                }
            }
            if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.back) == false && MovementManager.CellIsUsedByBlackPiece(position + Vector3.back) == false)
            {
                if(position.z != 0)
                {
                    PossibleMovesPerPiece++;
                    moves.Add(position + Vector3.back);
                }
            }
        }
        return moves;
    }

    public List<Vector3> MovementRook(Vector3 position)
    {
        PossibleMovesPerType = 14;
        PossibleMovesPerPiece = 0;
        int i = 1;
        List<Vector3> moves = new List<Vector3>();
        if(isWhite)
        {
            while (1 > 0)
            {
                if ((position + Vector3.forward).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.forward * i) == false)
                {
                    moves.Add(position + Vector3.forward * i);
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.forward * i) == false)
                {
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.forward * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + Vector3.back).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.back * i) == false)
                {
                    moves.Add(position + Vector3.back * i);
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.back * i) == false)
                {
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.back * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + Vector3.right).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.right * i) == false)
                {
                    moves.Add(position + Vector3.right * i);
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.right * i) == false)
                {
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.right * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + Vector3.left).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.left * i) == false)
                {
                    moves.Add(position + Vector3.left * i);
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.left * i) == false)
                {
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.left * i);
                i++;
            }
        }
        else
        {
            while (1 > 0)
            {
                if ((position + Vector3.forward).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.forward * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.forward * i) == false)
                {
                    moves.Add(position + Vector3.forward * i);
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.forward * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + Vector3.back).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.back * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.back * i) == false)
                {
                    moves.Add(position + Vector3.back * i);
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.back * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + Vector3.right).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.right * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.right * i) == false)
                {
                    moves.Add(position + Vector3.right * i);
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.right * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + Vector3.left).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.left * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.left * i) == false)
                {
                    moves.Add(position + Vector3.left * i);
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.left * i);
                i++;
            }
        }
        return moves;
    }

    public List<Vector3> MovementBishop(Vector3 position)
    {
        PossibleMovesPerType = 13;
        PossibleMovesPerPiece = 0;
        int i = 1;
        List<Vector3> moves = new List<Vector3>();
        if (isWhite)
        {
            while (1 > 0)
            {
                if ((position + new Vector3(-1, 0, 1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(-1, 0, 1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(-1, 0, 1) * i) == false)
                {
                    moves.Add(position + new Vector3(-1, 0, 1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(-1, 0, 1) * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + new Vector3(1, 0, 1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(1, 0, 1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(1, 0, 1) * i) == false)
                {
                    moves.Add(position + new Vector3(1, 0, 1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(1, 0, 1) * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + new Vector3(1, 0, -1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(1, 0, -1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(1, 0, -1) * i) == false)
                {
                    moves.Add(position + new Vector3(1, 0, -1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(1, 0, -1) * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + new Vector3(-1, 0, -1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(-1, 0, -1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(-1, 0, -1) * i) == false)
                {
                    moves.Add(position + new Vector3(-1, 0, -1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(-1, 0, -1) * i);
                i++;
            }
        }
        else
        {
            while (1 > 0)
            {
                if ((position + new Vector3(-1, 0, 1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(-1, 0, 1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(-1, 0, 1) * i) == false)
                {
                    moves.Add(position + new Vector3(-1, 0, 1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(-1, 0, 1) * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + new Vector3(1, 0, 1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(1, 0, 1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(1, 0, 1) * i) == false)
                {
                    moves.Add(position + new Vector3(1, 0, 1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(1, 0, 1) * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + new Vector3(1, 0, -1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(1, 0, -1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(1, 0, -1) * i) == false)
                {
                    moves.Add(position + new Vector3(1, 0, -1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(1, 0, -1) * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + new Vector3(-1, 0, -1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(-1, 0, -1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(-1, 0, -1) * i) == false)
                {
                    moves.Add(position + new Vector3(-1, 0, -1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(-1, 0, -1) * i);
                i++;
            }
        }
        return moves;
    }

    public List<Vector3> MovementKnight(Vector3 position)
    {
        PossibleMovesPerType = 8;
        PossibleMovesPerPiece = 0;
        List<Vector3> moves = new List<Vector3>();
        return moves;
    }

    public List<Vector3> MovementQueen(Vector3 position)
    {
        PossibleMovesPerType = 27;
        PossibleMovesPerPiece = 0;
        int i = 1;
        List<Vector3> moves = new List<Vector3>();
        if (isWhite)
        {
            while (1 > 0)
            {
                if ((position + Vector3.forward).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.forward * i) == false)
                {
                    moves.Add(position + Vector3.forward * i);
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.forward * i) == false)
                {
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.forward * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + Vector3.back).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.back * i) == false)
                {
                    moves.Add(position + Vector3.back * i);
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.back * i) == false)
                {
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.back * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + Vector3.right).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.right * i) == false)
                {
                    moves.Add(position + Vector3.right * i);
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.right * i) == false)
                {
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.right * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + Vector3.left).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.left * i) == false)
                {
                    moves.Add(position + Vector3.left * i);
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.left * i) == false)
                {
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.left * i);
                i++;
            }
        }
        else
        {
            while (1 > 0)
            {
                if ((position + Vector3.forward).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.forward * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.forward * i) == false)
                {
                    moves.Add(position + Vector3.forward * i);
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.forward * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + Vector3.back).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.back * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.back * i) == false)
                {
                    moves.Add(position + Vector3.back * i);
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.back * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + Vector3.right).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.right * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.right * i) == false)
                {
                    moves.Add(position + Vector3.right * i);
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.right * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + Vector3.left).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + Vector3.left * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + Vector3.left * i) == false)
                {
                    moves.Add(position + Vector3.left * i);
                    i = 1;
                    break;
                }
                moves.Add(position + Vector3.left * i);
                i++;
            }
        }
        if (isWhite)
        {
            while (1 > 0)
            {
                if ((position + new Vector3(-1, 0, 1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(-1, 0, 1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(-1, 0, 1) * i) == false)
                {
                    moves.Add(position + new Vector3(-1, 0, 1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(-1, 0, 1) * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + new Vector3(1, 0, 1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(1, 0, 1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(1, 0, 1) * i) == false)
                {
                    moves.Add(position + new Vector3(1, 0, 1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(1, 0, 1) * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + new Vector3(1, 0, -1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(1, 0, -1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(1, 0, -1) * i) == false)
                {
                    moves.Add(position + new Vector3(1, 0, -1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(1, 0, -1) * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + new Vector3(-1, 0, -1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(-1, 0, -1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(-1, 0, -1) * i) == false)
                {
                    moves.Add(position + new Vector3(-1, 0, -1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(-1, 0, -1) * i);
                i++;
            }
        }
        else
        {
            while (1 > 0)
            {
                if ((position + new Vector3(-1, 0, 1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(-1, 0, 1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(-1, 0, 1) * i) == false)
                {
                    moves.Add(position + new Vector3(-1, 0, 1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(-1, 0, 1) * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + new Vector3(1, 0, 1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(1, 0, 1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(1, 0, 1) * i) == false)
                {
                    moves.Add(position + new Vector3(1, 0, 1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(1, 0, 1) * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + new Vector3(1, 0, -1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(1, 0, -1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(1, 0, -1) * i) == false)
                {
                    moves.Add(position + new Vector3(1, 0, -1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(1, 0, -1) * i);
                i++;
            }
            while (1 > 0)
            {
                if ((position + new Vector3(-1, 0, -1)).z > 7)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByBlackPiece(position + new Vector3(-1, 0, -1) * i) == false)
                {
                    i = 1;
                    break;
                }
                if (MovementManager.CellIsUsedByWhitePiece(position + new Vector3(-1, 0, -1) * i) == false)
                {
                    moves.Add(position + new Vector3(-1, 0, -1) * i);
                    i = 1;
                    break;
                }
                moves.Add(position + new Vector3(-1, 0, -1) * i);
                i++;
            }
        }
        return moves;
    }

    public List<Vector3> MovementKing(Vector3 position)
    {
        PossibleMovesPerType = 10;
        PossibleMovesPerPiece = 0;
        List<Vector3> moves = new List<Vector3>();
        return moves;
    }

    private void Awake()
    {
        PossibleMoves = new List<Vector3>();
        GetMoves moves;
        switch(type)
        {
            case FigureType.Pawn:
                moves = MovementPawn;
                break;
            case FigureType.Rook:
                moves = MovementRook;
                break;
            case FigureType.Bishop:
                moves = MovementBishop;
                break;
            case FigureType.Knight:
                moves = MovementKnight;
                break;
            case FigureType.Queen:
                moves = MovementQueen;
                break;
            case FigureType.King:
                moves = MovementKing;
                break;
        }
    }
}