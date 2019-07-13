using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListUtil {

    // listにobjがあるか探してindexのリストを返す。なければ空リストを返却
    public static List<int> FindIndexList(List<int> list, int obj) {
        List<int> retList = new List<int>();
        if (list.Count == 0) {
            return retList;
        }
        for (int startIndex = 0, index = 0; startIndex < list.Count; startIndex = index + 1) {
            index = list.IndexOf(obj, startIndex);
            if (index == -1) {
                break;
            }
            retList.Add(index);
        }
        return retList;
    }
}
