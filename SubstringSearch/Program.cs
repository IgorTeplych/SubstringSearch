using SubstringSearch;

public static class Programm
{
    public static void Main()
    {
        string s1 = "strongstring";//"большие метеоданные";//
        string s2 = "rin";//"данные";//
        Substring substring = new Substring();
        var vr = substring.SearchSubstringByBrutalForce(s1, s2);
        var vr1 = substring.SearchBoyerMoore(s1, s2);
    }
}