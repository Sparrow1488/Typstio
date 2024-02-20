using System.Collections;
using System.Runtime.CompilerServices;

namespace Typstio.Core.Helpful;

public readonly struct STuple<T> : IEnumerable<T>
{
   private readonly List<T> _items = new();
   
   private STuple(ITuple x)
   {
      for (var i = 0; i < x.Length; i++)
         _items.Add((T)x[i]!);
   }

   private STuple(T x)
   {
      _items.Add(x);
   }
   
   public static implicit operator STuple<T>(T x) => new(x);
   public static implicit operator STuple<T>((T, T) x) => new(x);
   public static implicit operator STuple<T>((T, T,T) x) => new(x);
   public static implicit operator STuple<T>((T, T, T, T) x) => new(x);
   public static implicit operator STuple<T>((T, T, T, T, T) x) => new(x);
   public static implicit operator STuple<T>((T, T, T, T, T, T) x) => new(x);
   public static implicit operator STuple<T>((T, T, T, T, T, T, T) x) => new(x);
   public static implicit operator STuple<T>((T, T, T, T, T, T, T, T) x) => new(x);
   public static implicit operator STuple<T>((T, T, T, T, T, T, T, T, T) x) => new(x);
   
   public IEnumerator<T> GetEnumerator()
   {
      return _items.GetEnumerator();
   }

   IEnumerator IEnumerable.GetEnumerator()
   {
      return GetEnumerator();
   }
}