using System;
using UnityEngine;

/// <summary>
/// GameObject型の拡張メソッドを管理するクラス
/// </summary>
public static partial class GameObjectExtensions
{
    /// <summary>
    /// コンポーネントを取得します
    /// コンポーネントが存在しなければ追加してから取得します
    /// </summary>
    /// <typeparam name="T">取得するコンポーネントの型</typeparam>
    /// <param name="gameObject">GameObject型のインスタンス</param>
    /// <returns>コンポーネント</returns>
    public static T SafeGetComponent<T>(this GameObject gameObject) where T : Component {
        return
            gameObject.GetComponent<T>() ??
            gameObject.AddComponent<T>();
    }
}