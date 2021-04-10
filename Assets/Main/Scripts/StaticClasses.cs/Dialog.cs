using UnityEngine;

public static class Dialog {
    public static string[] allFineCollection = new string[] {
        "都可以",
        "都可以",
        "隨便",
        "都行阿",
        "沒意見"
    };
    public static string RandomAllFine => allFineCollection[Random.Range(0, allFineCollection.Length)];

    public static string sameAsYesterday = "可是我昨天才吃過";
    public static string noSour = "今天酸民好多，不想吃酸的";
    public static string noPekoTea = "好油喔peko";
    public static string noSushi = "這鮭魚他媽有夠生，生到我都能聽到牠吵著要把名字改回去";
    public static string notFood = "這能吃嗎";
    public static string youRude = "你在挑釁我嗎？";

    public static string pekoTea = "peko茶壓壓驚";
}
