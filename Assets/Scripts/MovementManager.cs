using UnityEngine;
using System.Collections.Generic;

public class MovementManager : MonoBehaviour
{
    public static List<Transform> whitePieces;  //0 - King, 1 - Q, 2 - a1 R, 3 - h1 R, 4 - b1 N, 5 - g1 N, 6 - c1 B, 7 - f1 B, 8..15 - a..h White Pawns
    public static List<Transform> blackPieces;  //0 - King, 1 - Q, 2 - a8 R, 3 - h8 R, 4 - b8 N, 5 - g8 N, 6 - c8 B, 7 - f8 B, 8..15 - a..h Black Pawns

    [SerializeField] GameObject[] whiteFigures; //Prefabs
    [SerializeField] GameObject[] blackFigures; //Prefabs

    Vector3 scaleVector = new Vector3(0.2f, 0.2f, 0.2f);

    public static int turnCouter = 1;
    public static bool WrongTurn = false;

    private void Awake()
    {
        whitePieces = new List<Transform>();
        blackPieces = new List<Transform>();
        FillDictionary();
        Spawn();
    }

    void Spawn()
    {
        SpawnKings();
        SpawnQueens();
        SpawnRooks();
        SpawnKnights();
        SpawnBishops();
        SpawnPawns();
    }

    Transform SpawnFigure(int id /* id is an index in array in UnityEditor*/, bool isWhite)
    {
        if(isWhite)
        {
            Transform figure = Instantiate(whiteFigures[id].transform);
            figure.localScale = scaleVector;
            whitePieces.Add(figure);
            return figure;
        }
        else
        {
            Transform figure = Instantiate(blackFigures[id].transform);
            figure.localScale = scaleVector;
            blackPieces.Add(figure);
            return figure;
        }
    }

    void SpawnRooks()
    {
        SpawnFigure(2, true).position = Vector3.zero;
        SpawnFigure(2, true).position = new Vector3(7, 0, 0);
        SpawnFigure(2, false).position = new Vector3(0, 0, 7);
        SpawnFigure(2, false).position = new Vector3(7, 0, 7);
    }

    void SpawnBishops()
    {
        SpawnFigure(4, true).position = new Vector3(1, 0, 0);
        SpawnFigure(4, true).position = new Vector3(6, 0, 0);
        SpawnFigure(4, false).position = new Vector3(1, 0, 7);
        SpawnFigure(4, false).position = new Vector3(6, 0, 7);
    }

    void SpawnKnights()
    {
        SpawnFigure(3, true).position = new Vector3(2, 0, 0);
        SpawnFigure(3, true).position = new Vector3(5, 0, 0);
        SpawnFigure(3, false).position = new Vector3(2, 0, 7);
        SpawnFigure(3, false).position = new Vector3(5, 0, 7);
    }

    void SpawnQueens()
    {
        SpawnFigure(1, true).position = new Vector3(3, 0, 0);
        SpawnFigure(1, false).position = new Vector3(3, 0, 7);
    }

    void SpawnKings()
    {
        SpawnFigure(0, true).position = new Vector3(4, 0, 0);
        SpawnFigure(0, false).position = new Vector3(4, 0, 7);
    }

    void SpawnPawns()
    {
        for (int i = 0; i < 8; i++)
        {
            SpawnFigure(5, true).position = new Vector3(i, 0, 1);
        }
        for (int i = 0; i < 8; i++)
        {
            SpawnFigure(5, false).position = new Vector3(i, 0, 6);
        }
    }

    public static void Move(Vector3 pointA, Vector3 pointB, bool whiteTurn)
    {
        if(whiteTurn)
        {
            foreach (Transform piece in whitePieces)
            {
                if((piece.position == pointA) && piece.gameObject.activeSelf)
                {
                    foreach(Transform piece2 in whitePieces)
                    {
                        if((piece2.position == pointB) && (piece2.gameObject.activeSelf))
                        {
                            WrongTurn = true;
                            return;
                        }
                    }
                    foreach(Transform piece2 in blackPieces)
                    {
                        if((piece2.position == pointB) && (piece2.gameObject.activeSelf))
                        {
                            piece2.gameObject.SetActive(false);
                            piece.position = pointB;
                            WrongTurn = false;
                            return;
                        }
                    }
                    piece.position = pointB;
                    WrongTurn = false;
                    return;
                }
            }
            WrongTurn = true;
        }
        else
        {
            foreach (Transform piece in blackPieces)
            {
                if((piece.position == pointA) && piece.gameObject.activeSelf)
                {
                    foreach (Transform piece2 in blackPieces)
                    {
                        if ((piece2.position == pointB) && (piece2.gameObject.activeSelf))
                        {
                            WrongTurn = true;
                            return;
                        }
                    }
                    foreach (Transform piece2 in whitePieces)
                    {
                        if ((piece2.position == pointB) && (piece2.gameObject.activeSelf))
                        {
                            piece2.gameObject.SetActive(false);
                            piece.position = pointB;
                            WrongTurn = false;
                            return;
                        }
                    }
                    piece.position = pointB;
                    WrongTurn = false;
                    return;
                }
            }
            WrongTurn = true;
        }
    }

    void FillDictionary()
    {
        Decoder.coords = new Dictionary<string, Vector3>();
        for (int i = 1; i < 9; i++)
        {
            Decoder.coords.Add($"a{i}", new Vector3(0, 0, i - 1));
            Decoder.coords.Add($"b{i}", new Vector3(1, 0, i - 1));
            Decoder.coords.Add($"c{i}", new Vector3(2, 0, i - 1));
            Decoder.coords.Add($"d{i}", new Vector3(2, 0, i - 1));
            Decoder.coords.Add($"e{i}", new Vector3(3, 0, i - 1));
            Decoder.coords.Add($"f{i}", new Vector3(4, 0, i - 1));
            Decoder.coords.Add($"g{i}", new Vector3(5, 0, i - 1));
            Decoder.coords.Add($"h{i}", new Vector3(6, 0, i - 1));
        }
    }
}
