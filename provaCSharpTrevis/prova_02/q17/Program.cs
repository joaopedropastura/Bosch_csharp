using static System.Console;

var pt = new Point(5, 5);
var circ = ConstrutorGeometrico.GetCirculo(pt, 5);
var squa = ConstrutorGeometrico.GetRetangulo(pt, 5, 5);
var tria = ConstrutorGeometrico.GetTriangulo(pt, 5, 5);

WriteLine(circ);
WriteLine(squa);
WriteLine(tria);

public class Point
{
    public Point(int x, int y)
    {
        throw new NotImplementedException();
    }
}

public abstract class FiguraGeometrica
{
    public abstract float Area { get; }
    public abstract float Perimetro { get; }
}

public abstract class Circulo : FiguraGeometrica
{
    public double raio {get;set;}
}
public static class ConstrutorGeometrico
{
    public static FiguraGeometrica GetCirculo(
        Point centro, float raio)
    {
        throw new NotImplementedException();
    }
    
    public static FiguraGeometrica GetRetangulo(
        Point cantoSuperiorEsquerdo, float altura, float largura)
    {
        throw new NotImplementedException();
    }
    
    public static FiguraGeometrica GetTriangulo(
        Point cantoEsquerdo, float baseTriangulo, float altura)
    {
        throw new NotImplementedException();
    }
}
