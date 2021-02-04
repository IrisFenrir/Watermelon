using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 从某个类型中选取某个字段返回值
/// </summary>
/// <typeparam name="T">数据类型</typeparam>
/// <typeparam name="TKey">数据类型的字段类型</typeparam>
/// <param name="t">数据类型的对象</param>
/// <returns>对象的某个字段的值</returns>
public delegate TKey SelectHandler<T,TKey>(T t);
/// <summary>
/// 查找条件委托
/// </summary>
/// <typeparam name="T">查找数据类型</typeparam>
/// <param name="t">数据类型对象</param>
/// <returns></returns>
public delegate bool FindHandler<T>(T t);
public static class ArrayHelper
{
    /// <summary>
    /// 升序排序
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <typeparam name="TKey">数据类型字段的类型</typeparam>
    /// <param name="array">数据类型对象的数组</param>
    /// <param name="handler">委托对象</param>
    public static void OrderBy<T,TKey>(T[] array, SelectHandler<T,TKey> handler) 
        where TKey : IComparable<TKey>
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (handler(array[i]).CompareTo(handler(array[j])) > 0)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    /// <summary>
    /// 降序排序
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <typeparam name="TKey">数据类型字段的类型</typeparam>
    /// <param name="array">数据类型对象的数组</param>
    /// <param name="handler">委托对象</param>
    public static void OrderByDescending<T, TKey>(T[] array, SelectHandler<T, TKey> handler)
        where TKey : IComparable<TKey>
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (handler(array[i]).CompareTo(handler(array[j])) < 0)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    /// <summary>
    /// 返回最大的
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <typeparam name="TKey">数据类型字段的类型</typeparam>
    /// <param name="array">数据类型对象的数组</param>
    /// <param name="handler">委托对象</param>
    public static T Max<T,TKey>(T[] array,SelectHandler<T,TKey> handler)
        where TKey:IComparable<TKey>
    {
        T max = default(T);
        max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if(handler(max).CompareTo(handler(array[i])) < 0)
            {
                max = array[i];
            }
        }
        return max;
    }

    /// <summary>
    /// 返回最小的
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <typeparam name="TKey">数据类型字段的类型</typeparam>
    /// <param name="array">数据类型对象的数组</param>
    /// <param name="handler">委托对象</param>
    public static T Min<T, TKey>(T[] array, SelectHandler<T, TKey> handler)
        where TKey : IComparable<TKey>
    {
        T min = default(T);
        min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (handler(min).CompareTo(handler(array[i])) > 0)
            {
                min = array[i];
            }
        }
        return min;
    }

    /// <summary>
    /// 查找满足handler条件的一个
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    /// <param name="array">数组</param>
    /// <param name="handler">查找条件委托</param>
    /// <returns></returns>
    public static T Find<T>(T[] array,FindHandler<T> handler)
    {
        T temp = default(T);
        for (int i = 0; i < array.Length; i++)
        {
            if(handler(array[i]))
            {
                return array[i];
            }
        }
        return temp;
    }

    /// <summary>
    /// 查找所有满足条件的
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="handler"></param>
    /// <returns></returns>
    public static T[] FindAll<T>(T[] array,FindHandler<T> handler)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < array.Length; i++)
        {
            if(handler(array[i]))
            {
                list.Add(array[i]);
            }
        }
        return list.ToArray();
    }

    /// <summary>
    /// 选取数组中对象的某些成员形成一个独立数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="array"></param>
    /// <param name="handler"></param>
    /// <returns></returns>
    public static TKey[] Select<T,TKey>(T[] array,SelectHandler<T,TKey> handler)
    {
        TKey[] keys = new TKey[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            keys[i] = handler(array[i]);
        }
        return keys;
    }
}

