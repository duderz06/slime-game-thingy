using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class SlimeFriendTXTreader
{


    private static string FilePath = Path.Combine(Application.persistentDataPath, "SlimeFriendsCollected.txt");



    static void DoesFileExist()
    {

        if (!File.Exists(FilePath))
        {
            File.WriteAllText(FilePath, "");

        }
    }



    public static Dictionary<string, int> Load()
    {
        DoesFileExist();

        Dictionary<string, int> dict = new Dictionary<string, int>();


        foreach (var line in File.ReadAllLines(FilePath))
        {


            if (string.IsNullOrWhiteSpace(line)) { 
                continue; 
            
            }


            if (!line.Contains("="))
            {

                continue;

            }


            string[] parts = line.Split('=');



            string id = parts[0].Trim();

            int value = int.Parse(parts[1].Trim());




            dict[id] = value;


        }



        return dict;


    }




    public static void Save(Dictionary<string, int> dict)
    {
        List<string> lines = new List<string>();


        foreach (var pair in dict)
        {

            lines.Add(pair.Key + "=" + pair.Value);

        }


        File.WriteAllLines(FilePath, lines);



    }



    public static int Get(string id)
    {

        var dict = Load();

        return dict.ContainsKey(id) ? dict[id] : 0;

    }




    public static void Set(string id, int value)
    {

        var dict = Load();

        dict[id] = value;

        Save(dict);

    }



    public static void ResetAll()
    {

        if (File.Exists(FilePath))
        {

            File.Delete(FilePath);

        }

        File.WriteAllText(FilePath, "");
    }


}
