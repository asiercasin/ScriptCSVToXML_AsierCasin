public class Auriculares : Producto
{
    private int metros;
    private bool estipoc;

    public Auriculares(int pmetros, bool pestipoc,String pnom, int pstock, int pdia, int pmes) : base(pnom, pstock, pdia, pmes)
    {
        this.metros=pmetros;
        this.estipoc=pestipoc;
    }

    public void vender()
    {
        if (stock > 0)
        {
            stock=stock-1;
        }
    }
    
    override
    public void renovarstock()
    {
        stock=stock+20;
    }

    

}