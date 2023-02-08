namespace SubstringSearch.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BrutalSerachSubstringPositivTest()
        {
            string s1 = "strongstring";
            string s2 = "string";
            Substring substring = new Substring();
            var pos = substring.SearchSubstringByBrutalForce(s1, s2);
            Assert.AreEqual(pos, 6);
        }
        [Test]
        public void BrutalSerachSubstringNegativTest()
        {
            string s1 = "strongstring";
            string s2 = "string0";
            Substring substring = new Substring();
            var pos = substring.SearchSubstringByBrutalForce(s1, s2);
            Assert.AreEqual(pos, -1);
        }
        [Test]
        public void BoyerMooreSerachSubstringPositivTest()
        {
            string s1 = "strongstring";
            string s2 = "string";
            Substring substring = new Substring();
            var pos = substring.SearchBoyerMoore(s1, s2);
            Assert.AreEqual(pos, 6);
        }
        [Test]
        public void BoyerMooreSerachMiddleSubstringTest()
        {
            string s1 = "strongstring";
            string s2 = "gst";
            Substring substring = new Substring();
            var pos = substring.SearchBoyerMoore(s1, s2);
            Assert.AreEqual(pos, 5);
        }
        [Test]
        public void BoyerMooreSerachSubstringNegativTest()
        {
            string s1 = "strongstring";
            string s2 = "string0";
            Substring substring = new Substring();
            var pos = substring.SearchBoyerMoore(s1, s2);
            Assert.AreEqual(pos, -1);
        }
    }
}