namespace IBankProviderFactory;

public interface IBankProviderFactory
{
    public IBankProvider.IBankProvider GetBankProvider(string bankName);
}