using System.Linq;

namespace KataFunctions
{
  public class Gcd
  {
    public int[] numbers { get; set; }

    public int calculateGcd(int[] givenNumbers)
    {
      givenNumbers = numbers;
      //use Linq's Aggregate function to accumulate the gcd forumla to gcd(a,b,c)= gcd(a,(gcd(b,c))
      return givenNumbers.Aggregate(gcdFormula);
    }

    static int gcdFormula(int a, int b)
    {
      if (b == 0)
      {
        return a;
      }
      //Euclidean algorithm
      return gcdFormula(b, a % b);
    }
  }
}
