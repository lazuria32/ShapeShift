using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stage {
    GameObject originLineObj;
    List<GameObject> shiftPointObjs;
    List<ShiftPoint> shiftPoints;

    List<int> lineStartPointIndexes;
    List<int> lineEndPointIndexes;

    public Stage(List<Vector3> initialPointPositions) {
        shiftPointObjs = new List<GameObject>();
        shiftPoints = new List<ShiftPoint>();
        lineStartPointIndexes = new List<int>();
        lineEndPointIndexes = new List<int>();
        MakeInitialPoints(initialPointPositions);
        originLineObj = GameObject.Find("Line");
    }

    // 初期ポイントを生成
    void MakeInitialPoints(List<Vector3> initialPointPositions) {
        AddPoint(GameObject.Find("StartPoint"));
        foreach(Vector3 position in initialPointPositions) {
            MakePoint(position);
        }
    }

    // シフトポイントを生成
    void MakePoint(Vector3 position) {
        var startPoint = shiftPointObjs.First();
        var newPoint = Object.Instantiate(startPoint) as GameObject;
        newPoint.transform.position = position;
        AddPoint(newPoint);
    }

    // シフトポイントをメンバに追加
    void AddPoint(GameObject obj) {
        shiftPointObjs.Add(obj);
        ShiftPoint shiftPoint = shiftPointObjs.Last().GetComponent<ShiftPoint>();
        shiftPoints.Add(shiftPoint);
    }

    // ステージにラインがあるか？
    public bool HasLine(GameObject point1, GameObject point2) {
        int point1Index, point2Index;
        getLineIndex(point1, point2, out point1Index, out point2Index);

        // リスト内検索
        List<int> point1StartIndexs = ListUtil.FindIndexList(lineStartPointIndexes, point1Index);
        if (point1StartIndexs.Count != 0) {
            foreach (int startIndex in point1StartIndexs) {
                if (lineEndPointIndexes[startIndex] == point2Index) { return true; }
            }
        }
        return false;
    }

    // ステージにラインを引く
    public bool drawLine(GameObject point1, GameObject point2) {
        int point1Index, point2Index;
        getLineIndex(point1, point2, out point1Index, out point2Index);

        // ラインを引く
        lineStartPointIndexes.Add(point1Index);
        lineEndPointIndexes.Add(point2Index);
        GameObject newLine = Object.Instantiate(originLineObj);
        LineRenderer newLineRenderer = newLine.GetComponent<LineRenderer>();
        newLineRenderer.SetPositions(new Vector3[] { point1.transform.position, point2.transform.position });

        // ランダムにポイントを生成
        float[] randPos = new float[3];
        for(int i=0; i<3; i++) {
            if(Random.Range(0,2) == 0) {
                randPos[i] = Random.Range(5, 20);
            } else {
                randPos[i] = Random.Range(-20, -5);
            }
        }
        MakePoint(point2.transform.position + new Vector3(randPos[0], randPos[1], randPos[2]));
        return true;
    }

    // 三角形生成判定 & 生成処理
    void judgeAndMakeTriangle(GameObject point1, GameObject point2) {
        int point1Index = shiftPointObjs.IndexOf(point1);
        int point2Index = shiftPointObjs.IndexOf(point2);
        if (point1Index >= point2Index) swap(ref point1Index, ref point2Index);
        // ここから書く
    }

    // 2点のindexを若い順に取得、ラインについて一意なキーになる
    void getLineIndex(GameObject point1, GameObject point2, out int point1Index, out int point2Index) {
        point1Index = shiftPointObjs.IndexOf(point1);
        point2Index = shiftPointObjs.IndexOf(point2);
        if (point1Index >= point2Index) swap(ref point1Index, ref point2Index);
    }

    // 2つのintを交換
    void swap(ref int obj1, ref int obj2) {
        int temp = obj1;
        obj1 = obj2;
        obj2 = temp;
    }


}
