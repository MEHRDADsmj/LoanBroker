namespace BankProviderFactory;

public class BankProviderFactory
{
    private Dictionary<string, IBankProvider.IBankProvider> providerDict;

    public void Init()
    {
        providerDict = new Dictionary<string, IBankProvider.IBankProvider>
                       {
                           { "bank_a", new BankAProvider.BankAProvider() },
                           { "bank_b", new BankBProvider.BankBProvider() },
                       };
    }

    public IBankProvider.IBankProvider GetBankProvider(string bankName)
    {
        if (providerDict.ContainsKey(bankName.ToLower()))
        {
            return providerDict[bankName.ToLower()];
        }

        throw new KeyNotFoundException("Invalid Bank name");
    }
}