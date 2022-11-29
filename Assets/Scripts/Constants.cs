using System.Collections;
using System.Collections.Generic;

public static class Constants {
    //to get index - do elementalMatchup.index(input)
    //To see strong against ((index+1)%3), weak ((index-1)%3)
    public static List<string> elementalMatchup = new List<string>(){"Fire","Plant","Water"};
    public static float normalDmgBoost = 1.25f;
    public static float elementalDmgBoost = 2f;
    public static float elementalResist = 0.5f;
        
        
}

