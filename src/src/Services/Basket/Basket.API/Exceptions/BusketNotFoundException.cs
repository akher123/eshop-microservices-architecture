namespace Basket.API.Exceptions;
public class BusketNotFoundException:NotFoundException
{
    public BusketNotFoundException(string userName):base("basket",userName) { }
}
