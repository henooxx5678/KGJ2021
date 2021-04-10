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

    // Ship Renter
    public static string confirmRent = "確定要用1000噸鳳梨跟我租船嗎？不後悔的話就拿著鳳梨再撞我一次";
    public static string howToRent = "想租船就拿1000噸鳳梨來";
    public static string afterRent = "酒後不開船，開船不喝酒";
    public static string lossSoMuch = "賠慘了...";
    public static string excavatorSent = "我派的小怪手明天就能把船救出來了";

    // Dock
    public static string noShip = "沒船還想銷售海外？去找船東租艘船吧";
    public static string shipOnlyForPineapple = "此船只運鳳梨，一趟100噸";
    public static string shipBeached = "你的鳳梨船在蘇伊士運河擱淺了，成為了世界的塞子！";
}
