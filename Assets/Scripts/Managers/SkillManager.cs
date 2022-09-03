using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using Main;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Debug = UnityEngine.Debug;


namespace Managers
{
    public class SkillManager : Singleton<SkillManager>
    {
        public Dictionary<string, Skill> Skills;


        protected override void Awake()
        {
            base.Awake();
            var csv = OpenCSV("Assets/Resources/Skills.csv");
            LoadSkills(csv);
        }


        private void LoadSkills(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var skill = LoadRow(row);
                Skills[skill.Id] = skill;
            }
            
            
        }

        private Skill LoadRow(DataRow row)
        {
            var s = row[5];
            var skill = new Skill
            {
                Id = row[0].ToString(),
                Positive = row[3].ToString().Equals("TRUE"),
                Rarity = int.Parse(row[4].ToString()),
                Modifier = new Status
                {
                    Atk = Convert(row[5]),
                    Piercing = Convert(row[6]),
                    Def = Convert(row[7]),
                    MaxHp = Convert(row[8]),
                    Critical = Convert(row[9]),
                    Dodge = Convert(row[10])
                }
            };
            return skill;
        }

        private static int Convert(object s)
        {
            var ss = (string) s;
            return ss.Equals("") ? 0 : int.Parse(ss);
        }
        
        
        
        private static DataTable OpenCSV(string filePath) //从csv读取数据返回table
        {
            var dt = new DataTable();
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    //记录每次读取的一行记录
                    string strLine = "";
                    //记录每行记录中的各字段内容
                    string[] aryLine = null;
                    string[] tableHead = null;
                    //标示列数
                    int columnCount = 0;
                    //标示是否是读取的第一行
                    bool IsFirst = true;
                    //逐行读取CSV中的数据
                    while ((strLine = sr.ReadLine()) != null)
                    {
                        if (IsFirst == true)
                        {
                            tableHead = strLine.Split(',');
                            IsFirst = false;
                            columnCount = tableHead.Length;
                            //创建列
                            for (int i = 0; i < columnCount; i++)
                            {
                                DataColumn dc = new DataColumn(tableHead[i]);
                                dt.Columns.Add(dc);
                            }
                        }
                        else
                        {
                            aryLine = strLine.Split(',');
                            DataRow dr = dt.NewRow();
                            for (int j = 0; j < columnCount; j++)
                            {
                                dr[j] = aryLine[j];
                            }

                            dt.Rows.Add(dr);
                        }
                    }

                    if (aryLine != null && aryLine.Length > 0)
                    {
                        dt.DefaultView.Sort = tableHead[0] + " " + "asc";
                    }

                    sr.Close();
                    fs.Close();
                    return dt;
                }
            }
        }
    }
}