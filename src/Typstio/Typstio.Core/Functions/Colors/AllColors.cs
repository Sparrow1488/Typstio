namespace Typstio.Core.Functions.Colors;

public static class AllColors
{
    public static ColorFunction Black => new Luma(0);
    public static ColorFunction Gray => new Luma(170);
    public static ColorFunction Silver => new Luma(221);
    public static ColorFunction White => new Luma(255);
    public static ColorFunction Blue => new Rgb("#0074d9");
    public static ColorFunction Purple => new Rgb("#b10dc9");
    public static ColorFunction Red => new Rgb("#ff4136");
    public static ColorFunction Orange => new Rgb("#ff851b");
    public static ColorFunction Yellow => new Rgb("#ffdc00");
    public static ColorFunction Green => new Rgb("#2ecc40");
    public static ColorFunction Lime => new Rgb("#01ff70");
}