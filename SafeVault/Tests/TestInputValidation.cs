using NUnit.Framework;
[TestFixture]
public class TestInputValidation {
    [Test]
    public void TestForSQLInjection()
    {
        string maliciousInput = "'; DROP TABLE Users; --";
        var result = SafeVaultApp.RegisterUser(maliciousInput, "test@example.com");
        Assert.AreEqual("Input is invalid", result);
    }

    [Test]
    public void TestForXSS()
    {
        string maliciousScript = "<script>alert('XSS');</script>";
        var result = SafeVaultApp.CleanInput(maliciousScript);
        Assert.AreEqual("&lt;script&gt;alert('XSS');&lt;/script&gt;", result);
    }
}
