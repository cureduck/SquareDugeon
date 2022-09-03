using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public struct Skills : IList<SkillSaveData>
    {

        [SerializeField] private SkillSaveData _data0;
        [SerializeField] private SkillSaveData _data1;
        [SerializeField] private SkillSaveData _data2;
        [SerializeField] private SkillSaveData _data3;
        [SerializeField] private SkillSaveData _data4;
        [SerializeField] private SkillSaveData _data5;
        [SerializeField] private SkillSaveData _data6;
        [SerializeField] private SkillSaveData _data7;
        [SerializeField] private SkillSaveData _data8;
        [SerializeField] private SkillSaveData _data9;

        public IEnumerator<SkillSaveData> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(SkillSaveData item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(SkillSaveData item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(SkillSaveData[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(SkillSaveData item)
        {
            throw new System.NotImplementedException();
        }

        public int Count => 10;
        public bool IsReadOnly { get; }
        public int IndexOf(SkillSaveData item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, SkillSaveData item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public SkillSaveData this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return _data0;
                    case 1: return _data1;
                    case 2: return _data2;
                    case 3: return _data3;
                    case 4: return _data4;
                    case 5: return _data5;
                    case 6: return _data6;
                    case 7: return _data7;
                    case 8: return _data8;
                    case 9: return _data9;
                    default: throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0: 
                        _data0 = value;
                        break;
                    case 1:
                        _data1 = value; break;
                    case 2:
                        _data2 = value;
                        break;
                    case 3:
                        _data3 = value;
                        break;
                    case 4:
                        _data4 = value;
                        break;
                    case 5:
                        _data5 = value;
                        break;
                    case 6:
                        _data6 = value;
                        break;
                    case 7:
                        _data7 = value;
                        break;
                    case 8:
                        _data8 = value;
                        break;
                    case 9:
                        _data9 = value;
                        break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }
    }
}