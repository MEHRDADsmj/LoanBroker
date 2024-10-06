namespace BankProviderFactory;

public class BankProviderFactory : IBankProviderFactory.IBankProviderFactory
{
    private Dictionary<string, IBankProvider.IBankProvider> providerDict;

    public BankProviderFactory()
    {
        providerDict = new Dictionary<string, IBankProvider.IBankProvider>
                       {
                           { "bank_a", new BankAProvider.BankAProvider() },
                           { "bank_b", new BankBProvider.BankBProvider() },
                           { "bank_c", new BankCProvider.BankCProvider() },
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