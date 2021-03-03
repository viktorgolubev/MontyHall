using System;
using System.Collections.Generic;

namespace MontyHall.Extensions
{
    public static class ListDoorsExtensions
    {
        private static Random _Random = new Random();

        public static T Random<T>(this List<T> list)
        {
            return list[_Random.Next(list.Count)];
        }
    }
}
