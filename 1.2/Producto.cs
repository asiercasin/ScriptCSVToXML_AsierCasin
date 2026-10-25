public class Producto
{
    protected String nombre;
    protected int stock;
    protected int dia;
    protected int mes;

    public Producto(String pnom, int pstock, int pdia, int pmes)
    {
        this.nombre=pnom;
        this.stock=pstock;
        this.dia=pdia;
        this.mes=pmes;
    }
    public void setnombre(String n)
    {
        this.nombre=n;
    }
    public String getnombre()
    {
        return this.nombre;
    }

    public virtual void renovarstock()
    {
        stock=stock+10;
    }
}