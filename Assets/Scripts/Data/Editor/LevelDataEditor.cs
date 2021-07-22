using System.Text;
using UnityEditor;
using UnityEngine;

namespace Myproject.Data.Editor
{
#if UNITY_EDITOR
    [CustomEditor(typeof(LevelData))]
    public class LevelDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            LevelData src = (LevelData)target;
            
            src.CharMap = src.CharMap.Replace("\n", "");

            var style = new GUIStyle {alignment = TextAnchor.MiddleCenter};
            style.normal.textColor = Color.white;
            GUILayout.Space(10);
            GUILayout.Label("Map Builder", style);
            
            for (int i = 0; i < 12; i++)
            {
                GUILayout.BeginHorizontal();
                for (int j = 0; j < 12; j++)
                {
                    bool isZero = src.CharMap[i * 12 + j] == '0';
                    GUILayout.BeginVertical();
                    GUI.backgroundColor = isZero ? Color.black : Color.white;
                    if (GUILayout.Button($"{ src.CharMap[i*12+j]}"))
                    {
                        StringBuilder builder = new StringBuilder(src.CharMap);
                        builder[i*12+j] = isZero ? '1' : '0';
                        src.CharMap = builder.ToString();
                    }
                    GUILayout.EndVertical();
                }
                GUILayout.EndHorizontal();
            }
            
            GUI.backgroundColor = Color.white;
            base.OnInspectorGUI();
        }
    }
#endif
}
