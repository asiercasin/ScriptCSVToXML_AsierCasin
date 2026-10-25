public class Pantallas : Producto
{
    private String modelo{get; set;}

    public Pantallas(String pmodel,String pnom, int pstock, int pdia, int pmes) : base(pnom, pstock, pdia, pmes)
    {
        this.modelo=pmodel;
    }
    
}