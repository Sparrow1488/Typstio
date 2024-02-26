using System.Collections;
using System.Runtime.CompilerServices;

namespace Typstio.Core.Models;

public readonly struct ArrTuple<T> : IEnumerable<T>
{
   private readonly List<T> _items = new();
   
   private ArrTuple(ITuple x)
   {
      for (var i = 0; i < x.Length; i++)
         _items.Add((T)x[i]!);
   }

   private ArrTuple(T x)
   {
      _items.Add(x);
   }
   
   public static implicit operator ArrTuple<T>(T x) => new(x);
   public static implicit operator ArrTuple<T>((T, T) x) => new(x);
   public static implicit operator ArrTuple<T>((T, T,T) x) => new(x);
   public static implicit operator ArrTuple<T>((T, T, T, T) x) => new(x);
   public static implicit operator ArrTuple<T>((T, T, T, T, T) x) => new(x);
   public static implicit operator ArrTuple<T>((T, T, T, T, T, T) x) => new(x);
   public static implicit operator ArrTuple<T>((T, T, T, T, T, T, T) x) => new(x);
   public static implicit operator ArrTuple<T>((T, T, T, T, T, T, T, T) x) => new(x);
   public static implicit operator ArrTuple<T>((T, T, T, T, T, T, T, T, T) x) => new(x);
   
   public IEnumerator<T> GetEnumerator()
   {
      return _items.GetEnumerator();
   }

   IEnumerator IEnumerable.GetEnumerator()
   {
      return GetEnumerator();
   }
}