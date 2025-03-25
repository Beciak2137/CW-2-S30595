namespace Cw2_s3059;

public class OverfillException : Exception
{
    public OverfillException() : base("Masa ładunku przekracza maksymalna pojemnosc kontenera") {}
}