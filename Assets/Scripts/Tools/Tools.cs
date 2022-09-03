using System;
using System.Reflection;
using PersistData;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public static class Tools
{
    public static void AutoMapping<T>(T s, T t)
    {
        var target = s.GetType();
        var pps = target.GetFields();
            
        foreach (var pp in pps)
        {
            var targetPP = target.GetField(pp.Name);
            object value = pp.GetValue(s);

            if (targetPP != null && value != null)
            {
                targetPP.SetValue(t, value);
            }
            
        }
    }
    
        
    public static T DeepCopy<T>(T obj)
    {
        //如果是字符串或值类型则直接返回
        if (obj is string || obj.GetType().IsValueType) return obj;

        var retval = Activator.CreateInstance(obj.GetType());
        var fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        foreach (var field in fields)
        {
            try { field.SetValue(retval, DeepCopy(field.GetValue(obj))); }
            catch
            {
                // ignored
            }
        }
        return (T)retval;
    }

    public static T DeepClone<T>(T obj) where T : ScriptableObject
    {
        //如果是字符串或值类型则直接返回
        if (obj is string || obj.GetType().IsValueType) return obj;

        var retval = ScriptableObject.CreateInstance<T>();
        var fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        foreach (var field in fields)
        {
            try { field.SetValue(retval, DeepCopy(field.GetValue(obj))); }
            catch
            {
                // ignored
            }
        }
        return (T)retval;
    }
    
}